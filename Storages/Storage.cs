using DemoRestAPI.Products;
using DemoRestAPI.Warehouses;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoRestAPI.Storages
{
    public class Storage
    {
        [Key]
        public int Id { get; set; }

        public string? StorageId { get; set; }

        //Many To One Relation
        [ForeignKey("Warehouse")]
        public int? WareHouseId { get; set; }
        public Warehouse? Warehouse { get; set; }

        public int? Quantity { get; set; }

        public int? MaxQuantity { get; set; }

        public int? NettoValue { get; set;}

        public int? BruttoValue { get; set;}

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}")]
        public DateTime CreatedAt { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}")]
        public DateTime ModifiedAt { get; set; }

        /* One To Many Relation */
        public List<Product> Products { get; set; }
    }
}
