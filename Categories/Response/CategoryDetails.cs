using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DemoRestAPI.Categories.Response
{
    public class CategoryDetails
    {
        [Required]
        [JsonProperty("category_id")]
        public String? CategoryId { get; set; }

        [Required]
        [JsonProperty("name")]
        public string? CategoryName { get; set; }
    }
}
