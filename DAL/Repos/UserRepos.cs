using DAL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class UserRepos : IRepository<user, int> , ILog , IAddUser<user>
    {
        landSellingEntities db;
        public UserRepos(landSellingEntities db)
        {
            this.db = db;
        }
        public bool Add(user obj)
        {
            db.users.Add(obj);
            if (db.SaveChanges() != 0) return true;
            return false;
        }

        public int AddUser(user e)
        {
            db.users.Add(e);
            db.SaveChanges();
            return e.id;
        }

        public bool Delete(int id)
        {
            var u = db.users.FirstOrDefault(x => x.id == id);
            db.users.Remove(u);
            db.SaveChanges();
            return true;
        }

        public bool Edit(user obj)
        {
            var u = db.users.FirstOrDefault(x => x.id == obj.id);
            u.username = obj.username;
            u.password = obj.password;
            //db.users.Remove(u);
            db.SaveChanges();
            return true;
        }

        public user Get(int id)
        {
            return db.users.FirstOrDefault(x => x.id == id);
        }

        public List<user> Get()
        {
            return db.users.ToList();
        }

        public int Login(string uname, string pass)
        {
            var userCount = (from e in db.users
                        where e.username.Equals(uname) && e.password.Equals(pass)
                        select e).Count();
            return userCount;
        }

        public List<user> Search(string name)
        {
            throw new NotImplementedException();
        }
    }
}
