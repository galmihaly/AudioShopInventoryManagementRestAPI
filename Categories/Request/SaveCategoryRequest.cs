using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DemoRestAPI.Categories.Request
{
    public class SaveCategoryRequest
    {
        [JsonProperty("category_id", Required = Required.Always)]
        public string? CategoryId { get; set; }

        [JsonProperty("name", Required = Required.Always)]
        public string? Name { get; set; }
    }
}
