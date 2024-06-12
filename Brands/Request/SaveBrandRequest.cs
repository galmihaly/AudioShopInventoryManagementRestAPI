using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace DemoRestAPI.Brands.Request
{
    public class SaveBrandRequest
    {
        [JsonProperty("brand_id", Required = Required.Always)]
        public string? BrandId { get; set; }

        [JsonProperty("name", Required = Required.Always)]
        public string? Name { get; set; }

        [JsonProperty("owner", Required = Required.Always)]
        public string? Owner { get; set; }
    }
}
