using System.ComponentModel.DataAnnotations;
using DemoRestAPI.Products;

namespace DemoRestAPI.Categories
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        public string? CategoryId { get; set; }

        public string? Name { get; set; }

        /* One To Many Relation */
        public List<Product> Products { get; set; }
    }
}
