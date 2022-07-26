using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Database;

namespace DAL
{
    public class DataAccessFactory
    {
        static landSellingEntities db = new landSellingEntities();
        public static ILog UserAccess()
        {
            return new UserRepos(db);
        }
        public static IRepository<user, int> User()
        {
            return new UserRepos(db);
        }
        public static IAddUser<user> AddUser()
        {
            return new UserRepos(db);
        }


        public static IRepository<seller, int> Seller()
        {
            return new SellerRepos(db);
        }

        public static IRepository<buyer, int> Buyer()
        {
            return new BuyerRepos(db);
        }

        public static IRepository<request, int> Request()
        {
            return new RequestRepos(db);
        }
        /*public static IAuth AuthDataAccess() {
            return new UserRepos(db);
        }*/

        public static IRepository<post, int> Post()
        {
            return new postRepo(db);
        }

        public static IRepository<administration, int> Admin()
        {
            return new adminRepo(db);
        }

        public static IRepository<Product, int> Product()
        {
            return new ProductRepo(db);
        }

        public static IRepository<For_Rent, int> Rent()
        {
            return new RentRepo(db);
        }

        public static IRepository<Review, int> Review()
        {
            return new ReviewRepo(db);
        }

        public static IRepository<Cart, int> Cart()
        {
            return new CartRepo(db);
        }
        
        public static IRepository<Order_Details, int> OrderDetails()
        {
            return new OrderDetailsRepo(db);
        }

        public static IRepository<For_Sell, int> Sell()
        {
            return new SellRepo(db);
        }

        public static IAuth AuthDataAccess()
        {
            return new AuthRepo(db);
        }


    }
}
