using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    public class UnitController : Controller
    {
        private Unit obj = new Unit();
        // GET: Unit
        public ActionResult UnitIndex()
        {
            return View();
        }
        public ActionResult AddEditUnit()
        {
            return PartialView("_AddEdit");
        }
        public ActionResult UnitList()
        {

            return PartialView("_UnitList", obj.GetUnit());
        }
        [HttpPost]
        public int Save(Unit U)
        {

            obj.Save(U);
            return 1;
        }

        public ActionResult Edit(int id)
        {
            return View("_AddEdit", obj.Edit(id));
        }
        public ActionResult FormUnit()
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