using DemoRestAPI.Brands;
using DemoRestAPI.Helpers;
using DemoRestAPI.Warehouses.Request;
using DemoRestAPI.Warehouses.Response;

namespace DemoRestAPI.Warehouses.Service
{
    public interface IWarehouseService
    {
        Task<WareHouseListResponse> GetWarehouses();
        Task<BaseResponse> SaveWarehouse(SaveWarehouseRequest request);
    }
}
