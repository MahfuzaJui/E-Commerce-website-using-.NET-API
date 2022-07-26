using BEL;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Presentation_WebAPI.Auth;

namespace Presentation_WebAPI.Controllers
{
    [BuyerAuth]
    public class buyerController : ApiController
    {
        [HttpPost]
        [Route("api/buyer/search")]
        public HttpResponseMessage BuyerSearch(buyerModel u)
        {
            var data = buyerService.Search(u.name);
            if (data == null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Not Found");
            }
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [HttpPost]
        [Route("api/reviews/search")]
        public HttpResponseMessage Reviewsearch(ReviewModel u)
        {
            var data = buyerService.SearchReview(u.Review1);
            if (data == null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Not Found");
            }
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpGet]
        [Route("api/buyer/all")]
        public HttpResponseMessage BuyerAll()
        {
            var listBuyer = buyerService.AllBuyer();
            return Request.CreateResponse(HttpStatusCode.OK, listBuyer);
        }

        [HttpPost]
        [Route("api/buyer/delete/{id}")]
        public HttpResponseMessage BuyerDelete(int id)
        {
            var isreq = buyerService.DeleteBuyer(id);
            if (isreq) { return Request.CreateResponse(HttpStatusCode.OK, "Buyer account deleted!"); }
            return Request.CreateResponse(HttpStatusCode.OK, "failed to delete!");
        }

        [HttpPost]
        [Route("api/buyer/edit")]
        public HttpResponseMessage BuyerEdit(UserBuyerModel obj)
        {
            var isreq = buyerService.EditBuyer(obj);
            if (isreq) { return Request.CreateResponse(HttpStatusCode.OK, "Data Updated!"); }
            return Request.CreateResponse(HttpStatusCode.OK, "failed to update data!");
        }






        [HttpGet]
        [Route("api/reviews")]
        public HttpResponseMessage AllReviews()
        {
            var data = buyerService.AllReviews();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpPost]
        [Route("api/review/delete/{id}")]
        public HttpResponseMessage DeleteReview(int id)
        {
            var flag = buyerService.DeleteReview(id);
            if (flag) { return Request.CreateResponse(HttpStatusCode.OK, "Review Deleted"); }
            return Request.CreateResponse(HttpStatusCode.OK, "Failed to delete");
        }

        [HttpPost]
        [Route("api/review/edit")]

        public HttpResponseMessage EditReview(ReviewModel obj)
        {
            bool flag = buyerService.EditReview(obj);
            if (flag) { return Request.CreateResponse(HttpStatusCode.OK, "Data Updated"); }
            return Request.CreateResponse(HttpStatusCode.OK, "Failed to update data!");
        }

        [HttpPost]
        [Route("api/review/add")]
        public HttpResponseMessage AddReview(ReviewModel obj)
        {
            bool flag = buyerService.AddReview(obj);
            if (flag) { return Request.CreateResponse(HttpStatusCode.OK, "Succesfully added"); }
            return Request.CreateResponse(HttpStatusCode.OK, "Failed to add review!");
        }



        [HttpGet]
        [Route("api/carts")]
        public HttpResponseMessage AllCarts()
        {
            var data = buyerService.AllCart();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpPost]
        [Route("api/cart/add")]
        public HttpResponseMessage AddCart(CartModel obj)
        {
            bool flag = buyerService.AddCart(obj);
            if (flag) { return Request.CreateResponse(HttpStatusCode.OK, "Cart Created Successfully"); }
            return Request.CreateResponse(HttpStatusCode.OK, "Failed to Create Cart");
        }

        [HttpPost]
        [Route("api/cart/delete/{id}")]
        public HttpResponseMessage DeleteCart(int id)
        {
            var flag = buyerService.DeleteCart(id);
            if (flag) { return Request.CreateResponse(HttpStatusCode.OK, "Cart Deleted"); }
            return Request.CreateResponse(HttpStatusCode.OK, "Failed to delete cart");
        }

        [HttpPost]
        [Route("api/cart/edit")]

        public HttpResponseMessage EditCart(CartModel obj)
        {
            bool flag = buyerService.EditCart(obj);
            if (flag) { return Request.CreateResponse(HttpStatusCode.OK, "Data Updated"); }
            return Request.CreateResponse(HttpStatusCode.OK, "Failed to update data!");
        }


        [HttpGet]
        [Route("api/orders")]
        public HttpResponseMessage AllOrders()
        {
            var list = buyerService.AllOrders();
            return Request.CreateResponse(HttpStatusCode.OK, list);
        }

        [HttpPost]
        [Route("api/order/delete/{id}")]
        public HttpResponseMessage DeleteOrder(int id)
        {
            if (buyerService.DeleteOrder(id)) return Request.CreateResponse(HttpStatusCode.OK, "Order Deleted");
            return Request.CreateResponse(HttpStatusCode.OK, "Failed to delete order");
        }

        [HttpPost, Route("api/order/add")]
        public HttpResponseMessage AddOrder(OrderDetailsModel obj)
        {
            if (buyerService.AddOrder(obj)) return Request.CreateResponse(HttpStatusCode.OK, "Order added");
            return Request.CreateResponse(HttpStatusCode.OK, "Failed to add order");
        }

        [HttpPost]
        [Route("api/order/edit")]
        public HttpResponseMessage UpdateOrder(OrderDetailsModel obj)
        {
            if (buyerService.UpdateOrder(obj)) return Request.CreateResponse(HttpStatusCode.OK, "Order Updated!");
            return Request.CreateResponse(HttpStatusCode.OK, "Failed to update Order");
        }
    }
}
