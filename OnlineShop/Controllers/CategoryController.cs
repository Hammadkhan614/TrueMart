using OnlineShop.ImageUploads;
using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    public class CategoryController : Uploads
    {
        private Category obj = new Category();

        // GET: Category
        public ActionResult CategoryIndex()
        {
            return View();
        }
        public ActionResult CategoryAddEdit()
        {
            return PartialView("_AddEdit");
        }
        public ActionResult CategoryList()
        {
            return PartialView("_CategoryList",obj.GetCategories());
        }
       
        [HttpPost]
        public int Save(Category f)
        {
            if (f.FileImage != null)
                f.CategoryImage = FileUpload(f.FileImage);

            obj.Save(f);
            return 1;
        }

        public ActionResult Edit(int id)
        {
            return View("_AddEdit", obj.Edit(id));
        }
        public ActionResult FormCategory()
        {
            return View("_AddEdit", obj);
        }
        public int Delete(int id)
        {
            obj.Delete(id);
            return 1;
        }
        public ActionResult ShowDescription(int Id)
        {
            var data = obj.ShowDescription(Id);
            return PartialView("_ShowDescription", data);
        }
       

    }
}