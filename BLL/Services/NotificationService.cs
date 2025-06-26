using BLL.DTOs;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    public class NotificationService
    {
        // Feature 1: Get all notifications
        public static List<NotificationDTO> Get()
        {
            var data = DataAccessFactory.NotificationDataAccess().Get();
            var list = new List<NotificationDTO>();
            foreach (var item in data)
            {
                list.Add(new NotificationDTO()
                {
                    NotificationId = item.NotificationId,
                    WarehouseId = item.WarehouseId,
                    Message = item.Message,
                    CreatedAt = item.CreatedAt,
                    Type = item.Type
                });
            }
            return list;
        }

        // Feature 2: Get single notification by ID
        public static NotificationDTO Get(int id)
        {
            var item = DataAccessFactory.NotificationDataAccess().Get(id);
            if (item == null) return null;
            return new NotificationDTO()
            {
                NotificationId = item.NotificationId,
                WarehouseId = item.WarehouseId,
                Message = item.Message,
                CreatedAt = item.CreatedAt,
                Type = item.Type
            };
        }

     

        // Feature 4: Delete notification
        public static bool Delete(int id)
        {
            return DataAccessFactory.NotificationDataAccess().Delete(id);
        }

        // Feature 5: Get notifications by warehouse
        public static List<NotificationDTO> GetByWarehouse(int warehouseId)
        {
            var data = DataAccessFactory.NotificationDataAccess().Get()
                .Where(n => n.WarehouseId == warehouseId);
            var list = new List<NotificationDTO>();
            foreach (var item in data)
            {
                list.Add(new NotificationDTO()
                {
                    NotificationId = item.NotificationId,
                    WarehouseId = item.WarehouseId,
                    Message = item.Message,
                    CreatedAt = item.CreatedAt,
                    Type = item.Type
                });
            }
            return list;
        }

        // Feature 6: Get recent notifications (last 7 days)
        public static List<NotificationDTO> GetRecent()
        {
            var cutoffDate = DateTime.Now.AddDays(-7);
            var data = DataAccessFactory.NotificationDataAccess().Get()
                .Where(n => n.CreatedAt >= cutoffDate);
            var list = new List<NotificationDTO>();
            foreach (var item in data)
            {
                list.Add(new NotificationDTO()
                {
                    NotificationId = item.NotificationId,
                    WarehouseId = item.WarehouseId,
                    Message = item.Message,
                    CreatedAt = item.CreatedAt,
                    Type = item.Type
                });
            }
            return list;
        }
    }
}