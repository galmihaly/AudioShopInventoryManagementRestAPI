using AudioShopInventoryManagementRestAPI.Helpers;
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
                return ResponseProvider.GetBaseResponse(ResponseEnum.DEVICE_FOUND_FAILED);
            }

            User searchedUser = await _userRepository.SearchByUserNameAndDeviceId(request.username, searchedDevice.Id);
            if (searchedUser == null)
            {
                return ResponseProvider.GetBaseResponse(ResponseEnum.USER_NOT_FOUND);
            }

            foreach (var item in request.productList!)
            {
                Brand searchedBrand = await _brandRepository.SearchByBrandId(item.brandId);
                if (searchedBrand == null)
                {
                    return ResponseProvider.GetBaseResponse(ResponseEnum.BRAND_NOT_EXIST);
                }

                Category searchedCategory = await _categoryRepository.SearchByCategoryId(item.categoryId);
                if (searchedCategory == null)
                {
                    return ResponseProvider.GetBaseResponse(ResponseEnum.CATEGORY_NOT_EXIST);
                }

                Model searchedModel = await _modelRepository.SearchByModelId(item.modelId);
                if (searchedModel == null)
                {
                    return ResponseProvider.GetBaseResponse(ResponseEnum.MODEL_NOT_EXIST);
                }

                Warehouse searchedWareHouse = await _warehouseRepository.SearchByWarehouseId(item.wareHouseId);
                if (searchedWareHouse == null)
                {
                    return ResponseProvider.GetBaseResponse(ResponseEnum.WAREHOUSE_NOT_EXIST);
                }

                Storage searchedStorage = await _storageRepository.AsyncSearchById(item.storageId, searchedWareHouse.Id);
                if (searchedStorage == null)
                {
                    return ResponseProvider.GetBaseResponse(ResponseEnum.STORAGE_NOT_EXIST);
                }

                string productId = Helper.GetProductId(searchedBrand.BrandId!, searchedCategory.CategoryId!, searchedModel.ModelId!);
                if (productId == null)
                {
                    return ResponseProvider.GetBaseResponse(ResponseEnum.PRODUCT_ID_GENERATION_FAILED);
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
                    return ResponseProvider.GetBaseResponse(ResponseEnum.PRODUCT_SAVE_FAILED);
                }

                bool isUpdatedStorage = await _storageRepository.IncrementQuantity(searchedStorage.StorageId);
                if (isUpdatedStorage == false)
                {
                    return ResponseProvider.GetBaseResponse(ResponseEnum.STORAGE_QUANTITY_INCREMENT_FAILED);
                }

                isUpdatedStorage = await _storageRepository.IncrementStorageValues(searchedStorage.StorageId, newProduct.BasePrice, newProduct.WholeSalePrice);
                if (isUpdatedStorage == false)
                {
                    return ResponseProvider.GetBaseResponse(ResponseEnum.STORAGE_PRICEVALUES_INCREMENT_FAILED);
                }

                bool isUpdatedWarehouse = await _warehouseRepository.IncrementWarehouseValues(searchedStorage.WareHouseId, newProduct.BasePrice, newProduct.WholeSalePrice);
                if (isUpdatedWarehouse == false)
                {
                    return ResponseProvider.GetBaseResponse(ResponseEnum.WAREHOUSE_PRICEVALUES_INCREMENT_FAILED);
                }
            }

            return ResponseProvider.GetBaseResponse(ResponseEnum.PRODUCT_SAVE_SUCCESSFUL);
        }

        public async Task<ProductListResponse> GetProducts(GetProductsRequest request)
        {
            List<Product> products = await _productRepository.GetProducts((int)request.PageIndex, (int)request.PageSize);
            if (products == null)
            {
                return ResponseProvider.GetProductListResponse(ResponseEnum.PRODUCT_NOT_EXIST);
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

                ProductDetails mappedObject = DetailsMapper.MappingToProductDetailsObject(p, b, c, m, u, d, w, s);
                if (mappedObject != null)
                {
                    productDetailsList.Add(mappedObject);
                }
            }

            ProductListResponse response = ResponseProvider.GetProductListResponse(ResponseEnum.PRODUCT_LIST_SUCCESS);
            response.productDetails = productDetailsList;

            return response;
        }

        public async Task<BaseResponse> DeleteProduct(string? barcode, string? storageId, string? warehouseId)
        {
            Product existedProduct = await _productRepository.SearchByBarcode(barcode);
            if (existedProduct == null)
            {
                return ResponseProvider.GetBaseResponse(ResponseEnum.PRODUCT_NOT_EXIST);
            }

            bool isDeletedProduct = await _productRepository.DeleteProduct(existedProduct);
            if (isDeletedProduct == false)
            {
                return ResponseProvider.GetBaseResponse(ResponseEnum.PRODUCT_DELETED_FAILED);
            }

            Warehouse searchedWarehouse = await _warehouseRepository.SearchByWarehouseId(warehouseId);
            if (searchedWarehouse == null)
            {
                return ResponseProvider.GetBaseResponse(ResponseEnum.WAREHOUSE_NOT_EXIST);
            }

            Storage searchedStorage = await _storageRepository.AsyncSearchById(storageId, searchedWarehouse.Id);
            if (searchedStorage == null)
            {
                return ResponseProvider.GetBaseResponse(ResponseEnum.STORAGE_NOT_EXIST);
            }

            bool isUpdatedStorage = await _storageRepository.DecrementQuantity(searchedStorage.StorageId);
            if (isUpdatedStorage == false)
            {
                return ResponseProvider.GetBaseResponse(ResponseEnum.STORAGE_QUANTITY_DECREMENT_FAILED);
            }

            isUpdatedStorage = await _storageRepository.DecrementStorageValues(searchedStorage.StorageId, existedProduct.BasePrice, existedProduct.WholeSalePrice);
            if (isUpdatedStorage == false)
            {
                return ResponseProvider.GetBaseResponse(ResponseEnum.STORAGE_PRICEVALUES_DECREMENT_FAILED);
            }

            bool isUpdatedWarehouse = await _warehouseRepository.DecrementWarehouseValues(searchedStorage.WareHouseId, existedProduct.BasePrice, existedProduct.WholeSalePrice);
            if (isUpdatedWarehouse == false)
            {
                return ResponseProvider.GetBaseResponse(ResponseEnum.WAREHOUSE_PRICEVALUES_DECREMENT_FAILED);
            }

            return ResponseProvider.GetBaseResponse(ResponseEnum.PRODUCT_DELETED_SUCCESS);
        }

        public async Task<ProductListResponse> GetProducts(string? storageId)
        {
            Storage searchedStorage = await _storageRepository.SearchByStorageId(storageId);
            if (searchedStorage == null)
            {
                return ResponseProvider.GetProductListResponse(ResponseEnum.PRODUCT_NOT_EXIST);
            }

            List<Product> products = await _productRepository.GetProducts(searchedStorage.Id);
            if (products == null)
            {
                return ResponseProvider.GetProductListResponse(ResponseEnum.PRODUCT_NOT_EXIST);
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

                ProductDetails mappedObject = DetailsMapper.MappingToProductDetailsObject(p, b, c, m, u, d, w, searchedStorage);
                if (mappedObject != null)
                {
                    productDetailsList.Add(mappedObject);
                }
            }

            ProductListResponse response = ResponseProvider.GetProductListResponse(ResponseEnum.PRODUCT_LIST_SUCCESS);
            response.productDetails = productDetailsList;

            return response;
        }
    }
}
