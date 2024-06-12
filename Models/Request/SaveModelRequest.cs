using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace DemoRestAPI.Models.Request
{
    public class SaveModelRequest
    {
        [JsonProperty("model_id", Required = Required.Always)]
        public string ModelId { get; set; }

        [JsonProperty("name", Required = Required.Always)]
        public string Name { get; set; }
    }
}
