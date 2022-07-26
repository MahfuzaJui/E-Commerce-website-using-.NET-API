using DAL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    class ProductRepo : IRepository<Product, int>
    {
        landSellingEntities db;
        public ProductRepo(landSellingEntities db)
        {
            this.db = db;
        }
        public bool Add(Product obj)
        {
            db.Products.Add(obj);
            if(db.SaveChanges() !=0) return true;
            return false;
        }

        public bool Delete(int id)
        {
            var count = (from p in db.Products
                         where p.Id == id
                         select p).Count();
            if(count == 1)
            {
                var pd = db.Products.FirstOrDefault(p => p.Id == id);
                db.Products.Remove(pd);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Edit(Product obj)
        {
            var d = db.Products.FirstOrDefault(p => p.Id == obj.Id);
            d.PropertyType = obj.PropertyType;
            d.Title = obj.Title;
            d.Size = obj.Size;
            d.Bath = obj.Bath;
            db.SaveChanges();
            return true;
        }

        public Product Get(int id)
        {
            return db.Products.FirstOrDefault(p => p.Id == id);
        }

        public List<Product> Get()
        {
            return db.Products.ToList();
        }

        public List<Product> Search(string name)
        {
            throw new NotImplementedException();
        }
    }
}
