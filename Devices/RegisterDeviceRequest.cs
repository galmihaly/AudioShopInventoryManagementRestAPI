using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace DemoRestAPI.Devices
{
    public class RegisterDeviceRequest
    {
        [JsonProperty("device_id", Required = Required.Always)]
        public string? DeviceId { get; set; }

        [JsonProperty("name", Required = Required.Always)]
        public string? Name { get; set; }

        [JsonProperty("type", Required = Required.Always)]
        public string? Type { get; set; }

        [JsonProperty("active", Required = Required.Always)]
        public bool? Active { get; set; }
    }
}
