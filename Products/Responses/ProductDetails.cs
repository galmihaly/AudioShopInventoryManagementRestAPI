using DemoRestAPI.Helpers;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DemoRestAPI.Products.Responses
{
    public class ProductDetails
    {
        [Required]
        [JsonProperty("barcode")]
        public string? Barcode { get; set; }

        [Required]
        [JsonProperty("product_id")]
        public string? ProductId { get; set; }

        [Required]
        [JsonProperty("product_name")]
        public string? ProductName { get; set; }

        [Required]
        [JsonProperty("product_type")]
        public string? ProductType { get; set; }

        [Required]
        [JsonProperty("base_price")]
        public int? BasePrice { get; set; }

        [Required]
        [JsonProperty("wholesale_price")]
        public int? WholeSalePrice { get; set; }

        [Required]
        [JsonProperty("warehouse_id")]
        public string? WarehouseId { get; set; }

        [Required]
        [JsonProperty("storage_id")]
        public string? StorageId { get; set; }

        [Required]
        [JsonProperty("device_id")]
        public string? DeviceId { get; set; }

        [Required]
        [JsonProperty("recorder_name")]
        public string? RecorderName { get; set; }

        [Required]
        [JsonProperty("recording_date")]
        public string? RecordingDate { get; set; }
    }
}
