using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    public class SizeController : Controller
    {
        private Size obj = new Size();
        // GET: Size
        public ActionResult SizeIndex()
        {
            return View();
        }
        public ActionResult AddEditSize()
        {
            return PartialView("_AddEdit");
        }
        public ActionResult SizeList()
        {

            return PartialView("_SizeList", obj.GetSize());

        }
        [HttpPost]
        public int Save(Size s)
        {
            obj.Save(s);
            return 1;
        }

        public ActionResult Edit(int id)
        {
            return View("_AddEdit", obj.Edit(id));
        }
        public ActionResult FormSize()
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