using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpringBlog.Helpers
{
    public static class ImageUtilities
    {
        public static void DeleteImage(this Controller controller, string photoPath)
        {
            if (!string.IsNullOrEmpty(photoPath))
            {
                var absPhotoPath = Path.Combine(controller.Server.MapPath("~/Upload"), photoPath);

                if (System.IO.File.Exists(absPhotoPath))
                {
                    System.IO.File.Delete(absPhotoPath);
                }
            }
        }

        public static string SaveImage(this Controller controller, HttpPostedFileBase image)
        {
            if (image == null)
                return "";

            string directory = controller.Server.MapPath("~/Upload/");
            string fileName = Guid.NewGuid() + Path.GetExtension(image.FileName);
            string savePath = Path.Combine(directory, fileName);

            image.SaveAs(savePath);

            return fileName;
        }

        public static string FeaturedImage(this UrlHelper urlHelper, string photoPath)
        {
            if (string.IsNullOrEmpty(photoPath))
            {
                return urlHelper.Content("~/Images/noimage.png");
            }

            return urlHelper.Content("~/Upload/" + photoPath);
        }
    }
}