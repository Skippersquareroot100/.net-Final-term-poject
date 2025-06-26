using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

public class Location
{
    [Key]
    public int LocationId { get; set; }

    public int WarehouseId { get; set; }

    [ForeignKey("WarehouseId")]
    public virtual Warehouse Warehouse { get; set; }

    [Column(TypeName = "VARCHAR"), StringLength(10)]
    public string Aisle { get; set; }

    [Column(TypeName = "VARCHAR"), StringLength(10)]
    public string Rack { get; set; }

    [Column(TypeName = "VARCHAR"), StringLength(10)]
    public string Bin { get; set; }

    public virtual ICollection<Inventory> Inventories { get; set; }
}
