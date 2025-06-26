using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

public class Product
{
    [Key]
    public int ProductId { get; set; }

    [Required, Column(TypeName = "VARCHAR"), StringLength(100)]
    public string Name { get; set; }

    [Required, Column(TypeName = "VARCHAR"), StringLength(50)]
    public string SKU { get; set; }

    [Column(TypeName = "VARCHAR"), StringLength(100)]
    public string Category { get; set; }

    public decimal UnitPrice { get; set; }

    public virtual ICollection<Inventory> Inventories { get; set; }
    public virtual ICollection<ShipmentDetail> ShipmentDetails { get; set; }
}
