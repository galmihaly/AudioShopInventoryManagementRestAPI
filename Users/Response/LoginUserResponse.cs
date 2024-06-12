using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace DemoRestAPI.Users.Response
{
    public class LoginUserResponse
    {
        [JsonProperty("timestamp", Required = Required.Always)]
        public DateTime? timestamp { get; set; }

        [JsonProperty("status_code", Required = Required.Always)]
        public int? httpStatusCode { get; set; }

        [JsonProperty("message_type", Required = Required.Always)]
        public string? messageType { get; set; }

        [JsonProperty("message_body", Required = Required.Always)]
        public string? messageBody { get; set; }

        [JsonProperty("login_user_details")]
        public LoginUserDetails loginUserDetails { get; set; }
    }
}
