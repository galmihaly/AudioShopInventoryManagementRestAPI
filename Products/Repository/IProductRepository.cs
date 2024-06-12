using DemoRestAPI.Products.Responses;

namespace DemoRestAPI.Products.Repository
{
    public interface IProductRepository
    {
        Task<Product> Add(Product entity);
        Task<List<Product>> GetProducts(int pageIndex, int pageSize);
        Task<List<Product>> GetProducts(int? storageId);
        Task<Product> SearchByBarcode(string? barcode);
        Task<bool> DeleteProduct(Product entity);
    }
}
