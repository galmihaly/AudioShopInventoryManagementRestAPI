using Azure.Core;
using DemoRestAPI.Helpers;
using DemoRestAPI.Models;
using DemoRestAPI.Storages.Repository;
using DemoRestAPI.Storages.Request;
using DemoRestAPI.Storages.Responses;
using DemoRestAPI.Warehouses;
using DemoRestAPI.Warehouses.Repository;
using DemoRestAPI.Warehouses.Response;

namespace DemoRestAPI.Storages.Service
{
    public class StorageService : IStorageService
    {
        private IWarehouseRepository _warehouseRepository;
        private IStorageRepository _storageRepository;

        public StorageService(IWarehouseRepository warehouseRepository, IStorageRepository storageRepository)
        {
            _warehouseRepository = warehouseRepository;
            _storageRepository = storageRepository;
        }

        public async Task<BaseResponse> SaveStorage(SaveStorageRequest request)
        {
            Warehouse searchedWarehouse = await _warehouseRepository.SearchByWarehouseId(request.WareHouseId);
            if (searchedWarehouse == null)
            {
                return WarehouseHelper.GetBaseResponse(WarehouseEnum.FOUND_FAILED);
            }

            Storage existedStorage = await _storageRepository.AsyncSearchById(request.StorageId, searchedWarehouse.Id);
            if (existedStorage != null)
            {
                return StorageHelper.GetBaseResponse(StorageEnum.NOT_EXISTED);
            }

            Storage newStorage = new Storage
            {
                Warehouse = searchedWarehouse,
                StorageId = request.StorageId,
                Quantity = request.Quantity,
                MaxQuantity = request.MaxQuantity,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now
            };

            Storage resultStorage = await _storageRepository.Add(newStorage);
            if (resultStorage == null)
            {
                return StorageHelper.GetBaseResponse(StorageEnum.SAVE_FAILED);
            }

            bool isIncrementedWarehouse = await _warehouseRepository.IncrementCurrentStockCapacity(request.WareHouseId);
            if (isIncrementedWarehouse == false)
            {
                return WarehouseHelper.GetBaseResponse(WarehouseEnum.NOT_INCREMENTED);
            }

            return StorageHelper.GetBaseResponse(StorageEnum.SAVE_SUCCESSFUL);
        }

        public async Task<StorageListResponse> GetStorages(string? warehouseId)
        {
            Warehouse searchedWarehouse = await _warehouseRepository.SearchByWarehouseId(warehouseId);
            if (searchedWarehouse == null)
            {
                return StorageHelper.GetStorageListResponse(WarehouseEnum.FOUND_FAILED);
            }

            List<Storage> existedStorageList = await _storageRepository.GetStoragesByWarehouseId(searchedWarehouse.Id);
            if (existedStorageList == null || existedStorageList.Count == 0)
            {
                return StorageHelper.GetStorageListResponse(StorageEnum.NOT_EXISTED);
            }

            List<StorageDetails> storageDetailsList = new List<StorageDetails>();
            foreach (var s in existedStorageList)
            {
                Console.WriteLine(s);
                StorageDetails mappedObject = Helper.MappingToStorageDetailsObject(s);
                if (mappedObject != null)
                {
                    Console.WriteLine(mappedObject);
                    storageDetailsList.Add(mappedObject);
                }
            }

            StorageListResponse r = StorageHelper.GetStorageListResponse(StorageEnum.FOUND_SUCCESSFUL);
            r.storageDetailsList = storageDetailsList;

            return r;
        }
    }
}
