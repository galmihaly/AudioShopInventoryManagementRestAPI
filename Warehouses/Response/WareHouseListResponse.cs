using DemoRestAPI.Products.Responses;
using Newtonsoft.Json;

namespace DemoRestAPI.Warehouses.Response
{
    public class WareHouseListResponse
    {
        [JsonProperty("timestamp", Required = Required.Always)]
        public DateTime? timestamp { get; set; }

        [JsonProperty("status_code", Required = Required.Always)]
        public int? httpStatusCode { get; set; }

        [JsonProperty("message_type", Required = Required.Always)]
        public String? messageType { get; set; }

        [JsonProperty("message_body", Required = Required.Always)]
        public String? messageBody { get; set; }

        [JsonProperty("warehouses")]
        public List<WarehouseDetails> warehouseDetails { get; set; }
    }
}
