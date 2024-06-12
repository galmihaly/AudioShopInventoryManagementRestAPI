using DemoRestAPI.Helpers;
using DemoRestAPI.Models;
using DemoRestAPI.Storages.Request;
using DemoRestAPI.Storages.Responses;

namespace DemoRestAPI.Storages.Service
{
    public interface IStorageService
    {
        Task<StorageListResponse> GetStorages(string? warehouseId);
        Task<BaseResponse> SaveStorage(SaveStorageRequest request);
    }
}
