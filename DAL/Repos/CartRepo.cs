using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Database;

namespace DAL.Repos
{
    class CartRepo : IRepository<Cart, int>
    {

        landSellingEntities db;

        public CartRepo(landSellingEntities db) { this.db = db; }
        public bool Add(Cart obj)
        {
            db.Carts.Add(obj);
            if (db.SaveChanges() != 0) return true;
            return false;
        }

        public bool Delete(int id)
        {
            var count = (from c in db.Carts
                        where c.Id == id
                        select c).Count();

            if(count == 1)
            {
                var ct = db.Carts.FirstOrDefault(c => c.Id == id);
                db.Carts.Remove(ct);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool Edit(Cart obj)
        {
            var ct = db.Carts.FirstOrDefault(db => db.Id == obj.Id);
            ct.Product_Id = obj.Product_Id;
            ct.Buyer_Id = obj.Buyer_Id;
            ct.Created_At = obj.Created_At;
            ct.Modified_At = obj.Modified_At;
            db.SaveChanges();
            return true;
        }

        public Cart Get(int id)
        {
            return db.Carts.FirstOrDefault(c => c.Id == id);
        }

        public List<Cart> Get()
        {
            return db.Carts.ToList();
        }

        public List<Cart> Search(string name)
        {
            throw new NotImplementedException();
        }
    }
}
