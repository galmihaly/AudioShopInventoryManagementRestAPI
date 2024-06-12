using DemoRestAPI.Products.Responses;
using Newtonsoft.Json;

namespace DemoRestAPI.Storages.Responses
{
    public class StorageListResponse
    {
        [JsonProperty("timestamp", Required = Required.Always)]
        public DateTime? timestamp { get; set; }

        [JsonProperty("status_code", Required = Required.Always)]
        public int? httpStatusCode { get; set; }

        [JsonProperty("message_type", Required = Required.Always)]
        public String? messageType { get; set; }

        [JsonProperty("message_body", Required = Required.Always)]
        public String? messageBody { get; set; }

        [JsonProperty("storages")]
        public List<StorageDetails> storageDetailsList { get; set; }
    }
}
