using DAL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class postRepo : IRepository<post, int>
    {
        landSellingEntities db;
        public postRepo(landSellingEntities db)
        {
            this.db = db;
        }
        public bool Add(post obj)
        {
            db.posts.Add(obj);
            if (db.SaveChanges() != 0) return true;
            return false;
        }

        public bool Delete(int id)
        {
            var count = (from e in db.posts
                         where e.id == id
                         select e).Count();
            if (count == 1)
            {
                var u = db.posts.FirstOrDefault(x => x.id == id);
                db.posts.Remove(u);
                db.SaveChanges();
                return true;
            }
            else
                return false;
        }

        public bool Edit(post obj)
        {
            var d = db.posts.FirstOrDefault(x => x.id == obj.id);
            d.title = obj.title;
            d.description = obj.description;
            d.location = obj.location;
            d.price = obj.price;
            db.SaveChanges();
            return true;
        }

        public post Get(int id)
        {
            var d = db.posts.FirstOrDefault(x => x.id == id);
            return d;
        }

        public List<post> Get()
        {
            throw new NotImplementedException();
        }

        public List<post> Search(string name)
        {
            throw new NotImplementedException();
        }
    }
}
