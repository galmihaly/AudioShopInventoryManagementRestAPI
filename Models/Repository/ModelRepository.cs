using DemoRestAPI.Categories;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace DemoRestAPI.Models.Repository
{
    public class ModelRepository : IModelRepository
    {

        private readonly SqlDBContext _context;

        public ModelRepository(SqlDBContext context)
        {
            _context = context;
        }

        public async Task<Model> Add(Model entity)
        {
            var searchedModel = await _context.Models
                .FirstOrDefaultAsync(m => m.ModelId == entity.ModelId);

            if (searchedModel != null)
            {
                return null;
            }

            await _context.Models.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<Model> SearchById(int? modelId)
        {
            var searchedModel = await _context.Models
                .FirstOrDefaultAsync(m => m.Id == modelId);

            if (searchedModel == null) { return null; }
            return searchedModel;
        }

        public async Task<Model> SearchByModelId(string? modelId)
        {
            var searchedModel = await _context.Models
                .FirstOrDefaultAsync(m => m.ModelId == modelId);

            if (searchedModel == null) { return null; }
            return searchedModel;
        }

        public async Task<Model> SearchByName(string? modelName)
        {
            var searchedModel = await _context.Models
                .FirstOrDefaultAsync(m => m.Name == modelName);

            if (searchedModel == null) { return null; }
            return searchedModel;
        }

        public async Task<List<Model>> GetModels()
        {
            List<Model> modelList = await _context.Models.ToListAsync();

            if (modelList == null) { return null; }
            return modelList;
        }
    }
}
