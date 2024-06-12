using DemoRestAPI.Brands;

namespace DemoRestAPI.Models.Repository
{
    public interface IModelRepository
    {
        Task<Model> Add(Model entity);
        Task<Model> SearchByName(string modelName);
        Task<Model> SearchById(int? modelId);
        Task<List<Model>> GetModels();
        Task<Model> SearchByModelId(string? modelId);
    }
}
