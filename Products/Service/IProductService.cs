using DemoRestAPI.Helpers;
using DemoRestAPI.Products.Requests;
using DemoRestAPI.Products.Responses;

namespace DemoRestAPI.Products.Service
{
    public interface IProductService
    {
        Task<BaseResponse> DeleteProduct(string? barcode, string? storageId, string? warehouseId);
        Task<ProductListResponse> GetProducts(string? storageId);
        Task<ProductListResponse> GetProducts(GetProductsRequest request);
        Task<BaseResponse> SaveProductList(SaveProductListRequest request);
    }
}
