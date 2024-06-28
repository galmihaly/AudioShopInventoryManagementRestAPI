using DemoRestAPI.Brands;
using DemoRestAPI.Brands.Response;
using DemoRestAPI.Categories.Request;
using DemoRestAPI.Categories.Response;
using DemoRestAPI.Categories.Service;
using DemoRestAPI.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DemoRestAPI.Categories
{

    [Route("api/category")]
    [ApiController]
    public class CategoryController : Controller
    {

        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost("save")]
        [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> SaveCategory([FromBody] SaveCategoryRequest request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            BaseResponse e = await _categoryService.SaveCategory(request);

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
        [ProducesResponseType(typeof(CategoryListResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(CategoryListResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllCategory()
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            CategoryListResponse e = await _categoryService.GetAllCategory();

            if (e.httpStatusCode == StatusCodes.Status400BadRequest)
            {
                return BadRequest(e);
            }

            return Ok(e);
        }
    }
}
