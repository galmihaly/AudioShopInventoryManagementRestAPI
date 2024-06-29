using DemoRestAPI.Helpers;
using DemoRestAPI.Users.Request;
using DemoRestAPI.Users.Response;
using DemoRestAPI.Users.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DemoRestAPI.Users
{
    [Route("api/user")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IAuthService _authService;

        public UserController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        [Authorize(Roles = "ADMIN")]
        [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> RegisterUserWithDevice([FromBody] RegisterUserRequest request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            BaseResponse e = await _authService.RegisterUser(request);

            if (e.httpStatusCode == StatusCodes.Status400BadRequest) 
            {
                return BadRequest(e);
            }
            if (e.httpStatusCode == StatusCodes.Status409Conflict)
            {
                return Conflict(e);
            }

            return Ok(e);
        }

        [HttpPost("login")]     
        [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Login(LoginUserRequest userRequest)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            LoginUserResponse e = await _authService.LoginUser(userRequest);

            if (e.httpStatusCode == StatusCodes.Status401Unauthorized)
            {
                return Unauthorized(e);
            }

            return Ok(e);
        }

        [HttpPost("refreshtoken")]
        [Authorize(Roles = "ADMIN")]
        [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> RefreshToken(RefreshTokenRequest model)
        {
            LoginUserResponse e = await _authService.RefreshToken(model);

            if (e.httpStatusCode == StatusCodes.Status401Unauthorized)
            {
                return Unauthorized(e);
            }

            return Ok(e);
        }
    }
}
