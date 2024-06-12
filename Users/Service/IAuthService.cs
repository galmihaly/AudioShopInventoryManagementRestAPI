using DemoRestAPI.Helpers;
using DemoRestAPI.Users.Request;
using DemoRestAPI.Users.Response;

namespace DemoRestAPI.Users.Service
{
    public interface IAuthService
    {
        Task<LoginUserResponse> LoginUser(LoginUserRequest loginRequest);
        Task<LoginUserResponse> RefreshToken(RefreshTokenRequest refreshRequest);
        Task<BaseResponse> RegisterUser(RegisterUserRequest registerRequest);
    }
}
