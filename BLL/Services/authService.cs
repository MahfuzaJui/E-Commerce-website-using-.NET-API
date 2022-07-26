using BEL;
using DAL;
using DAL.Database;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class authService
    {
        public static bool UserLogin(userModel obj)
        {
            bool flag = false;
            var st = DataAccessFactory.UserAccess().Login(obj.username,obj.password);
            if(st == 1)
            { flag = true; }
            return flag;
        }

        public static bool SignUpAsSeller(UserSellerModel obj)
        {
            var u = new user();
            u.username = obj.username;
            u.password = obj.password;
            u.role = "seller";
            u.status = "active";
            var usrid = DataAccessFactory.AddUser().AddUser(u);
            var s = new seller();
            s.uid = usrid;
            s.name = obj.seller.name;
            s.email = obj.seller.email;
            s.phone = obj.seller.phone;
            s.presentaddress = obj.seller.presentaddress;
            s.permanentaddress = obj.seller.permanentaddress;
            s.facebooklink = obj.seller.facebooklink;
            s.whatsappno = obj.seller.whatsappno;
            s.occupation = obj.seller.occupation;
            var flag = DataAccessFactory.Seller().Add(s);
            return flag;
        }

        public static bool SignUpAsBuyer(UserBuyerModel obj)
        {
            var u = new user();
            u.username = obj.username;
            u.password = obj.password;
            u.role = "buyer";
            u.status = "active";
            var usrid = DataAccessFactory.AddUser().AddUser(u);
            var b = new buyer();
            b.uid = usrid;
            b.name = obj.buyer.name;
            b.email = obj.buyer.email;
            b.occupation = obj.buyer.occupation;
            b.netincome = obj.buyer.netincome;
            var flag = DataAccessFactory.Buyer().Add(b);
            return flag;
        }
    }
}
