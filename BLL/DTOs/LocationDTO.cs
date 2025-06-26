using System;
using System.Collections.Generic;

namespace BLL.DTOs
{
    public class LocationDTO
    {
        public int LocationId { get; set; }
        public int WarehouseId { get; set; }
        public string Aisle { get; set; }
        public string Rack { get; set; }
        public string Bin { get; set; }
    }
}