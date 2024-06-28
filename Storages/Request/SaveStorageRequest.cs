using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DemoRestAPI.Storages.Request
{
    public class SaveStorageRequest
    {
        [JsonProperty("storage_id", Required = Required.Always)]
        public string? StorageId { get; set; }

        [JsonProperty("warehouse_id", Required = Required.Always)]
        public string? WareHouseId { get; set; }

        [JsonProperty("quantity", Required = Required.Always)]
        public int? Quantity { get; set; }

        [JsonProperty("max_quantity", Required = Required.Always)]
        public int? MaxQuantity { get; set; }

        [JsonProperty("netto_value", Required = Required.Always)]
        public int? NettoValue { get; set; }

        [JsonProperty("brutto_value", Required = Required.Always)]
        public int? BruttoValue { get; set; }
    }
}
