using BLL.DTOs;
using DAL;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    public class ProductService
    {
        public static List<ProductDTO> Get()
        {
            var data = DataAccessFactory.ProductDataAccess().Get();
            return data.Select(p => new ProductDTO
            {
                ProductId = p.ProductId,
                Name = p.Name,             
                SKU = p.SKU,
                UnitPrice = p.UnitPrice,
                Category = p.Category
            }).ToList();
        }

        public static ProductDTO Get(int id)
        {
            var item = DataAccessFactory.ProductDataAccess().Get(id);
            if (item == null) return null;
            return new ProductDTO
            {
                ProductId = item.ProductId,
                Name = item.Name,             
                SKU = item.SKU,
                UnitPrice =item.UnitPrice,
                Category = item.Category
            };
        }

        public static ProductDTO Add(ProductDTO dto)
        {
            var obj = new Product
            {
                Name = dto.Name,
                SKU = dto.SKU,
                UnitPrice = dto.UnitPrice,
                Category = dto.Category
            };
            var data = DataAccessFactory.ProductDataAccess().Add(obj);
            if (data == null) return null;
            return new ProductDTO
            {
                ProductId = data.ProductId,
                Name = data.Name,
                SKU = data.SKU,
                UnitPrice = data.UnitPrice,
                Category = data.Category
            };
        }

 
        public static bool Delete(int id)
        {
            return DataAccessFactory.ProductDataAccess().Delete(id);
        }
    }
}