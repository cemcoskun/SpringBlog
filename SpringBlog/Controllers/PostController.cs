using Microsoft.AspNet.Identity;
using SpringBlog.Models;
using SpringBlog.ViewModel;
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

            var vm = new ShowPostViewModel
            {
                Post = post,
                CommentViewModel = new CommentViewModel()
            };

            return View(vm);
        }

        [Route("p/{id}/{slug?}")]
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Show(int id, string slug, CommentViewModel commentViewModel)
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

            if (ModelState.IsValid)
            {
                var comment = new Comment
                {
                    AuthorId = User.Identity.GetUserId(),
                    Content = commentViewModel.Content,
                    ParentId = commentViewModel.ParentId,
                    CreationTime = DateTime.Now,
                    ModificationTime = DateTime.Now,
                    State = Enums.CommentState.Approved,
                    PostId = id,
                };
                db.Comments.Add(comment);
                db.SaveChanges();
                return Redirect(Url.RouteUrl(
                    new { 
                        controller = "Post", 
                        action = "Show",
                        id = id,
                        slug = slug, 
                        commentSuccess = true })
                    + "#leave-a-comment");
            }

            var vm = new ShowPostViewModel
            {
                Post = post,
                CommentViewModel = commentViewModel
            };

            return View(vm);
        }
    }
}