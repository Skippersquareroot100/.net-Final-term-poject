using BLL.DTOs;
using DAL;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    public class InventoryService
    {
        public static List<InventoryDTO> Get()
        {
            var data = DataAccessFactory.InventoryDataAccess().Get();
            return data.Select(i => new InventoryDTO
            {
                InventoryId = i.InventoryId,
                WarehouseId = i.WarehouseId,
                ProductId = i.ProductId,
                LocationId = i.LocationId,
                Quantity = i.Quantity,
                LastUpdated = i.LastUpdated
            }).ToList();
        }

        public static InventoryDTO Get(int id)
        {
            var item = DataAccessFactory.InventoryDataAccess().Get(id);
            if (item == null) return null;
            return new InventoryDTO
            {
                InventoryId = item.InventoryId,
                WarehouseId = item.WarehouseId,
                ProductId = item.ProductId,
                LocationId = item.LocationId,
                Quantity = item.Quantity,
                LastUpdated = item.LastUpdated
            };
        }

        public static InventoryDTO Add(InventoryDTO dto)
        {
            var obj = new Inventory
            {
                WarehouseId = dto.WarehouseId,
                ProductId = dto.ProductId,
                LocationId = dto.LocationId,
                Quantity = dto.Quantity
            };
            var data = DataAccessFactory.InventoryDataAccess().Add(obj);
            if (data == null) return null;
            return new InventoryDTO
            {
                InventoryId = data.InventoryId,
                WarehouseId = data.WarehouseId,
                ProductId = data.ProductId,
                LocationId = data.LocationId,
                Quantity = data.Quantity,
                LastUpdated = data.LastUpdated
            };
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.InventoryDataAccess().Delete(id);
        }

        public static List<InventoryDTO> Search(string query)
        {
            var data = DataAccessFactory.InventorySearchDataAccess().SearchByProductNameOrSKU(query);
            return data.Select(i => new InventoryDTO
            {
                InventoryId = i.InventoryId,
                ProductId = i.ProductId,
                Quantity = i.Quantity,
                Product = new ProductDTO
                {
                    ProductId = i.Product.ProductId,
                    Name = i.Product.Name,
                    SKU = i.Product.SKU
                }
            }).ToList();
        }
    }
}