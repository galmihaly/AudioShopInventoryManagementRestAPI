using DemoRestAPI.Brands.Request;
using DemoRestAPI.Brands.Response;
using DemoRestAPI.Brands.Service;
using DemoRestAPI.Helpers;
using DemoRestAPI.Users.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DemoRestAPI.Brands
{

    [Route("api/brand")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpPost("save")]
        [Authorize(Roles = "ADMIN")]
        [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> SaveBrand([FromBody] SaveBrandRequest request)
        { 
            if (!ModelState.IsValid) return BadRequest(ModelState);

            BaseResponse e = await _brandService.SaveBrand(request);

            if (e.httpStatusCode == StatusCodes.Status400BadRequest)
            {
                return BadRequest(e);
            }
            else if (e.httpStatusCode == StatusCodes.Status409Conflict)
            {
                return Conflict(e);
            }

            return Ok(e);
        }

        [HttpGet("all")]
        [Authorize(Roles = "ADMIN")]
        [ProducesResponseType(typeof(BrandListResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BrandListResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllBrand()
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            BrandListResponse e = await _brandService.GetAllBrand();

            if (e.httpStatusCode == StatusCodes.Status400BadRequest)
            {
                return BadRequest(e);
            }

            return Ok(e);
        }
    }
}
