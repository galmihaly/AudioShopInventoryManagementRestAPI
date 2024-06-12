using DemoRestAPI.Brands;
using Microsoft.EntityFrameworkCore;

namespace DemoRestAPI.Categories.Repository
{
    public class CategoryRepository : ICategoryRepository
    {

        private readonly SqlDBContext _context;

        public CategoryRepository(SqlDBContext context)
        {
            _context = context;
        }

        public async Task<Category> Add(Category entity)
        {
            var savedCategory = _context.Categories
                .FirstOrDefaultAsync(c => c.CategoryId == entity.CategoryId).Result;

            if (savedCategory != null)
            {
                return null;
            }

            await _context.Categories.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<Category> SearchById(int? categoryId)
        {
            var searchedCategory = await _context.Categories
                .FirstOrDefaultAsync(b => b.Id == categoryId);

            if (searchedCategory == null) { return null; }
            return searchedCategory;
        }

        public async Task<Category> SearchByCategoryId(string? categoryId)
        {
            var searchedCategory = await _context.Categories
                .FirstOrDefaultAsync(b => b.CategoryId == categoryId);

            if (searchedCategory == null) { return null; }
            return searchedCategory;
        }

        public async Task<Category> SearchByName(string? categoryName)
        {
            var searchedCategory = await _context.Categories
                .FirstOrDefaultAsync(c => c.Name == categoryName);

            if (searchedCategory == null) { return null; }
            return searchedCategory;
        }

        public async Task<List<Category>> GetCategories()
        {
            List<Category> categoryList = await _context.Categories.ToListAsync();
           
            if (categoryList == null) { return null; }
            return categoryList;
        }
    }
}
