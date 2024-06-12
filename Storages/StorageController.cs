
using DemoRestAPI.Helpers;
using DemoRestAPI.Models;
using DemoRestAPI.Products.Responses;
using DemoRestAPI.Storages.Request;
using DemoRestAPI.Storages.Responses;
using DemoRestAPI.Storages.Service;
using DemoRestAPI.Warehouses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DemoRestAPI.Storages
{
    [Route("api/storage")]
    [ApiController]
    public class StorageController : Controller
    {
        private readonly IStorageService _storageService;

        public StorageController(IStorageService storageService)
        {
            _storageService = storageService;
        }

        [HttpPost("save")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> SaveStorage([FromBody] SaveStorageRequest request)
        {

            if (!ModelState.IsValid) return BadRequest(ModelState);

            BaseResponse e = await _storageService.SaveStorage(request);

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

        [HttpGet("get/{warehouseId}")]
        [Authorize]
        [ProducesResponseType(typeof(StorageListResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(StorageListResponse), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(StorageListResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetStorages(string? warehouseId)
        {

            if (!ModelState.IsValid) return BadRequest(ModelState);

            StorageListResponse e = await _storageService.GetStorages(warehouseId);

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
