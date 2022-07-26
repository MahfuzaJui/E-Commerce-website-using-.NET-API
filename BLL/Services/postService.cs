using BEL;
using DAL;
using DAL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class postService
    {
        public static bool AddPost(postModel obj)
            {
                bool flag = false;
                var r = new post();
                r.id = obj.id;
                r.title = obj.title;
                r.description = obj.description;
                r.price = obj.price;
                r.propertyType = obj.propertyType;
                flag = DataAccessFactory.Post().Add(r);
                return flag;
            }

        public static bool DeletePost(int id)
        {
            bool flag = false;
            flag = DataAccessFactory.Post().Delete(id);
            return flag;
        }
        public static bool EditPost(postModel obj)
        {
            var r = new post();
            r.id = obj.id;
            r.title = obj.title;
            r.description = obj.description;
            r.price = obj.price;
            r.propertyType = obj.propertyType;
            var flag = DataAccessFactory.Post().Edit(r);
            return flag;
        }
    }
}
