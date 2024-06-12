namespace DemoRestAPI.Brands.Repository
{
    public interface IBrandRepository
    {
        Task<Brand> Add(Brand entity);
        Task<List<Brand>> GetBrands();
        Task<Brand> SearchById(int? brandId);
        Task<Brand> SearchByBrandId(string? brandId);
        Task<Brand> SearchByName(string? brandName);
    }
}
