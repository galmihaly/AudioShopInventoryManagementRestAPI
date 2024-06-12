using Azure.Core;
using DemoRestAPI.Helpers;
using DemoRestAPI.Products.Requests;
using DemoRestAPI.Products.Responses;
using DemoRestAPI.Products.Service;
using DemoRestAPI.Storages.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DemoRestAPI.Products
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService) 
        {
            _productService = productService;
        }

        [HttpPost("save")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> SaveProductList([FromBody] SaveProductListRequest request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            BaseResponse e = await _productService.SaveProductList(request);

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

        [HttpPost("getproducts")]
        [Authorize]
        [ProducesResponseType(typeof(ProductListResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProductListResponse), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(ProductListResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProducts([FromBody] GetProductsRequest request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            ProductListResponse e = await _productService.GetProducts(request);

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

        [HttpDelete("delete/{barcode}/{storageId}/{warehouseId}")]
        [Authorize]
        [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteProduct(string? barcode, string? storageId, string? warehouseId)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            BaseResponse e = await _productService.DeleteProduct(barcode, storageId, warehouseId);

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

        [HttpGet("get/{storageId}")]
        [ProducesResponseType(typeof(StorageListResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(StorageListResponse), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(StorageListResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProducts(string? storageId)
        {

            if (!ModelState.IsValid) return BadRequest(ModelState);

            ProductListResponse e = await _productService.GetProducts(storageId);

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
