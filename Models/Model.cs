using DemoRestAPI.Products;
using System.ComponentModel.DataAnnotations;

namespace DemoRestAPI.Models
{
    public class Model
    {
        [Key]
        public int Id { get; set; }

        public string? ModelId { get; set; }

        public string? Name { get; set; }

        /* One To Many Relation */
        public List<Product> Products { get; set; }
    }
}
