using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DAL.Database;
using DAL;
using System.Data;

namespace DAL.Repos
{
    public class AuthRepo : IAuth
    {
        landSellingEntities db;
        public AuthRepo(landSellingEntities db)
        {
            this.db = db;
        }
        public Token Authenticate(string username, string password)
        {
            Token t = null;
            var authcheck = db.users.FirstOrDefault(u => u.username == username && u.password == password);
            if (authcheck != null)
            {
                //var r = new Random();
                var g = Guid.NewGuid();
                var token = g.ToString();
                t = new Token()
                {
                    UserId = authcheck.id,
                    B_Token = token,
                    CreatedAt = DateTime.Now,
                    ExpiredAt = DateTime.Now.AddMinutes(10)
                };
                db.Tokens.Add(t);
                db.SaveChanges();
                return t;
            }
            else
            {
                return null;
            }
        }

        public bool IsAuthenticated(string token)
        {
            var tokencheck = db.Tokens.FirstOrDefault(t => t.B_Token.Equals(token) && DateTime.Compare((DateTime)t.ExpiredAt, DateTime.Now) > 0);

            if (tokencheck != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsBuyerAuthenticated(string token)
        {
            //DateTime.Compare(t1, t2);
            //Less than zero t1 is earlier than t2.
            //Zero t1 is the same as t2.
            //Greater than zero   t1 is later than t2.
            using (landSellingEntities db = new landSellingEntities())
            {
                var tokencheck = db.Tokens.FirstOrDefault(t => t.B_Token.Equals(token) && DateTime.Compare((DateTime)t.ExpiredAt, DateTime.Now) > 0);
                var userType = (from t in db.Tokens
                                join u in db.users on t.UserId equals u.id
                                where t.B_Token.Equals(token) && u.status.Equals("active")
                                select new
                                {
                                    u.role
                                }).ToList();
                var utype = "";
                foreach (var item in userType)
                {
                    utype = item.role.ToString();
                }
                if (tokencheck != null && utype.Equals("buyer"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }


        public bool Logout(int uid)
        {
            var data = db.Tokens.FirstOrDefault(t => t.UserId == uid && DateTime.Compare((DateTime)t.CreatedAt, DateTime.Now) < 0 && DateTime.Compare((DateTime)t.ExpiredAt, DateTime.Now) > 0);
            if (data != null)
            {
                data.ExpiredAt = DateTime.Now;
                db.Entry(data).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
