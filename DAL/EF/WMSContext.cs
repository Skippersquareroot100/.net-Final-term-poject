using System.Data.Entity;

namespace DAL.EF
{
    public class WMSContext : DbContext
    {
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Shipment> Shipments { get; set; }
        public DbSet<ShipmentDetail> ShipmentDetails { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<EmailLog> EmailLogs { get; set; }
        public DbSet<FileUpload> FileUploads { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Shipment>()
                .HasRequired(s => s.OriginWarehouse)
                .WithMany(w => w.OriginShipments)
                .HasForeignKey(s => s.OriginWarehouseId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Shipment>()
                .HasRequired(s => s.DestinationWarehouse)
                .WithMany(w => w.DestinationShipments)
                .HasForeignKey(s => s.DestinationWarehouseId)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}
