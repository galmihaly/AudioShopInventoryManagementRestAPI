using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace DemoRestAPI.Products.Requests
{
    public class GetProductsRequest
    {
        [JsonProperty("page_index", Required = Required.Always)]
        public int? PageIndex { get; set; }

        [Required]
        [JsonProperty("page_size", Required = Required.Always)]
        public int? PageSize { get; set; }
    }
}
