using OnlineShop.ImageUploads;
using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    public class BrandsController : Uploads
    {
        private Brands obj = new Brands();
        // GET: Brands
        public ActionResult BrandsIndex()
        {
            return View();
        }
      
       
        public ActionResult AddEditBrands()
        {
            return PartialView("_AddEdit");
        }
        public ActionResult BrandLists()
        {

            return PartialView("_BrandsList", obj.GetBrand());
        }
        [HttpPost]
        public int Save(Brands B)
        {
            if (B.FileImage != null)
                B.Image = FileUpload(B.FileImage);

            obj.Save(B);
            return 1;
        }

        public ActionResult Edit(int id)
        {
            return View("_AddEdit", obj.Edit(id));
        }
        public ActionResult FormBrands()
        {
            return View("_AddEdit", obj);
        }
        public int Delete(int id)
        {
            obj.Delete(id);
            return 1;
        }
    }
}