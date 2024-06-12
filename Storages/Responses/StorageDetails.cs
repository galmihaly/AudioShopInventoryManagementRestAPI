using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace DemoRestAPI.Storages.Responses
{
    public class StorageDetails
    {
        [Required]
        [JsonProperty("id")]
        public int? Id { get; set; }

        [Required]
        [JsonProperty("storage_id")]
        public string? StorageId { get; set; }

        [Required]
        [JsonProperty("warehouse_id")]
        public int? WarehouseId { get; set; }

        [Required]
        [JsonProperty("quantity")]
        public int? Quantity { get; set; }

        [Required]
        [JsonProperty("max_quantity")]
        public int? MaxQuantity { get; set; }
    }
}
