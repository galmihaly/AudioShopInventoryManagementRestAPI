using DemoRestAPI.Brands;
using DemoRestAPI.Categories;
using DemoRestAPI.Devices;
using DemoRestAPI.Models;
using DemoRestAPI.Products;
using DemoRestAPI.Storages;
using DemoRestAPI.Users;
using DemoRestAPI.Warehouses;
using Microsoft.EntityFrameworkCore;

namespace DemoRestAPI
{
    public class SqlDBContext : DbContext
    {
        public SqlDBContext(DbContextOptions<SqlDBContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<Storage> Storages { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
    }
}
