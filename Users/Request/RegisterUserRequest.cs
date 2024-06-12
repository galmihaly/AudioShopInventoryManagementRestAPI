using System.ComponentModel.DataAnnotations;
using DemoRestAPI.Devices;
using Newtonsoft.Json;

namespace DemoRestAPI.Users.Request
{
    public class RegisterUserRequest
    {
        [JsonProperty("name", Required = Required.Always)]
        public string? Name { get; set; }

        [JsonProperty("username", Required = Required.Always)]
        public string? Username { get; set; }

        [JsonProperty("password", Required = Required.Always)]
        public string? Password { get; set; }

        [JsonProperty("email", Required = Required.Always)]
        public string? Email { get; set; }

        [JsonProperty("address", Required = Required.Always)]
        public string? Address { get; set; }

        [JsonProperty("telephone", Required = Required.Always)]
        public string? Telephone { get; set; }

        [JsonProperty("right", Required = Required.Always)]
        public string? Right { get; set; }

        [JsonProperty("warehouse_id", Required = Required.Always)]
        public string? WareHouseId { get; set; }

        [JsonProperty("active", Required = Required.Always)]
        public bool? Active { get; set; }

        [JsonProperty("device", Required = Required.Always)]
        public RegisterDeviceRequest RegisterDeviceRequest { get; set; }
    }
}
