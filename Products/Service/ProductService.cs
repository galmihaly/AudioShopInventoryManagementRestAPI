using Azure.Core;
using DemoRestAPI.Brands;
using DemoRestAPI.Brands.Repository;
using DemoRestAPI.Brands.Response;
using DemoRestAPI.Categories;
using DemoRestAPI.Categories.Repository;
using DemoRestAPI.Categories.Response;
using DemoRestAPI.Devices;
using DemoRestAPI.Helpers;
using DemoRestAPI.Models;
using DemoRestAPI.Models.Repository;
using DemoRestAPI.Models.Response;
using DemoRestAPI.Products.Repository;
using DemoRestAPI.Products.Requests;
using DemoRestAPI.Products.Responses;
using DemoRestAPI.Storages;
using DemoRestAPI.Storages.Repository;
using DemoRestAPI.Storages.Responses;
using DemoRestAPI.Users;
using DemoRestAPI.Users.Repository;
using DemoRestAPI.Users.Response;
using DemoRestAPI.Warehouses;
using DemoRestAPI.Warehouses.Repository;
using DemoRestAPI.Warehouses.Response;

namespace DemoRestAPI.Products.Service
{
    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;
        private IBrandRepository _brandRepository;
        private ICategoryRepository _categoryRepository;
        private IModelRepository _modelRepository;

        private IUserRepository _userRepository;
        private IStorageRepository _storageRepository;
        private IWarehouseRepository _warehouseRepository;
        private IDeviceRepository _deviceRepository;

        public ProductService(IProductRepository productRepository, IBrandRepository brandRepository, ICategoryRepository categoryRepository, IModelRepository modelRepository, IUserRepository userRepository, IStorageRepository storageRepository, IWarehouseRepository warehouseRepository, IDeviceRepository deviceRepository)
        {
            _brandRepository = brandRepository;
            _categoryRepository = categoryRepository;
            _modelRepository = modelRepository;
            _userRepository = userRepository;
            _storageRepository = storageRepository;
            _productRepository = productRepository;
            _warehouseRepository = warehouseRepository;
            _deviceRepository = deviceRepository;
        }

        public async Task<BaseResponse> SaveProductList(SaveProductListRequest request)
        {
            Device searchedDevice = await _deviceRepository.SearchByDeviceId(request.deviceId);
            if (searchedDevice == null)
            {
                return DeviceHelper.GetBaseResponse(DeviceEnum.FOUND_FAILED);
            }

            User searchedUser = await _userRepository.SearchByUserNameAndDeviceId(request.userName, searchedDevice.Id);
            if (searchedUser == null)
            {
                return UserHelper.GetBaseResponse(UserEnum.USER_NOT_FOUND);
            }

            foreach (var item in request.productList!)
            {
                Product existedProduct = await _productRepository.SearchByBarcode(item.barcode);
                if (existedProduct != null)
                {
                    return ProductHelper.GetBaseResponse(ProductEnum.EXISTED);
                }

                Brand searchedBrand = await _brandRepository.SearchByBrandId(item.brandId);
                if (searchedBrand == null)
                {
                    return BrandHelper.GetBaseResponse(BrandEnum.FOUND_FAILED);
                }

                Category searchedCategory = await _categoryRepository.SearchByCategoryId(item.categoryId);
                if (searchedCategory == null)
                {
                    return CategoryHelper.GetBaseResponse(CategoryEnum.FOUND_FAILED);
                }

                Model searchedModel = await _modelRepository.SearchByModelId(item.modelId);
                if (searchedModel == null)
                {
                    return ModelHelper.GetBaseResponse(ModelEnum.FOUND_FAILED);
                }

                Warehouse searchedWareHouse = await _warehouseRepository.SearchByWarehouseId(item.wareHouseId);
                if (searchedWareHouse == null)
                {
                    return WarehouseHelper.GetBaseResponse(WarehouseEnum.FOUND_FAILED);
                }

                Storage searchedStorage = await _storageRepository.AsyncSearchById(item.storageId, searchedWareHouse.Id);
                if (searchedStorage == null)
                {
                    return StorageHelper.GetBaseResponse(StorageEnum.FOUND_FAILED);
                }

                string productId = Helper.GetProductId(searchedBrand.BrandId!, searchedCategory.CategoryId!, searchedModel.ModelId!);
                if (productId == null)
                {
                    return ProductHelper.GetBaseResponse(ProductEnum.ID_GENERATION_FAILED);
                }

                Product newProduct = new Product
                {
                    ProductId = productId,
                    Brand = searchedBrand,
                    Category = searchedCategory,
                    Model = searchedModel,
                    User = searchedUser,
                    Storage = searchedStorage,
                    BasePrice = item.basePrice,
                    WholeSalePrice = item.wholeSalePrice,
                    Barcode = item.barcode!,
                    CreatedAt = DateTime.Now,
                    ModifiedAt = DateTime.Now
                };

                Product resultProduct = await _productRepository.Add(newProduct);
                if (resultProduct == null)
                {
                    return ProductHelper.GetBaseResponse(ProductEnum.SAVE_FAILED);
                }

                bool isUpdatedStorage = await _storageRepository.IncrementQuantity(searchedStorage.StorageId);
                if (isUpdatedStorage == false)
                {
                    return StorageHelper.GetBaseResponse(StorageEnum.QUANTITY_INCREMENT_FAILED);
                }
            }

            return ProductHelper.GetBaseResponse(ProductEnum.SAVE_SUCCESSFUL);
        }

