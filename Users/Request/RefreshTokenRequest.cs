using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace DemoRestAPI.Users.Request
{
    public class RefreshTokenRequest
    {
        [JsonProperty("access_token", Required = Required.Always)]
        public string? AccessToken { get; set; }

        [JsonProperty("refresh_token", Required = Required.Always)]
        public string? RefreshToken { get; set; }
    }
}
