using DemoRestAPI.Categories.Request;
using DemoRestAPI.Categories.Response;
using DemoRestAPI.Helpers;

namespace DemoRestAPI.Categories.Service
{
    public interface ICategoryService
    {
        Task<CategoryListResponse> GetAllCategory();
        Task<BaseResponse> SaveCategory(SaveCategoryRequest request);
    }
}
