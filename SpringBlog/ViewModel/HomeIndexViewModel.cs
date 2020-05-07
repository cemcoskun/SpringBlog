using X.PagedList;
using SpringBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpringBlog.ViewModel
{
    public class HomeIndexViewModel
    {
        public IPagedList<Post> Posts { get; set; }
        public Category Category { get; set; }
        public string SearchTerm { get; set; }
        public int? CategoryId { get; set; }

    }
}