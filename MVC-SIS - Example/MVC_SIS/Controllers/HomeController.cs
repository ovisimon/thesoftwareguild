using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Exercises.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult Index()
        //{
        //    if (ModelState.IsValid)
        //    {
        //        // here we would save the appointment to a database
        //        return View("Confirmation");
        //    }
        //    else
        //    {
        //        // send them back to the entry form
        //        return View("Index");
        //    }

        //    return View();
        //}
    }
}