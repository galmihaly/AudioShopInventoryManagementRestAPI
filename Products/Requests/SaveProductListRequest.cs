using DemoRestAPI.Products.Responses;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace DemoRestAPI.Products.Requests
{
    public class SaveProductListRequest
    {
        
        [JsonProperty("username", Required = Required.Always)]
        public string? userName { get; set; }

        
        [JsonProperty("device_id", Required = Required.Always)]
        public string? deviceId { get; set; }

        
        [JsonProperty("products", Required = Required.Always)]
        public List<SaveProductRequest>? productList { get; set; }
    }
}
