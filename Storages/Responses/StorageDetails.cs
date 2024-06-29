using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace DemoRestAPI.Storages.Responses
{
    public class StorageDetails
    {
        [JsonProperty("id", Required = Required.Always)]
        public int? Id { get; set; }

        [JsonProperty("storage_id", Required = Required.Always)]
        public string? StorageId { get; set; }

        [JsonProperty("warehouse_id", Required = Required.Always)]
        public int? WarehouseId { get; set; }

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
