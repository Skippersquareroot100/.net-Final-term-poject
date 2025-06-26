using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repos
{
    internal class ShipmentRepo : Repo, IRepo<Shipment, int, Shipment>, IShipmentTracking<Shipment, int>
    {
        public Shipment Add(Shipment obj)
        {
            db.Shipments.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var dbobj = Get(id);
            db.Shipments.Remove(dbobj);
            return db.SaveChanges() > 0;
        }

        public List<Shipment> Get()
        {
            return db.Shipments.ToList();
        }

        public Shipment Get(int id)
        {
            return db.Shipments.Find(id);
        }

        public Shipment Update(Shipment obj)
        {
            var dbobj = Get(obj.ShipmentId);
            db.Entry(dbobj).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public List<Shipment> GetByStatus(string status)
        {
            return db.Shipments.Where(s => s.Status == status).ToList();
        }

        public List<Shipment> GetByWarehouse(int warehouseId)
        {
            return db.Shipments
                .Where(s => s.OriginWarehouseId == warehouseId ||
                            s.DestinationWarehouseId == warehouseId)
                .ToList();
        }
    }
}