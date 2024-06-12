using DemoRestAPI.Brands;

namespace DemoRestAPI.Categories.Repository
{
    public interface ICategoryRepository
    {
        Task<Category> Add(Category entity);
        Task<Category> SearchByName(string? categoryName);
        Task<Category> SearchById(int? categoryId);
        Task<List<Category>> GetCategories();
        Task<Category> SearchByCategoryId(string? categoryId);
    }
}
