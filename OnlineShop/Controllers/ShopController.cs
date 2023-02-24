using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    public class ShopController : Controller
    {
        // GET: Shop
        SubCategory SUB = new SubCategory();
        Category CT = new Category();
        ViewModel user = new ViewModel();

        public ActionResult ShopIndex()
        {
            user.Category = CT.GetCategories();
            user.SubCategory = SUB.GetSubCategories();
            return View(user);
        }

    }
}