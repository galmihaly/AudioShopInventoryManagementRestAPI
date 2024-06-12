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
                return WarehouseHelper.GetBaseResponse(WarehouseEnum.NOT_EXISTED);
            }

            Warehouse newWarehouse = new Warehouse
            {
                WareHouseId = request.WareHouseId,
                Name = request.Name,
                Address = request.Address,
                CurrentStockCapacity = request.CurrentStockCapacity,
                StockMaxCapacity = request.StockMaxCapacity,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now
            };

            var resultWarehouse = await _warehouseRepository.Add(newWarehouse);
            if (resultWarehouse == null)
            {
                return WarehouseHelper.GetBaseResponse(WarehouseEnum.SAVE_FAILED);
            }

            return WarehouseHelper.GetBaseResponse(WarehouseEnum.SAVE_SUCCESSFUL);
        }

        public async Task<WareHouseListResponse> GetWarehouses()
        {
            List<Warehouse> existedWarehouseList = await _warehouseRepository.GetWarehouses();
            if (existedWarehouseList == null || existedWarehouseList.Count == 0)
            {
                return WarehouseHelper.GetWarehouseListResponse(WarehouseEnum.NOT_EXISTED);
            }

            List<WarehouseDetails> warehouseDetailsList = new List<WarehouseDetails>();
            foreach (var w in existedWarehouseList)
            {
                WarehouseDetails mappedObject = Helper.MappingToWarehouseDetailsObject(w);
                if (mappedObject != null)
                {
                    warehouseDetailsList.Add(mappedObject);
                }
            }

            WareHouseListResponse r = WarehouseHelper.GetWarehouseListResponse(WarehouseEnum.FOUND_SUCCESSFUL);
            r.warehouseDetails = warehouseDetailsList;

            return r;
        }
    }
}
