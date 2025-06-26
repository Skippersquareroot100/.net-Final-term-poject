using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class ShipmentDetail
{
    [Key]
    public int ShipmentDetailId { get; set; }

    public int ShipmentId { get; set; }

    [ForeignKey("ShipmentId")]
    public virtual Shipment Shipment { get; set; }

    public int ProductId { get; set; }

    [ForeignKey("ProductId")]
    public virtual Product Product { get; set; }

    public int Quantity { get; set; }
}
