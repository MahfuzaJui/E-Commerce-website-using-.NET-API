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
    public class postController : ApiController
    {
        [HttpPost]
        [Route("api/post/add")]
        public HttpResponseMessage AddPost(postModel obj)
        {
            var isreq = postService.AddPost(obj);
            if (isreq) { return Request.CreateResponse(HttpStatusCode.OK, "Post added!"); }
            return Request.CreateResponse(HttpStatusCode.OK, "Post failed!");
        }
        [HttpPost]
        [Route("api/post/delete/{id}")]
        public HttpResponseMessage DeletePost(int id)
        {
            var isreq = postService.DeletePost(id);
            if (isreq) { return Request.CreateResponse(HttpStatusCode.OK, "Post deleted!"); }
            return Request.CreateResponse(HttpStatusCode.OK, "Post failed!");
        }
        [HttpPost]
        [Route("api/post/edit")]
        public HttpResponseMessage RequestEdit(postModel obj)
        {
            var isreq = postService.EditPost(obj);
            if (isreq) { return Request.CreateResponse(HttpStatusCode.OK, "Data updated!"); }
            return Request.CreateResponse(HttpStatusCode.OK, "Update failed!");
        }
    }
}
