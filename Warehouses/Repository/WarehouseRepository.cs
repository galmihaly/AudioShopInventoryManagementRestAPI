using DemoRestAPI.Products;
using Microsoft.EntityFrameworkCore;

namespace DemoRestAPI.Warehouses.Repository
{
    public class WarehouseRepository : IWarehouseRepository
    {
        private readonly SqlDBContext _context;

        public WarehouseRepository(SqlDBContext context)
        {
            _context = context;
        }

        public async Task<Warehouse> Add(Warehouse entity)
        {
            var savedWarehouse = await _context.Warehouses
                .FirstOrDefaultAsync(w => w.WareHouseId == entity.WareHouseId || w.Name == entity.Name);

            if (savedWarehouse != null)
            {
                return null;
            }

            await _context.Warehouses.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<Warehouse> AsyncSearchById(int? id)
        {
            var warehouse = await _context.Warehouses
                .FirstOrDefaultAsync(w => w.Id == id);

            if (warehouse == null) { return null; }
            return warehouse;
        }

        public async Task<Warehouse> SearchByWarehouseId(string? warehouseId)
        {
            var warehouse = await _context.Warehouses
                .FirstOrDefaultAsync(w => w.WareHouseId == warehouseId);

            if (warehouse == null) { return null; }
            return warehouse;
        }

        public async Task<bool> IncrementCurrentStockCapacity(string? warehouseId)
        {
            //Id alapján megkeressük az Storage-t az adatbázisban.
            var searchedWarehouse = await _context.Warehouses
                .FirstOrDefaultAsync(u => u.WareHouseId == warehouseId);

            //Ha nem találtuk meg, akkor false értékkel visszatérünk
            if (searchedWarehouse == null) { return false; }

            //Kivesszük a jelenlegi (meg nem növelt) quantity értéket
            var oldCapacity = searchedWarehouse.CurrentStockCapacity;

            //Növeljük a quantity értéket, majd mentjük a változott értéket az adatbázisba
            searchedWarehouse.CurrentStockCapacity += 1;
            searchedWarehouse.ModifiedAt = DateTime.Now;
            await _context.SaveChangesAsync();

            //Kivesszük az megnövelt quantity értéket
            var incrementedCapacity = searchedWarehouse.CurrentStockCapacity;

            //Megvizsgáljuk, hogy sikeres volt az növelés vagy sem
            // Ha NEM, akkor false-sal térünk vissza
            // Ha IGEN, akkor pedig true-val
            if (oldCapacity == incrementedCapacity) return false;
            return true;
        }

        public async Task<Warehouse> SearchById(int? warehouseId)
        {
            var user = await _context.Warehouses
                .FirstOrDefaultAsync(u => u.Id == warehouseId);

            if (user == null) { return null; }
            return user;
        }

        public async Task<List<Warehouse>> GetWarehouses()
        {
            List<Warehouse> warehouseList = await _context.Warehouses.ToListAsync();

            if (warehouseList == null || warehouseList.Count == 0) { return null; }
            return warehouseList;
        }
    }
}
