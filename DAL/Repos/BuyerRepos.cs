using DAL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    class BuyerRepos : IRepository<buyer, int>
    {
        landSellingEntities db;
        public BuyerRepos(landSellingEntities db)
        {
            this.db = db;
        }
        public bool Add(buyer obj)
        {
            db.buyers.Add(obj);
            if (db.SaveChanges() != 0) return true;
            return false;
        }

        public bool Delete(int id)
        {
            var count = (from e in db.buyers
                         where e.id == id
                         select e).Count();
            if (count == 1)
            {
                var u = db.buyers.FirstOrDefault(x => x.id == id);
                db.buyers.Remove(u);
                db.SaveChanges();
                return true;
            }
            else
                return false;
        }

        public bool Edit(buyer obj)
        {
            var b = db.buyers.FirstOrDefault(x => x.uid == obj.uid);
            b.name = obj.name;
            b.email = obj.email;
            b.occupation = obj.occupation;
            b.netincome = obj.netincome;
            db.SaveChanges();
            return true;
        }

        public buyer Get(int id)
        {
            return db.buyers.FirstOrDefault(x => x.id == id);
        }

        public List<buyer> Get()
        {
            return db.buyers.ToList();
        }

        public List<buyer> Search(string name)
        {
            var searchchk = db.buyers.Where(x => x.name.Contains(name) || x.email.Contains(name)).ToList();
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
