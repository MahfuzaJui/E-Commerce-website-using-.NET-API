using BEL;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Presentation_WebAPI.Controllers
{
    public class sellerController : ApiController
    {
        [HttpPost]
        [Route("api/seller/delete/{id}")]
        public HttpResponseMessage DeleteSeller(int id)
        {
            var isreq = sellerService.DeleteSeller(id);
            if (isreq) { return Request.CreateResponse(HttpStatusCode.OK, "Seller deleted!"); }
            return Request.CreateResponse(HttpStatusCode.OK, " failed!");
        }
        [HttpPost]
        [Route("api/seller/edit")]
        public HttpResponseMessage EditSeller(sellerModel obj)
        {
            var isreq = sellerService.EditSeller(obj);
            if (isreq) { return Request.CreateResponse(HttpStatusCode.OK, "Data updated!"); }
            return Request.CreateResponse(HttpStatusCode.OK, "Update failed!");
        }

        [HttpGet]
        [Route("api/products")]

        public HttpResponseMessage ProductsAll()
        {
            var listProducts = sellerService.AllProducts();
            return Request.CreateResponse(HttpStatusCode.OK,listProducts);
        }

        [HttpPost]
        [Route("api/product/delete/{id}")]
        public HttpResponseMessage ProductDelete(int id)
        {
            var isreq = sellerService.DeleteProduct(id);
            if (isreq) { return Request.CreateResponse(HttpStatusCode.OK, "Product deleted"); }
            return Request.CreateResponse(HttpStatusCode.OK, "Failed to delete product");
        }

        [HttpPost]
        [Route ("api/product/edit")]
        public HttpResponseMessage EditProduct(ProductModel obj)
        {
            var isreq = sellerService.EditProduct(obj);
            if (isreq) { return Request.CreateResponse(HttpStatusCode.OK, "Data updated!"); }
            return Request.CreateResponse(HttpStatusCode.OK, "Failed to update Product!");
        }



        [HttpGet]
        [Route("api/sell")]

        public HttpResponseMessage SellAll()
        {
            var listProducts = sellerService.AllSell();
            return Request.CreateResponse(HttpStatusCode.OK, listProducts);
        }

        [HttpPost]
        [Route("api/sell/delete/{id}")]
        public HttpResponseMessage SellDelete(int id)
        {
            var isreq = sellerService.DeleteSell(id);
            if (isreq) { return Request.CreateResponse(HttpStatusCode.OK, "Deleted"); }
            return Request.CreateResponse(HttpStatusCode.OK, "Failed to delete");
        }

        [HttpPost]
        [Route("api/sell/edit")]
        public HttpResponseMessage EditSell(SellModel obj)
        {
            var isreq = sellerService.EditSell(obj);
            if (isreq) { return Request.CreateResponse(HttpStatusCode.OK, "Data updated!"); }
            return Request.CreateResponse(HttpStatusCode.OK, "Failed to update Details!");
        }



        [HttpGet]
        [Route("api/rent")]

        public HttpResponseMessage RentAll()
        {
            var listProducts = sellerService.AllRent();
            return Request.CreateResponse(HttpStatusCode.OK, listProducts);
        }

        [HttpPost]
        [Route("api/rent/delete/{id}")]
        public HttpResponseMessage RentDelete(int id)
        {
            var isreq = sellerService.DeleteRent(id);
            if (isreq) { return Request.CreateResponse(HttpStatusCode.OK, "Deleted"); }
            return Request.CreateResponse(HttpStatusCode.OK, "Failed to delete");
        }

        [HttpPost]
        [Route("api/rent/edit")]
        public HttpResponseMessage EditRent(RentModel obj)
        {
            var isreq = sellerService.EditRent(obj);
            if (isreq) { return Request.CreateResponse(HttpStatusCode.OK, "Data updated!"); }
            return Request.CreateResponse(HttpStatusCode.OK, "Failed to update Details!");
        }

        [HttpPost]
        [Route("api/product/add")]
        public HttpResponseMessage AddProduct(ProductModel obj)
        {
            bool flag = sellerService.AddProduct(obj);
            if (flag) { return Request.CreateResponse(HttpStatusCode.OK, "Product Added"); }
            else { return Request.CreateResponse(HttpStatusCode.OK, "Failed to add the product"); }
        }

    }
}
