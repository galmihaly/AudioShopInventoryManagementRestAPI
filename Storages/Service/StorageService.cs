using AudioShopInventoryManagementRestAPI.Helpers;
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
                return ResponseProvider.GetBaseResponse(ResponseEnum.WAREHOUSE_NOT_EXIST);
            }

            Storage existedStorage = await _storageRepository.AsyncSearchById(request.StorageId, searchedWarehouse.Id);
            if (existedStorage != null)
            {
                return ResponseProvider.GetBaseResponse(ResponseEnum.STORAGE_NOT_EXIST);
            }

            Storage newStorage = new Storage
            {
                Warehouse = searchedWarehouse,
                StorageId = request.StorageId,
                Quantity = request.Quantity,
                MaxQuantity = request.MaxQuantity,
                NettoValue = request.NettoValue,
                BruttoValue = request.BruttoValue,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now
            };

            Storage resultStorage = await _storageRepository.Add(newStorage);
            if (resultStorage == null)
            {
                return ResponseProvider.GetBaseResponse(ResponseEnum.STORAGE_SAVE_FAILED);
            }

            bool isIncrementedWarehouse = await _warehouseRepository.IncrementCurrentStockCapacity(request.WareHouseId);
            if (isIncrementedWarehouse == false)
            {
                return ResponseProvider.GetBaseResponse(ResponseEnum.WAREHOUSE_NOT_INCREMENTED);
            }

            return ResponseProvider.GetBaseResponse(ResponseEnum.STORAGE_SAVE_SUCCESSFUL);
        }

        public async Task<StorageListResponse> GetStorages(string? warehouseId)
        {
            Warehouse searchedWarehouse = await _warehouseRepository.SearchByWarehouseId(warehouseId);
            if (searchedWarehouse == null)
            {
                return ResponseProvider.GetStorageListResponse(ResponseEnum.WAREHOUSE_NOT_EXIST);
            }

            List<Storage> existedStorageList = await _storageRepository.GetStoragesByWarehouseId(searchedWarehouse.Id);
            if (existedStorageList == null || existedStorageList.Count == 0)
            {
                return ResponseProvider.GetStorageListResponse(ResponseEnum.STORAGE_NOT_EXIST);
            }

            List<StorageDetails> storageDetailsList = new List<StorageDetails>();
            foreach (var s in existedStorageList)
            {
                Console.WriteLine(s);
                StorageDetails mappedObject = DetailsMapper.MappingToStorageDetailsObject(s);
                if (mappedObject != null)
                {
                    Console.WriteLine(mappedObject);
                    storageDetailsList.Add(mappedObject);
                }
            }

            StorageListResponse r = ResponseProvider.GetStorageListResponse(ResponseEnum.STORAGE_FOUND_SUCCESSFUL);
            r.storageDetailsList = storageDetailsList;

            return r;
        }
    }
}
