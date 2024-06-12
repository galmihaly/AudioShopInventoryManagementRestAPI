using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DemoRestAPI.Brands.Response
{
    public class BrandDetails
    {
        [Required]
        [JsonProperty("brand_id")]
        public String? BrandId { get; set; }

        [Required]
        [JsonProperty("name")]
        public String? BrandName { get; set; }
    }
}
