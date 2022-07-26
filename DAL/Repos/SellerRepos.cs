using DAL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class SellerRepos : IRepository<seller, int>
    {
        landSellingEntities db;
        public SellerRepos(landSellingEntities db)
        {
            this.db = db;
        }
        public bool Add(seller obj)
        {
            db.sellers.Add(obj);
            if (db.SaveChanges() != 0) return true;
            return false;
        }

        public bool Delete(int id)
        {
            var count = (from e in db.sellers
                         where e.id == id
                         select e).Count();
            if (count == 1)
            {
                var u = db.sellers.FirstOrDefault(x => x.id == id);
                db.sellers.Remove(u);
                db.SaveChanges();
                return true;
            }
            else
                return false;
        }

        public bool Edit(seller obj)
        {
            var d = db.sellers.FirstOrDefault(x => x.id == obj.id);
            d.name = obj.name;
            d.email = obj.email;
            d.phone = obj.phone;
            d.presentaddress = obj.presentaddress;
            d.permanentaddress = obj.permanentaddress;
            db.SaveChanges();
            return true;
        }

        public seller Get(int id)
        {
            var d = db.sellers.FirstOrDefault(x => x.id == id);
            return d;
        }

        public List<seller> Get()
        {
            return db.sellers.ToList();
        }

        public List<seller> Search(string name)
        {
            throw new NotImplementedException();
        }
    }
}
