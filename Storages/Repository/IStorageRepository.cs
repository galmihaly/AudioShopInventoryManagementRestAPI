
using Azure.Core;

namespace DemoRestAPI.Storages.Repository
{
    public interface IStorageRepository
    {
        Task<Storage> Add(Storage entity);
        Task<bool> IncrementQuantity(string? storageId);
        Task<Storage> AsyncSearchById(string? storageId, int? warehouseId);
        Task<Storage> SearchById(int? storageId, int? warehouseId);
        Task<bool> DecrementQuantity(string? storageId);
        Task<List<Storage>> GetStoragesByWarehouseId(int? warehouseId);
        Task<Storage> SearchByStorageId(string? storageId);
    }
}
