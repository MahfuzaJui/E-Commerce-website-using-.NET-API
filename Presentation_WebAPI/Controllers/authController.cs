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
    public class authController : ApiController
    {
        [HttpPost]
        [Route("api/buyer/login")]
        public HttpResponseMessage Login(userModel u)
        {
            var data = UserService.Authenticate(u.username, u.password);
            if (data == null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Username Or Password Invalid");
            }
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [HttpGet]
        [Route("api/buyer/logout/{uid}")]
        public HttpResponseMessage Logout(int uid)
        {
            var data = UserService.Logout(uid);
            if (data == true)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Successfully Logged Out");
            }
            return Request.CreateResponse(HttpStatusCode.OK, "Already Loggedout");
        }

    }
}
