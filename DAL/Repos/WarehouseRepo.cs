using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repos
{
    internal class WarehouseRepo : Repo, IRepo<Warehouse, int, Warehouse>, IWarehouseUtilization<Warehouse, int>
    {
        public Warehouse Add(Warehouse obj)
        {
            db.Warehouses.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var dbobj = Get(id);
            db.Warehouses.Remove(dbobj);
            return db.SaveChanges() > 0;
        }

        public List<Warehouse> Get()
        {
            return db.Warehouses.ToList();
        }

        public Warehouse Get(int id)
        {
            return db.Warehouses.Find(id);
        }

        public Warehouse Update(Warehouse obj)
        {
            var dbobj = Get(obj.WarehouseId);
            db.Entry(dbobj).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public List<Warehouse> GetUtilizationReport()
        {
            return db.Warehouses.ToList();
        }

        public Warehouse GetWarehouseUtilization(int warehouseId)
        {
            return db.Warehouses.Find(warehouseId);
        }
    }
}