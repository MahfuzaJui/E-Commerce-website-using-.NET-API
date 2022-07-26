using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using BLL.Services;

namespace Presentation_WebAPI.Auth
{
    public class BuyerAuth : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var authHeader = actionContext.Request.Headers.Authorization;
            if (authHeader == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.NotFound, new { message = "No Token Supplied" });

            }
            else
            {
                string token = authHeader.ToString();
                var rs = UserService.BuyerIsAuthenticated(token);
                if (!rs)
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized, new { message = "Unauthorized Access" });
                }
            }
            base.OnAuthorization(actionContext);
        }
    }
}