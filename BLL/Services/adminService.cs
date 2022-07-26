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
    public class adminService
    {
        public static bool DeleteAdmin(int id)
        {
            bool flag = false;
            flag = DataAccessFactory.Admin().Delete(id);
            return flag;
        }
        public static bool EditAdmin(adminModel obj)
        {
            var r = new administration();
            r.name = obj.name;
            r.email = obj.email;
            r.phone = obj.phone;
            r.address = obj.address;
            var flag = DataAccessFactory.Admin().Edit(r);
            return flag;
        }
    }
}
