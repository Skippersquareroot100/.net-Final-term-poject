using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Notification
{
    [Key]
    public int NotificationId { get; set; }

    public int WarehouseId { get; set; }

    [ForeignKey("WarehouseId")]
    public virtual Warehouse Warehouse { get; set; }

    [Required, Column(TypeName = "VARCHAR"), StringLength(250)]
    public string Message { get; set; }

    public DateTime CreatedAt { get; set; }

    [Required, Column(TypeName = "VARCHAR"), StringLength(50)]
    public string Type { get; set; } 
}
