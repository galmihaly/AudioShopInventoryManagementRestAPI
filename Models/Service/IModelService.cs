using DemoRestAPI.Categories;
using DemoRestAPI.Helpers;
using DemoRestAPI.Models.Request;
using DemoRestAPI.Models.Response;

namespace DemoRestAPI.Models.Service
{
    public interface IModelService
    {
        Task<ModelListResponse> GetAllModel();
        Task<BaseResponse> SaveModel(SaveModelRequest request);
    }
}
