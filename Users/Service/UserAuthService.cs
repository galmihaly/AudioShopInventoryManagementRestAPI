using AudioShopInventoryManagementRestAPI.Helpers;
using DemoRestAPI.Devices;
using DemoRestAPI.Helpers;
using DemoRestAPI.Users.Authentication;
using DemoRestAPI.Users.Request;
using DemoRestAPI.Users.Response;
using DemoRestAPI.Warehouses;
using DemoRestAPI.Warehouses.Repository;
using DemoRestAPI.Warehouses.Response;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace DemoRestAPI.Users.Service
{
    public class UserAuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _config;

        private readonly IWarehouseRepository _warehouseRepository;
        private readonly IDeviceRepository _deviceRepository;
        private readonly RsaKeyGenerator _rsaKeyGenerator;

        public UserAuthService(UserManager<User> userManager, IConfiguration config, IWarehouseRepository warehouseRepository, IDeviceRepository deviceRepository)
        {
            _userManager = userManager;
            _config = config;
            _warehouseRepository = warehouseRepository;
            _rsaKeyGenerator = new RsaKeyGenerator(_config);
            _deviceRepository = deviceRepository;
        }

        public async Task<BaseResponse> RegisterUser(RegisterUserRequest userRequest)
        {
            Warehouse searchedWarehouse = await _warehouseRepository.SearchByWarehouseId(userRequest.WareHouseId);
            if (searchedWarehouse == null)
            {
                return ResponseProvider.GetBaseResponse(ResponseEnum.WAREHOUSE_NOT_EXIST);
            }

            Device NewDevice = new Device
            {
                DeviceId = userRequest.RegisterDeviceRequest.DeviceId,
                Name = userRequest.RegisterDeviceRequest.Name,
                Type = userRequest.RegisterDeviceRequest.Type,
                Active = userRequest.RegisterDeviceRequest.Active,
                CreatedAt = DateTime.Now.AddHours(2),
                ModifiedAt = DateTime.Now.AddHours(2)
            };

            User newUser = new User
            {
                Name = userRequest.Name,
                UserName = userRequest.Username,
                Email = userRequest.Email,
                Address = userRequest.Address,
                PhoneNumber = userRequest.Telephone,
                Right = userRequest.Right,
                Active = userRequest.Active,
                CreatedAt = DateTime.Now.AddHours(2),
                ModifiedAt = DateTime.Now.AddHours(2),
                WareHouse = searchedWarehouse,
                Device = NewDevice
            };

            IdentityResult result = await _userManager.CreateAsync(newUser, userRequest.Password);
            if (!result.Succeeded)
            {
                return ResponseProvider.GetBaseResponse(ResponseEnum.USER_REGISTER_FAILED);
            }

            return ResponseProvider.GetBaseResponse(ResponseEnum.USER_REGISTER_SUCCESS);
        }

        public async Task<LoginUserResponse> LoginUser(LoginUserRequest loginRequest)
        {
            User identityUser = await _userManager.FindByEmailAsync(loginRequest.Email);
            if (identityUser != null) 
            {
                bool isValidPassword = await _userManager.CheckPasswordAsync(identityUser, loginRequest.Password);
                if (identityUser is null || isValidPassword == false)
                {
                    return ResponseProvider.GetLoginUserResponse(ResponseEnum.USER_LOGIN_FAILED);
                }
            }
            else
            {
                return ResponseProvider.GetLoginUserResponse(ResponseEnum.USER_NOT_FOUND);
            }

            return await GenerateTokensWithUserUpdate(identityUser);
        }

        public async Task<LoginUserResponse> RefreshToken(RefreshTokenRequest refreshRequest)
        {
            ClaimsPrincipal principal = GetTokenPrincipal(refreshRequest.AccessToken);
            if (principal == null)
            {
                return ResponseProvider.GetLoginUserResponse(ResponseEnum.USER_PRINCIPAL_NOT_FOUND);
            }

            if (principal?.Identity?.Name is null)
            {
                return ResponseProvider.GetLoginUserResponse(ResponseEnum.USER_PRINCIPAL_NAME_NOT_FOUND); ;
            }

            User user = await _userManager.FindByNameAsync(principal.Identity.Name);
            if (user == null)
            {
                return ResponseProvider.GetLoginUserResponse(ResponseEnum.USER_NOT_FOUND);
            }

            if (user.RefreshToken != refreshRequest.RefreshToken)
            {
                return ResponseProvider.GetLoginUserResponse(ResponseEnum.USER_REFRESHTOKEN_NOT_SAME);
            }

            if (user.RefreshTokenExpiration < DateTime.Now.AddHours(2))
            {
                return ResponseProvider.GetLoginUserResponse(ResponseEnum.USER_REFRESHTOKEN_NOT_EXPIRED);
            }

            return await GenerateTokensWithUserUpdate(user);
        }

        private async Task<LoginUserResponse> GenerateTokensWithUserUpdate(User user)
        {
            Device searchedDevice = await _deviceRepository.SearchById(user.DeviceId);
            if (searchedDevice == null)
            {
                return ResponseProvider.GetLoginUserResponse(ResponseEnum.DEVICE_FOUND_FAILED);
            }

            Warehouse searchedWarehouse = await _warehouseRepository.SearchById(user.WareHouseId);
            if (searchedWarehouse == null)
            {
                return ResponseProvider.GetLoginUserResponse(ResponseEnum.WAREHOUSE_NOT_EXIST);
            }

            string accessToken = GenerateAccessTokenString(user, searchedDevice, searchedWarehouse);
            if (accessToken == null)
            {
                return ResponseProvider.GetLoginUserResponse(ResponseEnum.USER_ACCESSTOKEN_GENERATION_FAILED);
            }

            string refreshToken = GenerateRefreshTokenString();
            if (refreshToken == null)
            {
                return ResponseProvider.GetLoginUserResponse(ResponseEnum.USER_REFRESHTOKEN_GENERATION_FAILED);
            }

            LoginUserDetails details = new LoginUserDetails
            {
                IsLogin = true,
                AccessToken = accessToken,
                RefreshToken = refreshToken
            };

            user.RefreshToken = details.RefreshToken;
            user.RefreshTokenExpiration = DateTime.Now.AddHours(12);
            IdentityResult updatedUser = await _userManager.UpdateAsync(user);
            if (!updatedUser.Succeeded)
            {
                return ResponseProvider.GetLoginUserResponse(ResponseEnum.USER_NOT_UPDATED);
            }

            LoginUserResponse response = ResponseProvider.GetLoginUserResponse(ResponseEnum.USER_LOGIN_SUCCESS);
            response.loginUserDetails = details;

            return response;
        }

        private string GenerateRefreshTokenString()
        {
            byte[] randomNumber = new byte[64];

            using (RandomNumberGenerator numberGenerator = RandomNumberGenerator.Create())
            {
                numberGenerator.GetBytes(randomNumber);
            }

            return Convert.ToBase64String(randomNumber);
        }

        private ClaimsPrincipal? GetTokenPrincipal(string token)
        {
            RsaSecurityKey key = _rsaKeyGenerator.GetRsaAudienceSigningKey();
            if (key == null) return null;

            TokenValidationParameters validation = new TokenValidationParameters
            {
                IssuerSigningKey = key,
                ValidateLifetime = false,
                ValidateActor = false,
                ValidateIssuer = false,
                ValidateAudience = false,
            };

            return new JwtSecurityTokenHandler().ValidateToken(token, validation, out _);
        }

        private string? GenerateAccessTokenString(User user, Device device, Warehouse warehouse)
        {
            RsaSecurityKey rsaKey = _rsaKeyGenerator.GetRsaAudienceSigningKey();
            if (rsaKey == null)
            {
                return null;
            }

            string upperCasedRole = user.Right.ToUpper();
            if (upperCasedRole == null || upperCasedRole == "")
            {
                return null;
            }

            Claim emailClaim = new Claim("email", user.Email);
            Claim roleClaim = new Claim("role", upperCasedRole);
            Claim nameClaim = new Claim("username", user.UserName);
            Claim deviceActiveClaim = new Claim("device_active", device.Active.ToString());
            Claim deviceIdClaim = new Claim("device_id", device.DeviceId);
            Claim warehouseIdClaim = new Claim("warehouse_id", warehouse.WareHouseId);

            List<Claim> claims = new List<Claim>();
            claims?.Add(emailClaim);
            claims?.Add(roleClaim);
            claims?.Add(nameClaim);
            claims?.Add(deviceActiveClaim);
            claims?.Add(deviceIdClaim);
            claims?.Add(warehouseIdClaim);

            SigningCredentials signingCredentials = new SigningCredentials(
                key: rsaKey,
                algorithm: SecurityAlgorithms.RsaSha256
            );

            JwtSecurityToken securityToken = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(20),
                issuer: _config["JWT:Issuer"],
                audience: _config["JWT:Audience"],
                signingCredentials: signingCredentials
            );

            string tokenString = new JwtSecurityTokenHandler().WriteToken(securityToken);
            return tokenString;
        }
    }
}
