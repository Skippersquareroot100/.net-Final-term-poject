using System;
using System.Collections.Generic;

namespace BLL.DTOs
{
    public class NotificationDTO
    {
        public int NotificationId { get; set; }
        public int WarehouseId { get; set; }
        public string Message { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Type { get; set; }
    }
}