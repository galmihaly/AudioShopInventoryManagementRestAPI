using DemoRestAPI.Devices;
using DemoRestAPI.Helpers;
using DemoRestAPI.Products;
using DemoRestAPI.Warehouses;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DemoRestAPI.Users
{
    public class User : IdentityUser
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [Required]
        [JsonPropertyName("address")]
        public string? Address { get; set; }

        [Required]
        [JsonPropertyName("right")]
        public string? Right { get; set; }

        [JsonPropertyName("refreshtoken")]
        public string? RefreshToken { get; set; }

        [JsonPropertyName("refreshtoken_expiration")]
        [JsonConverter(typeof(DateConverter))]
        public DateTime RefreshTokenExpiration { get; set; }

        [Required]
        [JsonPropertyName("active")]
        public bool? Active { get; set; }

        //One To One Relation
        [ForeignKey("Device")]
        public int? DeviceId { get; set; }
        public Device? Device { get; set; }

        //Many To One Relation
        [ForeignKey("Warehouse")]
        public int? WareHouseId { get; set; }
        public Warehouse? WareHouse { get; set; }

        [Required]
        [JsonPropertyName("created_at")]
        [JsonConverter(typeof(DateConverter))]
        public DateTime CreatedAt { get; set; }

        [Required]
        [JsonPropertyName("modified_at")]
        [JsonConverter(typeof(DateConverter))]
        public DateTime ModifiedAt { get; set; }

        /* One To Many Relation */
        public List<Product> Products { get; set; }
    }
}
