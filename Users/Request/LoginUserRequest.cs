using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace DemoRestAPI.Users.Request
{
    public class LoginUserRequest
    {
        [JsonProperty("email", Required = Required.Always)]
        public string? Email { get; set; }

        [JsonProperty("password", Required = Required.Always)]
        public string? Password { get; set; }
    }
}
