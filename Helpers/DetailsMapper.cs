using DemoRestAPI.Brands;
using DemoRestAPI.Categories;
using DemoRestAPI.Devices;
using DemoRestAPI.Products.Responses;
using DemoRestAPI.Products;
using DemoRestAPI.Users;
using DemoRestAPI.Warehouses;
using System.Text;
using DemoRestAPI.Models;
using DemoRestAPI.Storages;
using DemoRestAPI.Brands.Response;
using DemoRestAPI.Categories.Response;
using DemoRestAPI.Models.Response;
using DemoRestAPI.Warehouses.Response;
using DemoRestAPI.Storages.Responses;

namespace DemoRestAPI.Helpers
{
    public static class DetailsMapper
    {
        public static ProductDetails MappingToProductDetailsObject(Product p, Brand b, Category c, Model m, User u, Device d, Warehouse w, Storage s)
        {
            if (p == null) return null;
            if (b == null) return null;
            if (c == null) return null;
            if (m == null) return null;
            if (u == null) return null;
            if (d == null) return null;
            if (w == null) return null;
            if (s == null) return null;
            
            return new ProductDetails
            {
                Barcode = p.Barcode,
                ProductId = p.ProductId,
                ProductName = b.Name + " " + m.Name,
                ProductType = c.Name,
                BasePrice = p.BasePrice,
                WholeSalePrice = p.WholeSalePrice,
                WarehouseId = w.WareHouseId,
                StorageId = s.StorageId,
                DeviceId = d.DeviceId,
                RecorderName = u.Name,
                RecordingDate = p.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss"),
            };
        }

        public static BrandDetails MappingToBrandDetailsObject(Brand b)
        {
            if (b == null) return null;

            return new BrandDetails
            {
                BrandId = b.BrandId,
                BrandName = b.Name,
            };
        }

        public static CategoryDetails MappingToCategoryDetailsObject(Category c)
        {
            if (c == null) return null;

            return new CategoryDetails
            {
                CategoryId = c.CategoryId,
                CategoryName = c.Name,
            };
        }

        public static ModelDetails MappingToModelDetailsObject(Model m)
        {
            if (m == null) return null;

            return new ModelDetails
            {
                ModelId = m.ModelId,
                ModelName = m.Name,
            };
        }

        public static WarehouseDetails MappingToWarehouseDetailsObject(Warehouse w)
        {
            if (w == null) return null;

            return new WarehouseDetails
            {
                WareHouseId = w.WareHouseId,
                Name = w.Name,
                Address = w.Address,
                CurrentStockCapacity = w.CurrentStockCapacity,
                StockMaxCapacity = w.StockMaxCapacity,
            };
        }

        public static StorageDetails MappingToStorageDetailsObject(Storage s)
        {
            if (s == null) return null;

            return new StorageDetails
            {
                Id = s.Id,
                StorageId = s.StorageId,
                WarehouseId = s.WareHouseId,
                Quantity = s.Quantity,
                MaxQuantity = s.MaxQuantity
            };
        }
    }
}
