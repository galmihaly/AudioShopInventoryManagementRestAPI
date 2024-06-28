
using DemoRestAPI.Storages;

namespace DemoRestAPI.Warehouses.Repository
{
    public interface IWarehouseRepository
    {
        Task<Warehouse> Add(Warehouse entity);
        Task<Warehouse> SearchByWarehouseId(string? wareHouseId);
        Task<Warehouse> SearchById(int? warehouseId);
        Task<bool> IncrementCurrentStockCapacity(string? warehouseId);
        Task<List<Warehouse>> GetWarehouses();
        Task<bool> IncrementWarehouseValues(int? wareHouseId, int? basePrice, int? wholeSalePrice);
        Task<bool> DecrementWarehouseValues(int? wareHouseId, int basePrice, int wholeSalePrice);
    }
}
