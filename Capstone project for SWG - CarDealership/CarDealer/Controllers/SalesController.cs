using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealer.Controllers
{
    public class SalesController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Sales";
            return View();
        }

        public ActionResult Purchase()
        {
            ViewBag.Message = "Purchase Vehicle";
            return View();
        }
    }
}