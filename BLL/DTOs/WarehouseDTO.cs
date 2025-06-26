using System;
using System.Collections.Generic;

namespace BLL.DTOs
{
    public class WarehouseDTO
    {
        public int WarehouseId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int Capacity { get; set; }
        
    }
}