using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DemoRestAPI.Models.Response
{
    public class ModelDetails
    {
        [JsonProperty("model_id", Required = Required.Always)]
        public String? ModelId { get; set; }

        [JsonProperty("name", Required = Required.Always)]
        public string? ModelName { get; set; }
    }
}
