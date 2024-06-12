using DemoRestAPI.Helpers;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DemoRestAPI.Categories.Response
{
    public class CategoryListResponse
    {
        [JsonProperty("timestamp", Required = Required.Always)]
        public DateTime? timestamp { get; set; }

        [JsonProperty("status_code", Required = Required.Always)]
        public int? httpStatusCode { get; set; }

        [JsonProperty("message_type", Required = Required.Always)]
        public String? messageType { get; set; }

        [JsonProperty("message_body", Required = Required.Always)]
        public String? messageBody { get; set; }

        [JsonProperty("categories", Required = Required.Always)]
        public List<CategoryDetails>? categoryDetails { get; set; }
    }
}
