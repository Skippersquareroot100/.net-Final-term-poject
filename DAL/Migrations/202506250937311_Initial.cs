namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration{
        public override void Up()
        {
            CreateTable(
                "dbo.EmailLogs",
                c => new
                    {
                        EmailLogId = c.Int(nullable: false, identity: true),
                        ToEmail = c.String(nullable: false, maxLength: 100, unicode: false),
                        Subject = c.String(maxLength: 200, unicode: false),
                        Body = c.String(),
                        SentAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.EmailLogId);
            
            CreateTable(
                "dbo.FileUploads",
                c => new
                    {
                        FileId = c.Int(nullable: false, identity: true),
                        FileName = c.String(nullable: false, maxLength: 200, unicode: false),
                        FilePath = c.String(nullable: false, maxLength: 500, unicode: false),
                        UploadedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.FileId);
            
            CreateTable(
                "dbo.Inventories",
                c => new
                    {
                        InventoryId = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        WarehouseId = c.Int(nullable: false),
                        LocationId = c.Int(),
                        Quantity = c.Int(nullable: false),
                        LastUpdated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.InventoryId)
                .ForeignKey("dbo.Locations", t => t.LocationId)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Warehouses", t => t.WarehouseId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.WarehouseId)
                .Index(t => t.LocationId);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        LocationId = c.Int(nullable: false, identity: true),
                        WarehouseId = c.Int(nullable: false),
                        Aisle = c.String(maxLength: 10, unicode: false),
                        Rack = c.String(maxLength: 10, unicode: false),
                        Bin = c.String(maxLength: 10, unicode: false),
                    })
                .PrimaryKey(t => t.LocationId)
                .ForeignKey("dbo.Warehouses", t => t.WarehouseId, cascadeDelete: true)
                .Index(t => t.WarehouseId);
            
            CreateTable(
                "dbo.Warehouses",
                c => new
                    {
                        WarehouseId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100, unicode: false),
                        Location = c.String(nullable: false, maxLength: 200, unicode: false),
                        Capacity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.WarehouseId);
            
            CreateTable(
                "dbo.Shipments",
                c => new
                    {
                        ShipmentId = c.Int(nullable: false, identity: true),
                        OriginWarehouseId = c.Int(nullable: false),
                        DestinationWarehouseId = c.Int(nullable: false),
                        ShipmentDate = c.DateTime(nullable: false),
                        Status = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.ShipmentId)
                .ForeignKey("dbo.Warehouses", t => t.DestinationWarehouseId)
                .ForeignKey("dbo.Warehouses", t => t.OriginWarehouseId)
                .Index(t => t.OriginWarehouseId)
                .Index(t => t.DestinationWarehouseId);
            
            CreateTable(
                "dbo.ShipmentDetails",
                c => new
                    {
                        ShipmentDetailId = c.Int(nullable: false, identity: true),
                        ShipmentId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ShipmentDetailId)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Shipments", t => t.ShipmentId, cascadeDelete: true)
                .Index(t => t.ShipmentId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100, unicode: false),
                        SKU = c.String(nullable: false, maxLength: 50, unicode: false),
                        Category = c.String(maxLength: 100, unicode: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ProductId);
            
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        NotificationId = c.Int(nullable: false, identity: true),
                        WarehouseId = c.Int(nullable: false),
                        Message = c.String(nullable: false, maxLength: 250, unicode: false),
                        CreatedAt = c.DateTime(nullable: false),
                        Type = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.NotificationId)
                .ForeignKey("dbo.Warehouses", t => t.WarehouseId, cascadeDelete: true)
                .Index(t => t.WarehouseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Notifications", "WarehouseId", "dbo.Warehouses");
            DropForeignKey("dbo.Locations", "WarehouseId", "dbo.Warehouses");
            DropForeignKey("dbo.Inventories", "WarehouseId", "dbo.Warehouses");
            DropForeignKey("dbo.ShipmentDetails", "ShipmentId", "dbo.Shipments");
            DropForeignKey("dbo.ShipmentDetails", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Inventories", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Shipments", "OriginWarehouseId", "dbo.Warehouses");
            DropForeignKey("dbo.Shipments", "DestinationWarehouseId", "dbo.Warehouses");
            DropForeignKey("dbo.Inventories", "LocationId", "dbo.Locations");
            DropIndex("dbo.Notifications", new[] { "WarehouseId" });
            DropIndex("dbo.ShipmentDetails", new[] { "ProductId" });
            DropIndex("dbo.ShipmentDetails", new[] { "ShipmentId" });
            DropIndex("dbo.Shipments", new[] { "DestinationWarehouseId" });
            DropIndex("dbo.Shipments", new[] { "OriginWarehouseId" });
            DropIndex("dbo.Locations", new[] { "WarehouseId" });
            DropIndex("dbo.Inventories", new[] { "LocationId" });
            DropIndex("dbo.Inventories", new[] { "WarehouseId" });
            DropIndex("dbo.Inventories", new[] { "ProductId" });
            DropTable("dbo.Notifications");
            DropTable("dbo.Products");
            DropTable("dbo.ShipmentDetails");
            DropTable("dbo.Shipments");
            DropTable("dbo.Warehouses");
            DropTable("dbo.Locations");
            DropTable("dbo.Inventories");
            DropTable("dbo.FileUploads");
            DropTable("dbo.EmailLogs");
        }
    }
}
