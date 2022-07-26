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
    public class sellerService
    {
        public static bool DeleteSeller(int id)
        {
            bool flag = DataAccessFactory.Seller().Delete(id);
            return flag;
        }
        public static bool EditSeller(sellerModel obj)
        {
            var r = new seller();
            r.name = obj.name;
            r.email = obj.email;
            r.phone = obj.phone;
            r.presentaddress = obj.presentaddress;
            r.permanentaddress = obj.permanentaddress;
            var flag = DataAccessFactory.Seller().Edit(r);
            return flag;
        }

        public static List<ProductModel> AllProducts()
        {
            var data = DataAccessFactory.Product().Get();
            var lst = new List<ProductModel>();

            foreach (var p in data)
            {
                var pd = new ProductModel();
                pd.Id = p.Id;
                pd.Bed = p.Bed;
                pd.Title = p.Title;
                pd.Size = p.Size;
                pd.Bath = p.Bath;
                lst.Add(pd);
            }

            return lst;
        }


        public static bool AddProduct(ProductModel obj)
        {
            var prod = new Product();
            prod.PropertyType = obj.PropertyType;
            prod.Title = obj.Title;
            prod.Size = obj.Size;
            prod.Bath = obj.Bath;
            prod.Bed = obj.Bed;
            bool flag = DataAccessFactory.Product().Add(prod);
            return flag;
        }

        public static bool DeleteProduct(int id)
        {
            bool flag = DataAccessFactory.Product().Delete(id);
            return flag;
        }

        public static bool EditProduct(ProductModel p)
        {
            var prod = new Product();
            prod.Id = p.Id;
            prod.Bed = p.Bed;
            prod.Title = p.Title;
            prod.Size = p.Size;
            prod.Bath = p.Bath;
            bool flag = DataAccessFactory.Product().Edit(prod);
            return flag;
        }

        
        public static List<RentModel> AllRent()
        {
            var list = new List<RentModel>();
            foreach (var r in DataAccessFactory.Rent().Get())
            {
                var rt = new RentModel();
                rt.Id = r.Id;
                rt.Available_From = r.Available_From;
                rt.Rate = r.Rate;
                rt.Advance_Amount = r.Advance_Amount;
                list.Add(rt);
            }
            return list;
        }

        public static bool DeleteRent(int id)
        {
            bool flag = DataAccessFactory.Rent().Delete(id);
            return flag;
        }

        public static bool EditRent(RentModel obj)
        {
            var r = new For_Rent();
            r.Id = obj.Id;
            r.Available_From = obj.Available_From;
            r.Rate = obj.Rate;
            r.Advance_Amount = obj.Advance_Amount;
            bool flag = DataAccessFactory.Rent().Edit(r);
            return flag;
        }

        public static List<SellModel> AllSell()
        {
            var list = new List<SellModel>();
            foreach (var s in DataAccessFactory.Sell().Get())
            {
                var sm = new SellModel();
                sm.Id = s.Id;
                sm.AvailableFrom = s.AvailableFrom;
                sm.Price = s.Price;
                sm.Product_Id = s.Product_Id;
                list.Add(sm);
            }
            return list;
        }

        public static bool DeleteSell(int id)
        {
            bool flag = DataAccessFactory.Sell().Delete(id);
            return flag;
        }

        public static bool EditSell(SellModel obj)
        {
            var s = new For_Sell();
            s.Id = obj.Id;
            s.AvailableFrom = obj.AvailableFrom;
            s.Price = obj.Price;
            s.Product_Id = obj.Product_Id;
            bool flag = DataAccessFactory.Sell().Edit(s);
            return flag;
        }
    }
}
