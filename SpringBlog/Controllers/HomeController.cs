using SpringBlog.Models;
using SpringBlog.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using X.PagedList;

namespace SpringBlog.Controllers
{
    public class HomeController : BaseController
    {
        [Route("", Order = 2, Name = "HomeDefault")]
        [Route("c/{cid}/{slug}", Order = 1)]
        public ActionResult Index(string q, int? cid, string slug, int page=1)
        {
            var pageSize = 10;
            IQueryable<Post> posts = db.Posts;
            Category category = null;
            if (q != null)
            {
                posts = posts.Where(x => x.Category.CategoryName.Contains(q)
                || x.Title.Contains(q)
                || x.Content.Contains(q));
            }
            if (cid != null && q == null)
            {
                category = db.Categories.Find(cid);
                if (category == null)
                {
                    return HttpNotFound();
                }
                
                posts = posts.Where(x => x.CategoryId == cid);
            }
            var vm = new HomeIndexViewModel
            {
                Posts = posts.OrderByDescending(x => x.CreationTime).ToPagedList(page, pageSize),
                Category = category,
                SearchTerm = q,
                CategoryId = cid
            };

            return View(vm);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult CategoriesPartial()
        {
            return PartialView("_CategoriesPartial", 
            db.Categories.OrderBy(x => x.CategoryName).ToList());
        }
    }
}