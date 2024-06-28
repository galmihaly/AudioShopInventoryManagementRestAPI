using Azure.Core;
using DemoRestAPI.Brands.Response;
using DemoRestAPI.Helpers;
using DemoRestAPI.Products.Responses;
using DemoRestAPI.Products;
using DemoRestAPI.Categories;
using DemoRestAPI.Devices;
using DemoRestAPI.Users;
using DemoRestAPI.Warehouses;
using DemoRestAPI.Brands.Request;
using DemoRestAPI.Brands.Repository;
using AudioShopInventoryManagementRestAPI.Helpers;

namespace DemoRestAPI.Brands.Service
{
    public class BrandService : IBrandService
    {
        private IBrandRepository _brandRepository;

        public BrandService(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public async Task<BaseResponse> SaveBrand(SaveBrandRequest request)
        {
            Brand existedBrand = await _brandRepository.SearchByName(request.Name);
            if (existedBrand != null)
            {
                return ResponseProvider.GetBaseResponse(ResponseEnum.BRAND_ALREADY_EXIST);
            }

            Brand NewBrand = new Brand
            {
                BrandId = request.BrandId,
                Name = request.Name,
                Owner = request.Owner,
                Products = null
            };

            Brand resultBrand = await _brandRepository.Add(NewBrand);
            if (resultBrand == null)
            {
                return ResponseProvider.GetBaseResponse(ResponseEnum.BRAND_SAVE_FAILED);
            }

            return ResponseProvider.GetBaseResponse(ResponseEnum.BRAND_SAVE_SUCCESSFUL);
        }

        public async Task<BrandListResponse> GetAllBrand()
        {
            List<Brand> brands = await _brandRepository.GetBrands();
            if (brands == null)
            {
                return ResponseProvider.GetBrandListResponse(ResponseEnum.BRAND_NOT_EXIST);
            }

            List<Brand> brandList = brands.ToList();
            List<BrandDetails> brandDetailsList = new List<BrandDetails>();
            brandList.ForEach(b =>
            {
                BrandDetails mappedObject = DetailsMapper.MappingToBrandDetailsObject(b);
                if(mappedObject != null)
                {
                    brandDetailsList.Add(mappedObject);
                }
            });

            BrandListResponse response = ResponseProvider.GetBrandListResponse(ResponseEnum.BRAND_LIST_SUCCESS);
            response.brandDetails = brandDetailsList;

            return response;
        }
    }
}
