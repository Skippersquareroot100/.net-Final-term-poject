using DAL.Interfaces;
using DAL.Repos;
using System;

namespace DAL
{
    public class DataAccessFactory
    {
        public static IRepo<Warehouse, int, Warehouse> WarehouseDataAccess()
        {
            return new WarehouseRepo();
        }
        public static IRepo<Warehouse, int, bool> WarehouseDataAccessForUpdate()
        {
            return new BoolWarehouseRepo();
        }

        public static IRepo<Product, int, Product> ProductDataAccess()
        {
            return new ProductRepo();
        }

        public static IRepo<Location, int, Location> LocationDataAccess()
        {
            return new LocationRepo();
        }

        public static IRepo<Inventory, int, Inventory> InventoryDataAccess()
        {
            return new InventoryRepo();
        }

        public static IRepo<Shipment, int, Shipment> ShipmentDataAccess()
        {
            return new ShipmentRepo();
        }

        public static IRepo<Notification, int, Notification> NotificationDataAccess()
        {
            return new NotificationRepo();
        }

        public static IRepo<FileUpload, int, FileUpload> FileUploadDataAccess()
        {
            return new FileUploadRepo();
        }

        
        public static ISearchInventory<Inventory, bool,int> InventorySearchDataAccess()
        {
            return new InventoryRepo();
        }

        public static ILowStockAlert<Notification, int, bool> LowStockAlertDataAccess()
        {
            return new InventoryRepo();
        }

        public static IShipmentTracking<Shipment, int> ShipmentTrackingDataAccess()
        {
            return new ShipmentRepo();
        }

        public static IFileUploadService<FileUpload, int, bool> FileUploadServiceDataAccess()
        {
            return new FileUploadRepo();
        }

        public static IWarehouseUtilization<Warehouse, int> WarehouseUtilizationDataAccess()
        {
            return new WarehouseRepo();
        }
       
    }
}