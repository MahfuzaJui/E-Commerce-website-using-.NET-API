using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Database;

namespace DAL.Repos
{
    class OrderDetailsRepo : IRepository<Order_Details, int>
    {
        landSellingEntities db;

        public OrderDetailsRepo(landSellingEntities db) { this.db = db; }
        public bool Add(Order_Details obj)
        {
            db.Order_Details.Add(obj);
            if (db.SaveChanges() != 0) return true;
            return false;
        }

        public bool Delete(int id)
        {
            var count = db.Order_Details.Where(x => x.Id == id).Count();
                    
            if (count ==1)
            {
                var od = db.Order_Details.FirstOrDefault(x => x.Id == id);
                db.Order_Details.Remove(od);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Edit(Order_Details obj)
        {
            var od = db.Order_Details.FirstOrDefault(x => x.Id==obj.Id);
            od.Status = obj.Status;
            od.Cart_Id = obj.Cart_Id;
            od.Total = obj.Total;
            db.SaveChanges();
            return true;
        }

        public Order_Details Get(int id)
        {
            return db.Order_Details.FirstOrDefault(x => x.Id == id);
        }

        public List<Order_Details> Get()
        {
            return db.Order_Details.ToList();
        }

        public List<Order_Details> Search(string name)
        {
            throw new NotImplementedException();
        }
    }
}
