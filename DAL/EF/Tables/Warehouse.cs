using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;



public class Warehouse{

        [Key]
        public int WarehouseId { get; set; }

        [Required, Column(TypeName = "VARCHAR"), StringLength(100)]
        public string Name { get; set; }

        [Required, Column(TypeName = "VARCHAR"), StringLength(200)]
        public string Location { get; set; }

        public int Capacity { get; set; }

        public virtual ICollection<Inventory> Inventories { get; set; }




        [InverseProperty("OriginWarehouse")]
        public virtual ICollection<Shipment> OriginShipments { get; set; }

        [InverseProperty("DestinationWarehouse")]
        public virtual ICollection<Shipment> DestinationShipments { get; set; }


        public virtual ICollection<Location> Locations { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
}
