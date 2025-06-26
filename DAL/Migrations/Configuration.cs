namespace DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.EF.WMSContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.EF.WMSContext context)
        {


       
            var rand = new Random();

            // Warehouses
            context.Warehouses.AddOrUpdate(w => w.WarehouseId,
                new Warehouse { WarehouseId = 1, Name = "Main", Location = "Dhaka", Capacity = 1000 },
                new Warehouse { WarehouseId = 2, Name = "Branch", Location = "Chattogram", Capacity = 800 }
            );
            context.SaveChanges();

            // Products
            for (int i = 1; i <= 20; i++)
            {
                context.Products.AddOrUpdate(p => p.ProductId, new Product
                {
                    ProductId = i,
                    Name = $"Product_{Guid.NewGuid().ToString().Substring(0, 6)}",
                    SKU = $"SKU{i}{rand.Next(100, 999)}",
                    Category = i % 2 == 0 ? "Electronics" : "Office",
                    UnitPrice = rand.Next(1000, 100000)
                });
            }
            context.SaveChanges();

            // Locations
            for (int i = 1; i <= 10; i++)
            {
                context.Locations.AddOrUpdate(l => l.LocationId, new Location
                {
                    LocationId = i,
                    WarehouseId = i % 2 == 0 ? 2 : 1,
                    Aisle = $"A{i}",
                    Rack = $"R{i}",
                    Bin = $"B{i}"
                });
            }
            context.SaveChanges();

            // Inventory
            for (int i = 1; i <= 20; i++)
            {
                context.Inventories.AddOrUpdate(inv => inv.InventoryId, new Inventory
                {
                    InventoryId = i,
                    ProductId = i,
                    WarehouseId = i % 2 == 0 ? 2 : 1,
                    LocationId = (i % 10) + 1,
                    Quantity = rand.Next(5, 500),
                    LastUpdated = DateTime.Now
                });
            }
            context.SaveChanges();

            // Shipments
            for (int i = 1; i <= 10; i++)
            {
                context.Shipments.AddOrUpdate(s => s.ShipmentId, new Shipment
                {
                    ShipmentId = i,
                    OriginWarehouseId = 1,
                    DestinationWarehouseId = 2,
                    ShipmentDate = DateTime.Now.AddDays(-i),
                    Status = i % 2 == 0 ? "Delivered" : "In Transit"
                });
            }
            context.SaveChanges();

            // ShipmentDetails
            for (int i = 1; i <= 20; i++)
            {
                context.ShipmentDetails.AddOrUpdate(sd => sd.ShipmentDetailId, new ShipmentDetail
                {
                    ShipmentDetailId = i,
                    ShipmentId = (i % 10) + 1,
                    ProductId = (i % 20) + 1,
                    Quantity = rand.Next(1, 100)
                });
            }
            context.SaveChanges();

            // Notifications
            for (int i = 1; i <= 10; i++)
            {
                context.Notifications.AddOrUpdate(n => n.NotificationId, new Notification
                {
                    NotificationId = i,
                    WarehouseId = i % 2 == 0 ? 2 : 1,
                    Message = $"Notification_{Guid.NewGuid().ToString().Substring(0, 5)}",
                    Type = i % 2 == 0 ? "LowStock" : "ShipmentDelay",
                    CreatedAt = DateTime.Now.AddMinutes(-rand.Next(30, 300))
                });
            }
            context.SaveChanges();

            // File Uploads
            for (int i = 1; i <= 10; i++)
            {
                context.FileUploads.AddOrUpdate(f => f.FileId, new FileUpload
                {
                    FileId = i,
                    FileName = $"upload_{Guid.NewGuid().ToString().Substring(0, 5)}.pdf",
                    FilePath = $"/uploads/doc_{i}.pdf",
                    UploadedAt = DateTime.Now.AddDays(-i)
                });
            }
            context.SaveChanges();
        
        //  This method will be called after migrating to the latest version.

        //  You can use the DbSet<T>.AddOrUpdate() helper extension method
        //  to avoid creating duplicate seed data.
    }
    }
}
