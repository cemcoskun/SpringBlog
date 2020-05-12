using SpringBlog.Areas.Admin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpringBlog.Areas.Admin.Controllers
{
    public class DashboardController : AdminBaseController
    {
        // GET: Admin/Dashboard
        public ActionResult Index()
        {
            var vm = new DashboardViewModel
            {
                CategoryCount = db.Categories.Count(),
                PostCount = db.Posts.Count(),
                UserCount = db.Users.Count(),
                CommentCount = db.Comments.Count()
            };
            return View(vm);
        }
    }
}