using DemoRestAPI.Categories.Response;
using DemoRestAPI.Helpers;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DemoRestAPI.Models.Response
{
    public class ModelListResponse
    { 
        [JsonProperty("timestamp", Required = Required.Always)]
        public DateTime? timestamp { get; set; }

        [JsonProperty("status_code", Required = Required.Always)]
        public int? httpStatusCode { get; set; }

        [JsonProperty("message_type", Required = Required.Always)]
        public string? messageType { get; set; }

        [JsonProperty("message_body", Required = Required.Always)]
        public string? messageBody { get; set; }

        [JsonProperty("models", Required = Required.Always)]
        public List<ModelDetails>? modelDetails { get; set; }
    }
}
