using SpringBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpringBlog.ViewModel
{
    public class ShowPostViewModel
    {
        public Post Post { get; set; }
        public CommentViewModel CommentViewModel { get; set; }
    }
}