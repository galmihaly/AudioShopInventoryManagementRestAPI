using DemoRestAPI.Products;
using Microsoft.EntityFrameworkCore;

namespace DemoRestAPI.Brands.Repository
{
    public class BrandRepository : IBrandRepository
    {

        private readonly SqlDBContext _context;

        public BrandRepository(SqlDBContext context)
        {
            _context = context;
        }

        public async Task<Brand> Add(Brand entity)
        {
            var savedBrand = await _context.Brands
                .FirstOrDefaultAsync(b => b.BrandId == entity.BrandId);

            if (savedBrand != null)
            {
                return null;
            }

            await _context.Brands.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<Brand> SearchById(int? brandId)
        {
            var searchedBrand = await _context.Brands
                .FirstOrDefaultAsync(b => b.Id == brandId);

            if (searchedBrand == null) { return null; }
            return searchedBrand;
        }

        public async Task<Brand> SearchByBrandId(string? brandId)
        {
            var searchedBrand = await _context.Brands
                .FirstOrDefaultAsync(b => b.BrandId == brandId);

            if (searchedBrand == null) { return null; }
            return searchedBrand;
        }

        public async Task<Brand> SearchByName(string? brandName)
        {
            var searchedBrand = await _context.Brands
                .FirstOrDefaultAsync(b => b.Name == brandName);

            if (searchedBrand == null) { return null; }
            return searchedBrand;
        }

        public async Task<List<Brand>> GetBrands()
        {
            List<Brand> brandList = await _context.Brands.ToListAsync();

            if (brandList == null) { return null; }
            return brandList;
        }
    }
}
