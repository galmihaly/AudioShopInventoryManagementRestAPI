using Microsoft.EntityFrameworkCore;

namespace DemoRestAPI.Storages.Repository
{
    public class StorageRepository : IStorageRepository
    {
        private readonly SqlDBContext _context;

        public StorageRepository(SqlDBContext context)
        {
            _context = context;
        }

        public async Task<Storage> Add(Storage entity)
        {
            var savedStorage = await _context.Storages
                .FirstOrDefaultAsync(s => s.StorageId == entity.StorageId);

            if (savedStorage != null)
            {
                return null;
            }

            await _context.Storages.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<Storage> AsyncSearchById(string? storageId, int? warehouseId)
        {
            var storage = await _context.Storages
                .FirstOrDefaultAsync(
                    s => s.StorageId == storageId && s.WareHouseId == warehouseId);

            if (storage == null) { return null; }
            return storage;
        }

        public async Task<bool> IncrementQuantity(string? storageId)
        {
            //Id alapján megkeressük az Storage-t az adatbázisban.
            var searchedStorage = await _context.Storages
                .FirstOrDefaultAsync(u => u.StorageId == storageId);

            //Ha nem találtuk meg, akkor false értékkel visszatérünk
            if (searchedStorage == null) { return false; }

            //Kivesszük a jelenlegi (meg nem növelt) quantity értéket
            var oldQuantity = searchedStorage.Quantity;

            //Növeljük a quantity értéket, majd mentjük a változott értéket az adatbázisba
            searchedStorage.Quantity += 1;
            searchedStorage.ModifiedAt = DateTime.Now;
            await _context.SaveChangesAsync();

            //Kivesszük az megnövelt quantity értéket
            var incrementedQuantity = searchedStorage.Quantity;

            //Megvizsgáljuk, hogy sikeres volt az növelés vagy sem
            // Ha NEM, akkor false-sal térünk vissza
            // Ha IGEN, akkor pedig true-val
            if (oldQuantity == incrementedQuantity) return false;
            return true;
        }

        public async Task<bool> DecrementQuantity(string? storageId)
        {
            //Id alapján megkeressük az Storage-t az adatbázisban.
            var searchedStorage = await _context.Storages
                .FirstOrDefaultAsync(u => u.StorageId == storageId);

            //Ha nem találtuk meg, akkor false értékkel visszatérünk
            if (searchedStorage == null) { return false; }

            //Kivesszük a jelenlegi (le nem csökkentett) quantity értéket
            var oldQuantity = searchedStorage.Quantity;

            //Csökkentjük a quantity értéket, majd mentjük a változott értéket az adatbázisba
            searchedStorage.Quantity -= 1;
            searchedStorage.ModifiedAt = DateTime.Now;
            await _context.SaveChangesAsync();

            //Kivesszük az lecsökkentett quantity értéket
            var incrementedQuantity = searchedStorage.Quantity;

            //Megvizsgáljuk, hogy sikeres volt az csökkentés vagy sem
            // Ha NEM, akkor false-sal térünk vissza
            // Ha IGEN, akkor pedig true-val
            if (oldQuantity == incrementedQuantity) return false;
            return true;
        }

        public async Task<Storage> SearchById(int? storageId, int? warehouseId)
        {
            var storage = await _context.Storages
                .FirstOrDefaultAsync(
                    s => s.Id == storageId && s.WareHouseId == warehouseId);

            if (storage == null) { return null; }
            return storage;
        }

        public async Task<Storage> SearchByStorageId(string? storageId)
        {
            var storage = await _context.Storages
                .FirstOrDefaultAsync(s => s.StorageId == storageId);

            if (storage == null) { return null; }
            return storage;
        }

        public async Task<List<Storage>> GetStoragesByWarehouseId(int? warehouseId)
        {
            List<Storage> storageList = await _context.Storages.ToListAsync();
            List<Storage> searchedStorageList = new List<Storage>();

            if (storageList != null) 
            {
                foreach (var storage in storageList)
                {
                    if (storage.WareHouseId == warehouseId)
                    {
                        searchedStorageList.Add(storage);
                    }
                }
            }

            if (storageList == null || searchedStorageList == null || searchedStorageList.Count == 0) { return null; }
            return searchedStorageList;
        }

        public async Task<bool> IncrementStorageValues(string? storageId, int? basePrice, int? wholeSalePrice)
        {
            //Id alapján megkeressük az Storage-t az adatbázisban.
            var searchedStorage = await _context.Storages
                .FirstOrDefaultAsync(u => u.StorageId == storageId);

            //Ha nem találtuk meg, akkor false értékkel visszatérünk
            if (searchedStorage == null) return false;

            //Ha a basePrice és WholePrice egyenlő 0-val (tehát a két ár 0) vagy ha mindkét szám kisebb mint 0, akkor szintén visszatérünk, nem dolgozunk 0 összeggel
            if (basePrice <= 0) return false;
            if (wholeSalePrice <= 0) return false;

            //Kivesszük a jelenlegi (meg nem növelt) StorageNettoValue értéket
            var oldNettoValue = searchedStorage.NettoValue;

            //Kivesszük a jelenlegi (meg nem növelt) StorageBruttoValue értéket
            var oldBruttoValue = searchedStorage.BruttoValue;

            //Növeljük a StorageNettoValue értéket, majd mentjük a változott értéket az adatbázisba
            searchedStorage.NettoValue += basePrice;

            //Növeljük a StorageBruttoValue értéket, majd mentjük a változott értéket az adatbázisba
            searchedStorage.BruttoValue += wholeSalePrice;

            searchedStorage.ModifiedAt = DateTime.Now;
            await _context.SaveChangesAsync();

            //Kivesszük a megnövelt StorageNettoValue és StorageBruttoValue értékeket
            var incrementedStorageNettoValue = searchedStorage.NettoValue;
            var incrementedStorageBruttoValue = searchedStorage.BruttoValue;

            //Megvizsgáljuk, hogy sikeres volt az növelés vagy sem
            // Ha NEM, akkor false-sal térünk vissza
            // Ha IGEN, akkor pedig true-val
            if (oldNettoValue == incrementedStorageNettoValue) return false;
            if (oldBruttoValue == incrementedStorageBruttoValue) return false;

            Console.WriteLine("Ok");
            
            return true;
        }

        public async Task<bool> DecrementStorageValues(string? storageId, int basePrice, int wholeSalePrice)
        {
            //Id alapján megkeressük az Storage-t az adatbázisban.
            var searchedStorage = await _context.Storages
                .FirstOrDefaultAsync(u => u.StorageId == storageId);

            //Ha nem találtuk meg, akkor false értékkel visszatérünk
            if (searchedStorage == null) { return false; }

            //Ha a basePrice és WholePrice egyenlő 0-val (tehát a két ár 0) vagy ha mindkét szám kisebb mint 0, akkor szintén visszatérünk, nem dolgozunk 0 összeggel
            if (basePrice <= 0) return false;
            if (wholeSalePrice <= 0) return false;

            //Kivesszük a jelenlegi (le nem csökkentett) StorageNettoValue értéket
            var oldNettoValue = searchedStorage.NettoValue;

            //Kivesszük a jelenlegi (le nem csökkentett) StorageBruttoValue értéket
            var oldBruttoValue = searchedStorage.BruttoValue;

            //Csökentjük a StorageNettoValue értéket, majd mentjük a változott értéket az adatbázisba
            searchedStorage.NettoValue -= basePrice;

            //Csökentjük a StorageBruttoValue értéket, majd mentjük a változott értéket az adatbázisba
            searchedStorage.BruttoValue -= wholeSalePrice;

            searchedStorage.ModifiedAt = DateTime.Now;
            await _context.SaveChangesAsync();

            //Kivesszük a lecsökentett StorageNettoValue és StorageBruttoValue értékeket
            var incrementedStorageNettoValue = searchedStorage.NettoValue;
            var incrementedStorageBruttoValue = searchedStorage.BruttoValue;

            //Megvizsgáljuk, hogy sikeres volt az csökkentés vagy sem
            // Ha NEM, akkor false-sal térünk vissza
            // Ha IGEN, akkor pedig true-val
            if (oldNettoValue == incrementedStorageNettoValue) return false;
            if (oldBruttoValue == incrementedStorageBruttoValue) return false;
            return true;
        }
    }
}
