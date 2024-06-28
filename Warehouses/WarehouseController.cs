
using DemoRestAPI.Brands;
using DemoRestAPI.Helpers;
using DemoRestAPI.Models;
using DemoRestAPI.Warehouses.Request;
using DemoRestAPI.Warehouses.Response;
using DemoRestAPI.Warehouses.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DemoRestAPI.Warehouses
{
    [Route("api/warehouse")]
    [ApiController]
    public class WarehouseController : Controller
    {
        private readonly IWarehouseService _warehouseService;

        public WarehouseController(IWarehouseService warehouseService)
        {
            _warehouseService = warehouseService;
        }

        [HttpPost("save")]
        [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> SaveWareHouse([FromBody] SaveWarehouseRequest request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            BaseResponse e = await _warehouseService.SaveWarehouse(request);

            if (e.httpStatusCode == StatusCodes.Status400BadRequest)
            {
                return BadRequest(JsonConvert.SerializeObject(e, Formatting.Indented));
            }
            else if (e.httpStatusCode == StatusCodes.Status409Conflict)
            {
                return Conflict(JsonConvert.SerializeObject(e, Formatting.Indented));
            }

            return Ok(JsonConvert.SerializeObject(e, Formatting.Indented));
        }

        [HttpGet("all")]
        [ProducesResponseType(typeof(WareHouseListResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(WareHouseListResponse), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(WareHouseListResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetWareHouses()
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            WareHouseListResponse e = await _warehouseService.GetWarehouses();

            if (e.httpStatusCode == StatusCodes.Status400BadRequest)
            {
                return BadRequest(JsonConvert.SerializeObject(e, Formatting.Indented));
            }
            else if (e.httpStatusCode == StatusCodes.Status409Conflict)
            {
                return Conflict(JsonConvert.SerializeObject(e, Formatting.Indented));
            }

            return Ok(JsonConvert.SerializeObject(e, Formatting.Indented));
        }
    }
}
