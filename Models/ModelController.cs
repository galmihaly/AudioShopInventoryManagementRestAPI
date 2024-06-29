
using DemoRestAPI.Categories;
using DemoRestAPI.Categories.Response;
using DemoRestAPI.Helpers;
using DemoRestAPI.Models.Request;
using DemoRestAPI.Models.Response;
using DemoRestAPI.Models.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DemoRestAPI.Models
{
    [Route("api/model")]
    [ApiController]
    public class ModelController : Controller
    {

        private readonly IModelService _modelService;

        public ModelController(IModelService modelService)
        {
            _modelService = modelService;
        }

        [HttpPost("save")]
        [Authorize(Roles = "ADMIN")]
        [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> SaveCategory([FromBody] SaveModelRequest request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            BaseResponse e = await _modelService.SaveModel(request);

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
        [ProducesResponseType(typeof(ModelListResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ModelListResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllModel()
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            ModelListResponse e = await _modelService.GetAllModel();

            if (e.httpStatusCode == StatusCodes.Status400BadRequest)
            {
                return BadRequest(e);
            }

            return Ok(e);
        }
    }
}
