using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace DemoRestAPI.Warehouses.Response
{
    public class WarehouseDetails
    {
        [JsonProperty("warehouse_id", Required = Required.Always)]
        public string? WareHouseId { get; set; }

        [JsonProperty("name", Required = Required.Always)]
        public string? Name { get; set; }

        [JsonProperty("address", Required = Required.Always)]
        public string? Address { get; set; }

        [JsonProperty("current_stock_capacity", Required = Required.Always)]
        public int? CurrentStockCapacity { get; set; }

        [JsonProperty("stock_max_capacity", Required = Required.Always)]
        public int? StockMaxCapacity { get; set; }

        [JsonProperty("netto_value", Required = Required.Always)]
        public int? NettoValue { get; set; }

        [JsonProperty("brutto_value", Required = Required.Always)]
        public int? BruttoValue { get; set; }
    }
}
