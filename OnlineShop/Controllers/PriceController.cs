using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    public class PriceController : Controller
    {
        // GET: Price
        Price Pr = new Price();

        
        public ActionResult PriceIndex()
        {
            return View();
        }

        public int Save(Price p)
        {
            p.Save(p);
            return 1;
        }
        public ActionResult GetFormPrice(int ProductId)

        {
            Pr.ProductId = ProductId;
            return PartialView("_Addprice", Pr);
        }

        public ActionResult ShowPrice(int ProductId)
        {

            return PartialView("_ShowPrice", Pr.GetPriceOne(ProductId));
        }

        public ActionResult ShowPrices()
        {
            return PartialView("_PriceList", Pr.GetPriceAll());
        }
    }
}