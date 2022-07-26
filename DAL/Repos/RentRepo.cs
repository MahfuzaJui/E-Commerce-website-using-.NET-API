using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Database;

namespace DAL.Repos
{
    class RentRepo : IRepository<For_Rent, int>
    {
        landSellingEntities db;

        public RentRepo(landSellingEntities db) { this.db = db; }

        public bool Add(For_Rent obj)
        {
            db.For_Rent.Add(obj);
            if(db.SaveChanges() != 0) return true;
            return false;
        }

        public bool Delete(int id)
        {
            var count = (from r in db.For_Rent
                         where r.Id == id
                         select r).Count();

            if(count == 1)
            {
                var rt = db.For_Rent.FirstOrDefault(r => r.Id == id);
                db.For_Rent.Remove(rt);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Edit(For_Rent obj)
        {
            var rt = db.For_Rent.FirstOrDefault(r => r.Id == obj.Id);
            rt.Available_From = obj.Available_From;
            rt.Advance_Amount = obj.Advance_Amount;
            rt.Product_Id = obj.Product_Id;
            rt.Rate = obj.Rate;
            db.SaveChanges();
            return true;
        }

        public For_Rent Get(int id)
        {
            return db.For_Rent.FirstOrDefault(r => r.Id == id);
        }

        public List<For_Rent> Get()
        {
            return db.For_Rent.ToList();
        }

        public List<For_Rent> Search(string name)
        {
            throw new NotImplementedException();
        }
    }
}
