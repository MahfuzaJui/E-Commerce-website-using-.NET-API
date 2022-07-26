using DAL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class adminRepo : IRepository<administration, int>
    {
        private landSellingEntities db;

        public adminRepo(landSellingEntities db)
        {
            this.db = db;
        }

        public bool Add(administration obj)
        {
            db.administrations.Add(obj);
            if (db.SaveChanges() != 0) return true;
            return false;
        }

        public bool Delete(int id)
        {
            var count = (from e in db.administrations
                         where e.id == id
                         select e).Count();
            if (count == 1)
            {
                var u = db.administrations.FirstOrDefault(x => x.id == id);
                db.administrations.Remove(u);
                db.SaveChanges();
                return true;
            }
            else
                return false;
        }

        public bool Edit(administration obj)
        {
            var d = db.administrations.FirstOrDefault(x => x.id == obj.id);
            d.name = obj.name;
            d.email = obj.email;
            d.phone = obj.phone;
            d.address = obj.address;
            db.SaveChanges();
            return true;
        }

        public administration Get(int id)
        {
            var d = db.administrations.FirstOrDefault(x => x.id == id);
            return d;
        }

        public List<administration> Get()
        {
            return db.administrations.ToList();
        }

        public List<administration> Search(string name)
        {
            throw new NotImplementedException();
        }
    }
}
