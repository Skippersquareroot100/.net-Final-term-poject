using BLL.DTOs;
using DAL;

using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    public class WarehouseService
    {
        public static List<WarehouseDTO> Get()
        {
            var data = DataAccessFactory.WarehouseDataAccess().Get();
            var list = new List<WarehouseDTO>();
            foreach (var item in data)
            {
                list.Add(new WarehouseDTO()
                {
                    WarehouseId = item.WarehouseId,
                    Name = item.Name,
                    Location = item.Location,
                    Capacity = item.Capacity
                });
            }
            return list;
        }

        public static WarehouseDTO Get(int id)
        {
            var item = DataAccessFactory.WarehouseDataAccess().Get(id);
            if (item == null) return null;
            return new WarehouseDTO()
            {
                WarehouseId = item.WarehouseId,
                Name = item.Name,
                Location = item.Location,
                Capacity = item.Capacity
            };
        }

        public static WarehouseDTO Add(WarehouseDTO dto)
        {
            var obj = new Warehouse()
            {
                Name = dto.Name,
                Location = dto.Location,
                Capacity = dto.Capacity
            };
            var data = DataAccessFactory.WarehouseDataAccess().Add(obj);
            if (data == null) return null;
            return new WarehouseDTO()
            {
                WarehouseId = data.WarehouseId,
                Name = data.Name,
                Location = data.Location,
                Capacity = data.Capacity
            };
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.WarehouseDataAccess().Delete(id);
        }

       

        
        public static List<WarehouseUtilizationDTO> GetUtilizationReport()
        {
            var warehouses = DataAccessFactory.WarehouseDataAccess().Get();
            var result = new List<WarehouseUtilizationDTO>();
            var inventoryData = DataAccessFactory.InventoryDataAccess().Get();

            foreach (var wh in warehouses)
            {
                var totalStock = inventoryData
                    .Where(i => i.WarehouseId == wh.WarehouseId)
                    .Sum(i => i.Quantity);

                result.Add(new WarehouseUtilizationDTO
                {
                    WarehouseId = wh.WarehouseId,
                    Name = wh.Name,
                    Capacity = wh.Capacity,
                    CurrentStock = totalStock,
                    UtilizationPercentage = (decimal)totalStock / wh.Capacity * 100
                });
            }
            return result;
        }
    }

    public class WarehouseUtilizationDTO
    {
        public int WarehouseId { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int CurrentStock { get; set; }
        public decimal UtilizationPercentage { get; set; }
    }
}