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
    public class buyerService
    {
       
        public static bool DeleteBuyer(int id)
        {
            var buyerD = DataAccessFactory.Buyer().Get(id);
            bool flag = DataAccessFactory.Buyer().Delete(id);
            if (flag)
            {
                flag = DataAccessFactory.User().Delete(buyerD.uid);
            }
            return flag;
        }
        public static bool EditBuyer(UserBuyerModel obj)
        {
            var u = new user();
            u.id = obj.id;
            u.username = obj.username;
            u.password = obj.password;
            bool flag = DataAccessFactory.User().Edit(u);
            var b = new buyer();
            b.uid = obj.id;
            b.name = obj.buyer.name;
            b.email = obj.buyer.email;
            b.occupation = obj.buyer.occupation;
            b.netincome = obj.buyer.netincome;
            flag = DataAccessFactory.Buyer().Edit(b);
            return flag;
        }

        public static List<UserBuyerModel> AllBuyer()
        {
            var data = DataAccessFactory.Buyer().Get();
            var lst = new List<UserBuyerModel>();
            foreach(var e in data)
            {
                var u = new UserBuyerModel();
                u.id = e.user.id;
                u.username = e.user.username;
                u.password = e.user.password;
                u.role = e.user.role;
                u.status = e.user.status;
                //u.buyer = e.user;
                u.buyer.id = e.id;
                u.buyer.uid = e.uid;
                u.buyer.name = e.name;
                u.buyer.email = e.email;
                u.buyer.occupation = e.occupation;
                u.buyer.netincome = e.netincome;
                lst.Add(u);
            }
            return lst;
        }

        public static List<ReviewModel> AllReviews()
        {
            var data = DataAccessFactory.Review().Get();
            var list = new List<ReviewModel>();
            foreach (var rv in data)
            {
                var r = new ReviewModel();
                r.id = rv.id;
                r.Review1 = rv.Review1;
                r.Buyer_Id = rv.Buyer_Id;
                r.Rating = rv.Rating;
                list.Add(r);
            }
            return list;
        }

        public static bool DeleteReview(int id)
        {
            bool flag = DataAccessFactory.Review().Delete(id);
            return flag;
        }

        public static bool EditReview(ReviewModel obj)
        {
            var r = new Review();
            r.id = obj.id;
            r.Buyer_Id=obj.Buyer_Id;
            r.Rating=obj.Rating;
            r.Review1 = obj.Review1;
            bool flag = DataAccessFactory.Review().Edit(r);
            return flag;
        }

        public static bool AddReview(ReviewModel obj)
        {
            var rev = new Review();
            rev.Review1 = obj.Review1;
            rev.Buyer_Id = obj.Buyer_Id;
            rev.Rating = obj.Rating;
            bool flag = DataAccessFactory.Review().Add(rev);
            return flag;
        }







        public static List<CartModel> AllCart()
        {
            var list = new List<CartModel>();
            foreach (var c in DataAccessFactory.Cart().Get())
            {
                var r = new CartModel();
                r.Product_Id = c.Product_Id;
                r.Buyer_Id= c.Buyer_Id;
                r.Id = c.Id;
                r.Created_At = c.Created_At;
                r.Modified_At = c.Modified_At;
                list.Add((r));
            }
            return list;
        }


        public static bool AddCart(CartModel obj)
        {
            var crt = new Cart();
            crt.Product_Id= obj.Product_Id;
            crt.Buyer_Id= obj.Buyer_Id;
            crt.Created_At= DateTime.Now;
            crt.Modified_At= DateTime.Now;
            bool flag = DataAccessFactory.Cart().Add(crt);
            return flag;
        }
        public static bool EditCart(CartModel obj)
        {
            var r = new Cart();
            r.Id= obj.Id;
            r.Product_Id = obj.Product_Id;
            r.Buyer_Id =obj.Buyer_Id;
            r.Created_At = obj.Created_At;
            r.Modified_At=DateTime.Now;
            bool flag = DataAccessFactory.Cart().Edit(r);
            return flag;
        }


        public static bool DeleteCart(int id)
        {
            bool flag = DataAccessFactory.Cart().Delete(id);
            return flag;
        }


        public static List<OrderDetailsModel> AllOrders()
        {
            var data = DataAccessFactory.OrderDetails().Get();
            var list = new List<OrderDetailsModel>();
            foreach (var od in data)
            {
                var o = new OrderDetailsModel();
                o.Total = od.Total;
                o.Status = od.Status;
                o.Cart_Id = od.Cart_Id;
                o.Id = od.Id;
                o.Total = od.Total;
                list.Add(o);
            }

            return list;
        }


        public static bool AddOrder(OrderDetailsModel obj)
        {
            var ord = new Order_Details();
            ord.Id = obj.Id;
            ord.Total = obj.Total;
            ord.Status = obj.Status;
            ord.Cart_Id = obj.Cart_Id;
            bool flag = DataAccessFactory.OrderDetails().Add(ord);
            return flag;
        }

        public static bool DeleteOrder(int id)
        {
            return DataAccessFactory.OrderDetails().Delete(id);
        }

        public static bool UpdateOrder(OrderDetailsModel obj)
        {
            var ord = new Order_Details();
            ord.Id = obj.Id;
            ord.Cart_Id=obj.Cart_Id;
            ord.Status=obj.Status;
            ord.Total=obj.Total;
            return DataAccessFactory.OrderDetails().Edit(ord);
        }

        public static List<buyerModel> Search(string p)
        {
            var data = DataAccessFactory.Buyer().Search(p);
            if (data != null)
            {
                List<buyerModel> searchchk = new List<buyerModel>();
                foreach (var r in data)
                {
                    searchchk.Add(new buyerModel()
                    {
                        id = r.id,
                        uid=r.uid,
                        name = r.name,
                        email = r.email,
                        occupation =r.occupation,
                        netincome =r.netincome, 
                    
                    });

                }
                return searchchk;
            }
            return null;
        }
        public static List<ReviewModel> SearchReview(string p)
        {
            var data = DataAccessFactory.Review().Search(p);
            if (data != null)
            {
                List<ReviewModel> searchchk = new List<ReviewModel>();
                foreach (var r in data)
                {
                    searchchk.Add(new ReviewModel()
                    {
                        id = r.id,
                        Buyer_Id = r.Buyer_Id,  
                        Rating = r.Rating,
                        Review1 = r.Review1,

                    });

                }
                return searchchk;
            }
            return null;
        }
    }
}
