using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Part_Of_Project.Controllers
{
    public static class Utility
    {
        public static void SaveImage(HttpPostedFile image, string folderName)
        {
            string folderPath = HttpContext.Current.Server.MapPath(@"~\images");
            string completePath = Path.Combine(folderPath, folderName, image.FileName);
            image.SaveAs(completePath);
        }
    }
}