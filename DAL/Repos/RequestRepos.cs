using DAL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class RequestRepos : IRepository<request, int>
    {
        landSellingEntities db;
        public RequestRepos(landSellingEntities db)
        {
            this.db = db;
        }
        public bool Add(request obj)
        {
            db.requests.Add(obj);
            if (db.SaveChanges() != 0) return true;
            return false;
        }

        public bool Delete(int id)
        {   
            var count = (from e in db.requests
                         where e.id == id
                         select e).Count();
            if (count == 1)
            {
                var u = db.requests.FirstOrDefault(x => x.id == id);
                db.requests.Remove(u);
                db.SaveChanges();
                return true; 
            }
            else
            return false;
        }

        public bool Edit(request obj)
        {
            var d = db.requests.FirstOrDefault(x => x.id == obj.id);
            d.bidprice = obj.bidprice;
            db.SaveChanges();
            return true;
        }

        public request Get(int id)
        {
            var d = db.requests.FirstOrDefault(x => x.id == id);
            return d;
        }

        public List<request> Get()
        {
            return db.requests.ToList();
        }

        public List<request> Search(string name)
        {
            throw new NotImplementedException();
        }
    }
}
