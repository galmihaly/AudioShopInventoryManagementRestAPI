using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace DemoRestAPI.Users.Response
{
    public class LoginUserDetails
    {
        [JsonProperty("is_login", Required = Required.Always)]
        public bool IsLogin { get; set; } = false;

        [JsonProperty("access_token", Required = Required.Always)]
        public string? AccessToken { get; set; }

        [JsonProperty("refresh_token", Required = Required.Always)]
        public string? RefreshToken { get; internal set; }
    }
}
