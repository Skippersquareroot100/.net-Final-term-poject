using System;
using System.Collections.Generic;

namespace BLL.DTOs
{
    public class InventoryDTO
    {
        public int InventoryId { get; set; }
        public int ProductId { get; set; }
        public int WarehouseId { get; set; }
        public int? LocationId { get; set; }
        public int Quantity { get; set; }
        public DateTime LastUpdated { get; set; }
        public ProductDTO Product { get; set; }
    }
}