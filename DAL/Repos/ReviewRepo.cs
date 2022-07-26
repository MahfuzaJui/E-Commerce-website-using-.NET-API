using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Database;

namespace DAL.Repos
{
    class ReviewRepo : IRepository<Review, int>
    {
        landSellingEntities db;

        public ReviewRepo(landSellingEntities db)
        {
            this.db = db;
        }

        public bool Add(Review obj)
        {
            db.Reviews.Add(obj);
            if (db.SaveChanges() != 0) return true;
            return false;
        }

        public bool Delete(int id)
        {
            var count = (from r in db.Reviews
                         where r.id == id
                         select r).Count();

            if (count == 1)
            {
                var rv = db.Reviews.FirstOrDefault(x => x.id == id);
                db.Reviews.Remove(rv);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Edit(Review obj)
        {
            var rv = db.Reviews.FirstOrDefault(x =>x.id == obj.id);
            rv.Review1 = obj.Review1;
            rv.Buyer_Id = obj.Buyer_Id;
            rv.Rating = obj.Rating;
            db.SaveChanges();
            return true;
        }

        public Review Get(int id)
        {
            return db.Reviews.FirstOrDefault(x => x.id == id);
        }

        public List<Review> Get()
        {
            return db.Reviews.ToList();
        }

        public List<Review> Search(string name)
        {
            var searchchk = db.Reviews.Where(x => x.Review1.Contains(name)).ToList();
            if (searchchk != null)
            {
                return searchchk;
            }
            else
            {
                return null;
            }
        }
    }
}
