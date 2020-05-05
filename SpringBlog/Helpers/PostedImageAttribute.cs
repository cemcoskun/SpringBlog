using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;

namespace SpringBlog.Helpers
{
    public class PostedImageAttribute : ValidationAttribute
    {
        public string AllowedExtensions { get; set; } = ".jpg, .jpeg, .png";

        public int MaxFileSizeMB { get; set; } = 1;

        public override bool IsValid(object value)
        {
            if (value == null || !(value is HttpPostedFileBase))
                return true;

            string[] allowedExtensions = AllowedExtensions.ToLower(CultureInfo.InvariantCulture)
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var image = (HttpPostedFileBase)value;

            var ext = Path.GetExtension(image.FileName);

            if (!image.ContentType.StartsWith("image/") || !allowedExtensions.Contains(ext.ToLower(CultureInfo.InvariantCulture)))
            {
                ErrorMessage = "Accepted file types: " + AllowedExtensions + ".";
                return false;
            }
            else if (image.ContentLength > MaxFileSizeMB * 1024 * 1024)
            {
                ErrorMessage = $"Max file size: {MaxFileSizeMB}MB.";
                return false;
            }

            return true;
        }
    }
}