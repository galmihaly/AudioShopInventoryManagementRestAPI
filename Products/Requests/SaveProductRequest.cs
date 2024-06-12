using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace DemoRestAPI.Products.Requests
{
    public class SaveProductRequest
    {
        
        [JsonProperty("brand_id", Required = Required.Always)]
        public string? brandId { get; set; }

        [JsonProperty("category_id", Required = Required.Always)]
        public string? categoryId { get; set; }

        [JsonProperty("model_id", Required = Required.Always)]
        public string? modelId { get; set; }

        [JsonProperty("warehouse_id", Required = Required.Always)]
        public string? wareHouseId { get; set; }

        [JsonProperty("storage_id", Required = Required.Always)]
        public string? storageId { get; set; }

        [JsonProperty("base_price", Required = Required.Always)]
        public int basePrice { get; set; }

        [JsonProperty("wholesale_price", Required = Required.Always)]
        public int wholeSalePrice { get; set; }

        [JsonProperty("barcode", Required = Required.Always)]
        public string? barcode { get; set; }
    }
}
