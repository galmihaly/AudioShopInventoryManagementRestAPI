using DemoRestAPI.Helpers;
using DemoRestAPI.Products.Responses;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace DemoRestAPI.Brands.Response
{
    public class BrandListResponse
    {
        [JsonProperty("timestamp", Required = Required.Always)]
        public DateTime? timestamp { get; set; }

        [JsonProperty("status_code", Required = Required.Always)]
        public int? httpStatusCode { get; set; }

        [JsonProperty("message_type", Required = Required.Always)]
        public String? messageType { get; set; }

        [JsonProperty("message_body", Required = Required.Always)]
        public String? messageBody { get; set; }

        [JsonProperty("brands", Required = Required.Always)]
        public List<BrandDetails>? brandDetails { get; set; }
    }
}
