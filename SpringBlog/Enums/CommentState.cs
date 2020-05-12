using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SpringBlog.Enums
{
    public enum CommentState
    {
        [Display(Name = "Pending Review")]
        Pending = 0,
        [Display(Name = "Published")]
        Approved = 1,
        [Display(Name = "Not Published")]
        Rejected = 2
    }
}