using DemoRestAPI.Products.Responses;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace DemoRestAPI.Products.Repository
{
    public class ProductRepository : IProductRepository
    {

        private readonly SqlDBContext _context;

        public ProductRepository(SqlDBContext context)
        {
            _context = context;
        }

        public async Task<Product> Add(Product entity)
        {
            var searchedProduct = await _context.Products
                .FirstOrDefaultAsync(m => m.Barcode == entity.Barcode);

            if (searchedProduct != null)
            {
                return null;
            }

            await _context.Products.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<Product> SearchByBarcode(string? barcode)
        {
            var product = await _context.Products
                .FirstOrDefaultAsync(p => p.Barcode == barcode);


            if (product == null) { return null; }
            return product;
        }

        public async Task<List<Product>> GetProducts(int pageIndex, int pageSize)
        {
            List<Product> productList = null;

            productList = await _context.Products
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

            if (productList == null || productList.Count == 0) { return null; }
            return productList;
        }

        public async Task<List<Product>> GetProducts(int? storageId)
        {
            List<Product> productList = await _context.Products.ToListAsync();
            List<Product> searchedProductList = new List<Product>();

            if (productList != null)
            {
                foreach (var p in productList)
                {
                    if (p.StorageId == storageId)
                    {
                        searchedProductList.Add(p);
                    }
                }
            }

            if (productList == null || searchedProductList == null || searchedProductList.Count == 0) { return null; }
            return searchedProductList;
        }

        public async Task<bool> DeleteProduct(Product deleteEntity)
        {
            _context.Products.Remove(deleteEntity);
            await _context.SaveChangesAsync();

            var searchedProduct = await _context.Products
                .FirstOrDefaultAsync(m => m.Barcode == deleteEntity.Barcode);

            if (searchedProduct != null)
            {
                return false;
            }

            return true;
        }
    }
}
