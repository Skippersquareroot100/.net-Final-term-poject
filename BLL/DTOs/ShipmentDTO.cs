using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class ShipmentDTO
    {
        public int ShipmentId { get; set; }
        public int OriginWarehouseId { get; set; }
        public int DestinationWarehouseId { get; set; }
        public DateTime ShipmentDate { get; set; }
        public DateTime EstimatedArrival { get; set; }
        public string Status { get; set; }
        public string TrackingNumber { get; set; }
    }
}
