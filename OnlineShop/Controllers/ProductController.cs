using OnlineShop.ImageUploads;
using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    public class ProductController : Uploads
    {

        SubCategory SC = new SubCategory();
        Product p = new Product();
        // GET: Product


        public ActionResult IndexProductAdd()
        {
            return View();
        }
        public ActionResult productAdd()
        {
            return PartialView("_AddProducts");
        }
        public ActionResult GetForm(int? ProductId)
        {
            return PartialView("_AddProducts", p.Edit(ProductId));
        }

        public ActionResult GetSubCatogery(int CategoryId)
        {
            var list = SC.GetSubCategories(CategoryId);
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public ActionResult IndexProductList()
        {
            return View(p.GetProductAll());
        }
        [HttpPost]
        public int Save(Product product)
        {
            if (product.FileImage != null)
                product.Image = FileUpload(product.FileImage);
            product.Save(product);
            return 1;
        }
        public int Delete(int ProductId)
        {
            p.Delete(ProductId);
            return 1;
        }
    }
}