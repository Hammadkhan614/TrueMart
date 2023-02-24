using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    public class UserHomeController : Controller
    {
        // GET: UserHome

        ViewModel vm = new ViewModel();
        Category cat = new Category();
        SubCategory Sub = new SubCategory();
        Product pr = new Product();
        Brands Br = new Brands();

        public ActionResult UserHomeIndex()
        {
            vm.Category = cat.GetCategories();
            vm.SubCategory = Sub.GetSubCategories();
            vm.Product = pr.GetProductAll();
            vm.Brand = Br.GetBrand();
            return View(vm);
        }
        public ActionResult SubCategory(int Id)
        {
            var Data = Sub.GetSubCategories(Id);
            return PartialView("_SubCategoryUser", Data);
        }
    }
}