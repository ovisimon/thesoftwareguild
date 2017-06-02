using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealer.Controllers
{
    public class ReportsController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Reports";

            return View();
        }

        public ActionResult Inventory()
        {
            ViewBag.Message = "Inventory";

            return View();
        }

        public ActionResult SalesRp()
        {
            ViewBag.Message = "Sales";

            return View();
        }
    }
}