using DemoRestAPI.Products;
using System.ComponentModel.DataAnnotations;

namespace DemoRestAPI.Brands
{
    public class Brand
    {
        [Key]
        public int Id { get; set; }

        public string? BrandId { get; set; }

        public string? Name { get; set; }

        public string Owner { get; set; }

        /* One To Many Relation */
        public List<Product> Products { get; set; }
    }
}
