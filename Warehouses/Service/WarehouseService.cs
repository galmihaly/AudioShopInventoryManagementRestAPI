using Azure.Core;
using DemoRestAPI.Brands;
using DemoRestAPI.Categories;
using DemoRestAPI.Devices;
using DemoRestAPI.Helpers;
using DemoRestAPI.Products.Responses;
using DemoRestAPI.Products;
using DemoRestAPI.Users;
using DemoRestAPI.Warehouses.Repository;
using DemoRestAPI.Warehouses.Request;
using DemoRestAPI.Warehouses.Response;
using Microsoft.IdentityModel.Tokens;
using AudioShopInventoryManagementRestAPI.Helpers;

namespace DemoRestAPI.Warehouses.Service
{
    public class WarehouseService : IWarehouseService
    {
        private IWarehouseRepository _warehouseRepository;

        public WarehouseService(IWarehouseRepository warehouseRepository)
        {
            _warehouseRepository = warehouseRepository;
        }

        public async Task<BaseResponse> SaveWarehouse(SaveWarehouseRequest request)
        {
            Warehouse existedWarehouse = await _warehouseRepository.SearchByWarehouseId(request.WareHouseId);
            if (existedWarehouse != null)
            {
                return ResponseProvider.GetBaseResponse(ResponseEnum.WAREHOUSE_NOT_EXIST);
            }

            Warehouse newWarehouse = new Warehouse
            {
                WareHouseId = request.WareHouseId,
                Name = request.Name,
                Address = request.Address,
                CurrentStockCapacity = request.CurrentStockCapacity,
                StockMaxCapacity = request.StockMaxCapacity,
                NettoValue = request.NettoValue,
                BruttoValue = request.BruttoValue,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now
            };

            var resultWarehouse = await _warehouseRepository.Add(newWarehouse);
            if (resultWarehouse == null)
            {
                return ResponseProvider.GetBaseResponse(ResponseEnum.WAREHOUSE_SAVE_FAILED);
            }

            return ResponseProvider.GetBaseResponse(ResponseEnum.WAREHOUSE_SAVE_SUCCESSFUL);
        }

        public async Task<WareHouseListResponse> GetWarehouses()
        {
            List<Warehouse> existedWarehouseList = await _warehouseRepository.GetWarehouses();
            if (existedWarehouseList == null || existedWarehouseList.Count == 0)
            {
                return ResponseProvider.GetWarehouseListResponse(ResponseEnum.WAREHOUSE_NOT_EXIST);
            }

            List<WarehouseDetails> warehouseDetailsList = new List<WarehouseDetails>();
            foreach (var w in existedWarehouseList)
            {
                WarehouseDetails mappedObject = DetailsMapper.MappingToWarehouseDetailsObject(w);
                if (mappedObject != null)
                {
                    warehouseDetailsList.Add(mappedObject);
                }
            }

            WareHouseListResponse r = ResponseProvider.GetWarehouseListResponse(ResponseEnum.WAREHOUSE_FOUND_SUCCESSFUL);
            r.warehouseDetails = warehouseDetailsList;

            return r;
        }
    }
}
