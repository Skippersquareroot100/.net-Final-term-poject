using BLL.DTOs;
using DAL;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    public class LocationService
    {
        
        public static List<LocationDTO> Get()
        {
            var data = DataAccessFactory.LocationDataAccess().Get();
            var list = new List<LocationDTO>();
            foreach (var item in data)
            {
                list.Add(new LocationDTO()
                {
                    LocationId = item.LocationId,
                    WarehouseId = item.WarehouseId,
                    Aisle = item.Aisle,
                    Rack = item.Rack,
                    Bin = item.Bin
                });
            }
            return list;
        }

       
        public static LocationDTO Get(int id)
        {
            var item = DataAccessFactory.LocationDataAccess().Get(id);
            if (item == null) return null;
            return new LocationDTO()
            {
                LocationId = item.LocationId,
                WarehouseId = item.WarehouseId,
                Aisle = item.Aisle,
                Rack = item.Rack,
                Bin = item.Bin
            };
        }

       
        public static LocationDTO Add(LocationDTO dto)
        {
            var obj = new Location()
            {
                WarehouseId = dto.WarehouseId,
                Aisle = dto.Aisle,
                Rack = dto.Rack,
                Bin = dto.Bin
            };
            var data = DataAccessFactory.LocationDataAccess().Add(obj);
            if (data == null) return null;
            return new LocationDTO()
            {
                LocationId = data.LocationId,
                WarehouseId = data.WarehouseId,
                Aisle = data.Aisle,
                Rack = data.Rack,
                Bin = data.Bin
            };
        }

   
        public static bool Delete(int id)
        {
            return DataAccessFactory.LocationDataAccess().Delete(id);
        }

        public static LocationDTO Update(LocationDTO dto)
        {
            var obj = new Location()
            {
                LocationId = dto.LocationId,
                WarehouseId = dto.WarehouseId,
                Aisle = dto.Aisle,
                Rack = dto.Rack,
                Bin = dto.Bin
            };
            var data = DataAccessFactory.LocationDataAccess().Update(obj);
            if (data == null) return null;
            return dto;
        }

       
        public static List<LocationDTO> GetByWarehouse(int warehouseId)
        {
            var data = DataAccessFactory.LocationDataAccess().Get()
                .Where(l => l.WarehouseId == warehouseId);
            var list = new List<LocationDTO>();
            foreach (var item in data)
            {
                list.Add(new LocationDTO()
                {
                    LocationId = item.LocationId,
                    WarehouseId = item.WarehouseId,
                    Aisle = item.Aisle,
                    Rack = item.Rack,
                    Bin = item.Bin
                });
            }
            return list;
        }

        
        public static List<LocationUtilizationDTO> GetUtilizationReport()
        {
            var locations = DataAccessFactory.LocationDataAccess().Get();
            var inventoryData = DataAccessFactory.InventoryDataAccess().Get();
            var result = new List<LocationUtilizationDTO>();

            foreach (var loc in locations)
            {
                var itemsAtLocation = inventoryData
                    .Where(i => i.LocationId == loc.LocationId)
                    .Count();

                result.Add(new LocationUtilizationDTO
                {
                    LocationId = loc.LocationId,
                    AisleRackBin = $"{loc.Aisle}-{loc.Rack}-{loc.Bin}",
                    WarehouseId = loc.WarehouseId,
                    ItemsStored = itemsAtLocation,
                    UtilizationStatus = itemsAtLocation > 0 ? "Active" : "Empty"
                });
            }
            return result;
        }
    }

    public class LocationUtilizationDTO
    {
        public int LocationId { get; set; }
        public string AisleRackBin { get; set; }
        public int WarehouseId { get; set; }
        public int ItemsStored { get; set; }
        public string UtilizationStatus { get; set; }
    }
}