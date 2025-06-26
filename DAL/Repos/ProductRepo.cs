using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repos
{
    internal class ProductRepo : Repo, IRepo<Product, int, Product>
    {
        public Product Add(Product obj)
        {
            db.Products.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var dbobj = Get(id);
            db.Products.Remove(dbobj);
            return db.SaveChanges() > 0;
        }

        public List<Product> Get()
        {
            return db.Products.ToList();
        }

        public Product Get(int id)
        {
            return db.Products.Find(id);
        }

        public Product Update(Product obj)
        {
            var dbobj = Get(obj.ProductId);
            db.Entry(dbobj).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}