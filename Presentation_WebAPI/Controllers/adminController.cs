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
    public class adminController : ApiController
    {
        [HttpPost]
        [Route("api/admin/delete/{id}")]
        public HttpResponseMessage DeleteAdmin(int id)
        {
            var isreq = adminService.DeleteAdmin(id);
            if (isreq) { return Request.CreateResponse(HttpStatusCode.OK, "Admin deleted!"); }
            return Request.CreateResponse(HttpStatusCode.OK, " failed!");
        }
        [HttpPost]
        [Route("api/admin/edit")]
        public HttpResponseMessage EditSeller(adminModel obj)
        {
            var isreq = adminService.EditAdmin(obj);
            if (isreq) { return Request.CreateResponse(HttpStatusCode.OK, "Data updated!"); }
            return Request.CreateResponse(HttpStatusCode.OK, "Update failed!");
        }
    }
}
