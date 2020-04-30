using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpringBlog.Controllers
{
    public class PostController : BaseController
    {
        // GET: article/sample-post-1
        [Route("article/{slug}")]
        public ActionResult Show(string slug)
        {
            var post = db.Posts.FirstOrDefault(x => x.Slug == slug);

            if (post == null)
            {
                return HttpNotFound();
            }

            return View(post);
        }
    }
}