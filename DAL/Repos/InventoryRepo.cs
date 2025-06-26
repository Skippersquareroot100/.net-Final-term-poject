using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repos
{
    internal class InventoryRepo : Repo, IRepo<Inventory, int, Inventory>,
        ISearchInventory<Inventory, bool,int>, ILowStockAlert<Notification, int, bool>
    {
        public Inventory Add(Inventory obj)
        {
            db.Inventories.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var dbobj = Get(id);
            db.Inventories.Remove(dbobj);
            return db.SaveChanges() > 0;
        }

        public List<Inventory> Get()
        {
            return db.Inventories.ToList();
        }

        public Inventory Get(int id)
        {
            return db.Inventories.Find(id);
        }

        public Inventory Update(Inventory obj)
        {
            var dbobj = Get(obj.InventoryId);
            db.Entry(dbobj).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public List<Inventory> SearchByProductNameOrSKU(string query)
        {
            return db.Inventories
                .Where(i => i.Product.Name.Contains(query) || i.Product.SKU.Contains(query))
                .ToList();
        }

        public bool UpdateInventoryLocation(int inventoryId, int locationId)
        {
            var inventory = Get(inventoryId);
            inventory.LocationId = locationId;
            return db.SaveChanges() > 0;
        }

        public List<Notification> CheckStockLevels(int warehouseId, int threshold)
        {
            return db.Inventories
                .Where(i => i.WarehouseId == warehouseId && i.Quantity < threshold)
                .Select(i => new Notification
                {
                    WarehouseId = i.WarehouseId,
                    Message = $"Low stock alert: {i.Product.Name} (SKU: {i.Product.SKU})",
                    Type = "LowStock",
                    CreatedAt = System.DateTime.Now
                })
                .ToList();
        }

        public bool GenerateNotification(int warehouseId, string message)
        {
            db.Notifications.Add(new Notification
            {
                WarehouseId = warehouseId,
                Message = message,
                Type = "LowStock",
                CreatedAt = System.DateTime.Now
            });
            return db.SaveChanges() > 0;
        }
    }
}