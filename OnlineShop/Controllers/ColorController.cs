using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    public class ColorController : Controller
    {
   
        
            private Color obj = new Color();
            // GET: Color
            public ActionResult ColorIndex()
            {
                return View();
            }
            public ActionResult AddEditColor()
            {
                return PartialView("_AddEdit");
            }
            public ActionResult ColorList()
            {

                return PartialView("_ColorList", obj.GetColor());
            }
            [HttpPost]
            public int Save(Color C)
            {
                obj.Save(C);
                return 1;
            }

            public ActionResult Edit(int id)
            {
                return View("_AddEdit", obj.Edit(id));
            }
            public ActionResult FormColor()
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