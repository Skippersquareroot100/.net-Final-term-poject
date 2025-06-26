using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Inventory
{
    [Key]
    public int InventoryId { get; set; }

    public int ProductId { get; set; }

    [ForeignKey("ProductId")]
    public virtual Product Product { get; set; }

    public int WarehouseId { get; set; }

    [ForeignKey("WarehouseId")]
    public virtual Warehouse Warehouse { get; set; }

    public int? LocationId { get; set; }

    [ForeignKey("LocationId")]
    public virtual Location Location { get; set; }

    public int Quantity { get; set; }

    public DateTime LastUpdated { get; set; }
}
