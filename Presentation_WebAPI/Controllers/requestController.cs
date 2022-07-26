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
    public class requestController : ApiController
    {
        [HttpPost]
        [Route("api/request/add")]
        public HttpResponseMessage RequestAdd(requestModel obj)
        {
            var isreq = requestService.AddRequest(obj);
            if (isreq) { return Request.CreateResponse(HttpStatusCode.OK, "Request posted!"); }
            return Request.CreateResponse(HttpStatusCode.OK, "Request posted failed!");
        }

        [HttpPost]
        [Route("api/request/delete/{id}")]
        public HttpResponseMessage RequestDelete(int id)
        {
            var isreq = requestService.DeleteRequest(id);
            if (isreq) { return Request.CreateResponse(HttpStatusCode.OK, "Request deleted!"); }
            return Request.CreateResponse(HttpStatusCode.OK, "Request deleted failed!");
        }

        [HttpPost]
        [Route("api/request/edit")]
        public HttpResponseMessage RequestEdit(requestModel obj)
        {
            var isreq = requestService.EditRequest(obj);
            if (isreq) { return Request.CreateResponse(HttpStatusCode.OK, "Request data updated!"); }
            return Request.CreateResponse(HttpStatusCode.OK, "Update failed!");
        }

        [HttpGet]
        [Route("api/request/all")]
        public HttpResponseMessage RequestAll()
        {
            var listDt = requestService.AllRequest();
            return Request.CreateResponse(HttpStatusCode.OK, listDt);
        }
    }
}
