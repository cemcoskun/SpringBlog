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
        [Route("p/{id}/{slug?}")]
        public ActionResult Show(int id, string slug)
        {
            var post = db.Posts.Find(id);

            if (post == null)
            {
                return HttpNotFound();
            }

            if (post.Slug != slug)
            {
                return RedirectToAction("Show", new { id = id, slug = post.Slug });
            }

            return View(post);
        }
    }
}