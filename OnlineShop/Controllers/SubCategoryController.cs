using OnlineShop.ImageUploads;
using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    public class SubCategoryController : Uploads
    {
        private SubCategory obj = new SubCategory();
        // GET: SubCategory
        public ActionResult SubCategoryIndex()
        {
            return View();
        }
        public ActionResult AddEditSubCategory()
        {
            return PartialView("_AddEdit");
        }
        public ActionResult SubCategoryList()
        {
            return PartialView("_SubCategoryList", obj.GetSubCategories());
        }

        [HttpPost]
        public int Save(SubCategory f)
        {
            if (f.FileImage != null)
                f.Image = FileUpload(f.FileImage);

            obj.Save(f);
            return 1;
        }

        public ActionResult Edit(int id)
        {
            return View("_AddEdit", obj.Edit(id));
        }
        public ActionResult FormSubCategory()
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