
namespace DemoRestAPI.Warehouses.Repository
{
    public interface IWarehouseRepository
    {
        Task<Warehouse> Add(Warehouse entity);
        Task<Warehouse> SearchByWarehouseId(string? wareHouseId);
        Task<Warehouse> AsyncSearchById(int? id);
        Task<Warehouse> SearchById(int? warehouseId);
        Task<bool> IncrementCurrentStockCapacity(string? warehouseId);
        Task<List<Warehouse>> GetWarehouses();
    }
}
