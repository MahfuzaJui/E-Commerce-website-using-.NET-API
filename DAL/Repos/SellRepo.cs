using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Database;

namespace DAL.Repos
{
    class SellRepo : IRepository<For_Sell, int>
    {
        landSellingEntities db;

        public SellRepo(landSellingEntities db) { this.db = db; }
        public bool Add(For_Sell obj)
        {
            db.For_Sell.Add(obj);
            if (db.SaveChanges() != 0) return true;
            return false;
        }

        public bool Delete(int id)
        {
            var count = (from s in db.For_Sell
                         where s.Id == id
                         select s).Count();

            if (count == 1)
            {
                var sl = db.For_Sell.FirstOrDefault(s => s.Id == id);
                db.For_Sell.Remove(sl);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Edit(For_Sell obj)
        {
            var sl = db.For_Sell.FirstOrDefault(x => x.Id == obj.Id);
            sl.Price = obj.Price;
            sl.AvailableFrom = obj.AvailableFrom;
            sl.Product_Id = obj.Product_Id;
            db.SaveChanges();
            return true;

        }

        public For_Sell Get(int id)
        {
            return db.For_Sell.FirstOrDefault(x => x.Id == id);
        }

        public List<For_Sell> Get()
        {
            return db.For_Sell.ToList();
        }

        public List<For_Sell> Search(string name)
        {
            throw new NotImplementedException();
        }
    }
}
