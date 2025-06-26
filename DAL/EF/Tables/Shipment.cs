using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System;

public class Shipment
{
    [Key]
    public int ShipmentId { get; set; }

    public int OriginWarehouseId { get; set; }

    [ForeignKey("OriginWarehouseId")]
    public virtual Warehouse OriginWarehouse { get; set; }

    public int DestinationWarehouseId { get; set; }

    [ForeignKey("DestinationWarehouseId")]
    public virtual Warehouse DestinationWarehouse { get; set; }

    public DateTime ShipmentDate { get; set; }

    [Required, Column(TypeName = "VARCHAR"), StringLength(50)]
    public string Status { get; set; }

    public virtual ICollection<ShipmentDetail> ShipmentDetails { get; set; }
}
