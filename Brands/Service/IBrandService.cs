using DemoRestAPI.Brands.Request;
using DemoRestAPI.Brands.Response;
using DemoRestAPI.Helpers;
using DemoRestAPI.Users;

namespace DemoRestAPI.Brands.Service
{
    public interface IBrandService
    {
        Task<BrandListResponse> GetAllBrand();
        Task<BaseResponse> SaveBrand(SaveBrandRequest request);
    }
}
