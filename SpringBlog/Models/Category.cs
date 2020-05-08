using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SpringBlog.Models
{
    public class Category
    {
        public int Id { get; set; }
       
        [Required]
        [StringLength(30)]
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }

        [Required]
        [Display(Name = "Short Url")]
        [StringLength(30)]
        public string Slug { get; set; }
        
        public virtual ICollection<Post> Posts { get; set; }
        
    }
}