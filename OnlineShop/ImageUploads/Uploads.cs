using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.ImageUploads
{
    public class Uploads: Controller
    {
       

        public string FileUpload(HttpPostedFileBase file)
        {
            string ext = Path.GetExtension(file.FileName);
            string Filename = "OnlineShopping" + DateTime.Now.ToString("yyyymmddhhmmss") + ext;
            string path = "~/Uploads/" + Filename;
            string targetpath = Server.MapPath(path);
            file.SaveAs(targetpath);
            string domainname = HttpContext.Request.Url.GetLeftPart(UriPartial.Authority);
            return domainname + "/Uploads/" + Filename;
        }
    }
}