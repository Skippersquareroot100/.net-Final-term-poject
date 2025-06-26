using BLL.DTOs;
using DAL;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    public class ShipmentService
    {
        public static List<ShipmentDTO> Get()
        {
            var data = DataAccessFactory.ShipmentDataAccess().Get();
            return data.Select(s => new ShipmentDTO
            {
                ShipmentId = s.ShipmentId,
                OriginWarehouseId = s.OriginWarehouseId,
                DestinationWarehouseId = s.DestinationWarehouseId,
                ShipmentDate = s.ShipmentDate,
                Status = s.Status
            }).ToList();
        }

        public static ShipmentDTO Get(int id)
        {
            var item = DataAccessFactory.ShipmentDataAccess().Get(id);
            if (item == null) return null;
            return new ShipmentDTO
            {
                ShipmentId = item.ShipmentId,
                OriginWarehouseId = item.OriginWarehouseId,
                DestinationWarehouseId = item.DestinationWarehouseId,
                ShipmentDate = item.ShipmentDate,
               
                Status = item.Status
       
            };
        }

        public static ShipmentDTO Add(ShipmentDTO dto)
        {
            var obj = new Shipment
            {
                OriginWarehouseId = dto.OriginWarehouseId,
                DestinationWarehouseId = dto.DestinationWarehouseId,
                ShipmentDate = dto.ShipmentDate,
       
                Status = dto.Status
           
            };
            var data = DataAccessFactory.ShipmentDataAccess().Add(obj);
            if (data == null) return null;
            return new ShipmentDTO
            {
                ShipmentId = data.ShipmentId,
                OriginWarehouseId = data.OriginWarehouseId,
                DestinationWarehouseId = data.DestinationWarehouseId,
                ShipmentDate = data.ShipmentDate,
          
                Status = data.Status,
               
            };
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.ShipmentDataAccess().Delete(id);
        }

        public static List<ShipmentDTO> TrackByStatus(string status)
        {
            var data = DataAccessFactory.ShipmentTrackingDataAccess().GetByStatus(status);
            return data.Select(s => new ShipmentDTO
            {
                ShipmentId = s.ShipmentId,
                Status = s.Status,
               
                DestinationWarehouseId = s.DestinationWarehouseId
            }).ToList();
        }
    }
}