        public async Task<ProductListResponse> GetProducts(GetProductsRequest request)
        {
            List<Product> products = await _productRepository.GetProducts((int)request.PageIndex, (int)request.PageSize);
            if (products == null)
            {
                return ProductHelper.GetProductListResponse(ProductEnum.NOT_EXISTED);
            }

            List<ProductDetails> productDetailsList = new List<ProductDetails>();
            foreach (var p in products)
            {
                Brand b = await _brandRepository.SearchById(p.BrandId);
                Category c = await _categoryRepository.SearchById(p.CategoryId);
                Model m = await _modelRepository.SearchById(p.ModelId);
                User u = await _userRepository.SearchById(p.UserId);
                Device d = null;
                Warehouse w = null;
                Storage s = null;

                if (u != null)
                {
                    d = await _deviceRepository.SearchById(u.DeviceId);
                    w = await _warehouseRepository.SearchById(u.WareHouseId);
                    s = await _storageRepository.SearchById(p.StorageId, u.WareHouseId);
                }

                ProductDetails mappedObject = Helper.MappingToProductDetailsObject(p, b, c, m, u, d, w, s);
                if (mappedObject != null)
                {
                    productDetailsList.Add(mappedObject);
                }
            }

            ProductListResponse response = ProductHelper.GetProductListResponse(ProductEnum.PORDUCT_LIST_SUCCESS);
            response.productDetails = productDetailsList;

            return response;
        }

        public async Task<BaseResponse> DeleteProduct(string? barcode, string? storageId, string? warehouseId)
        {
            Product existedProduct = await _productRepository.SearchByBarcode(barcode);
            if (existedProduct == null)
            {
                return ProductHelper.GetBaseResponse(ProductEnum.NOT_EXISTED);
            }

            bool isDeletedProduct = await _productRepository.DeleteProduct(existedProduct);
            if (isDeletedProduct == false)
            {
                return ProductHelper.GetBaseResponse(ProductEnum.DELETED_FAILED);
            }

            Warehouse searchedWarehouse = await _warehouseRepository.SearchByWarehouseId(warehouseId);
            if (searchedWarehouse == null)
            {
                return WarehouseHelper.GetBaseResponse(WarehouseEnum.FOUND_FAILED);
            }

            Storage searchedStorage = await _storageRepository.AsyncSearchById(storageId, searchedWarehouse.Id);
            if (searchedStorage == null)
            {
                return StorageHelper.GetBaseResponse(StorageEnum.FOUND_FAILED);
            }

            bool isUpdatedStorage = await _storageRepository.DecrementQuantity(searchedStorage.StorageId);
            if (isUpdatedStorage == false)
            {
                return StorageHelper.GetBaseResponse(StorageEnum.QUANTITY_DECREMENT_FAILED);
            }

            return ProductHelper.GetBaseResponse(ProductEnum.DELETED_SUCCESS);
        }

        public async Task<ProductListResponse> GetProducts(string? storageId)
        {
            Storage searchedStorage = await _storageRepository.SearchByStorageId(storageId);
            if (searchedStorage == null)
            {
                return ProductHelper.GetProductListResponse(ProductEnum.NOT_EXISTED);
            }

            List<Product> products = await _productRepository.GetProducts(searchedStorage.Id);
            if (products == null)
            {
                return ProductHelper.GetProductListResponse(ProductEnum.NOT_EXISTED);
            }

            List<ProductDetails> productDetailsList = new List<ProductDetails>();
            foreach (var p in products)
            {
                Brand b = await _brandRepository.SearchById(p.BrandId);
                Category c = await _categoryRepository.SearchById(p.CategoryId);
                Model m = await _modelRepository.SearchById(p.ModelId);
                User u = await _userRepository.SearchById(p.UserId);
                Device d = null;
                Warehouse w = null;

                if (u != null)
                {
                    d = await _deviceRepository.SearchById(u.DeviceId);
                    w = await _warehouseRepository.SearchById(u.WareHouseId);
                }

                ProductDetails mappedObject = Helper.MappingToProductDetailsObject(p, b, c, m, u, d, w, searchedStorage);
                if (mappedObject != null)
                {
                    productDetailsList.Add(mappedObject);
                }
            }

            ProductListResponse response = ProductHelper.GetProductListResponse(ProductEnum.PORDUCT_LIST_SUCCESS);
            response.productDetails = productDetailsList;

            return response;
        }
    }
}
