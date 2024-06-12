using DemoRestAPI.Brands;
using DemoRestAPI.Categories;
using DemoRestAPI.Devices;
using DemoRestAPI.Models;
using DemoRestAPI.Products.Responses;
using DemoRestAPI.Storages;
using DemoRestAPI.Users;
using DemoRestAPI.Warehouses;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoRestAPI.Products
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        public string ProductId { get; set; }

        /* Many To One Relation */
        [ForeignKey("Brand")]
        public int? BrandId { get; set; }
        public Brand? Brand { get; set; }

        /* Many To One Relation */
        [ForeignKey("Category")]
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

        /* Many To One Relation */
        [ForeignKey("Model")]
        public int? ModelId { get; set; }
        public Model? Model { get; set; }

        /* Many To One Relation */
        [ForeignKey("User")]
        public int? UserId { get; set; }
        public User? User { get; set; }

        /* Many To One Relation */
        [ForeignKey("Storage")]
        public int? StorageId { get; set; }
        public Storage? Storage { get; set; }

        public int BasePrice { get; set; }

        public int WholeSalePrice { get; set; }

        public string Barcode { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}")]
        public DateTime CreatedAt { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}")]
        public DateTime ModifiedAt { get; set; }
    }
}
