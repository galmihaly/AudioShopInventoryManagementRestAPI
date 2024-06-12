using DemoRestAPI.Storages;
using DemoRestAPI.Users;
using System.ComponentModel.DataAnnotations;

namespace DemoRestAPI.Warehouses
{
    public class Warehouse
    {
        [Key]
        public int Id { get; set; }

        public string? WareHouseId { get; set; }

        public string? Name { get; set; }

        public string? Address { get; set; }

        public int? CurrentStockCapacity { get; set; }

        public int? StockMaxCapacity { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{yyyy-MM-dd HH:mm:ss}")]
        public DateTime CreatedAt { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{yyyy-MM-dd HH:mm:ss}")]
        public DateTime ModifiedAt { get; set; }

        /* One To Many Relation */
        public List<User> Users { get; set; }

        /* One To Many Relation */
        public List<Storage> Storages { get; set; }
    }
}
