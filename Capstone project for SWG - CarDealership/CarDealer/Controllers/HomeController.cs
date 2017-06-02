using CarDealer.Data;
using CarDealer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealer.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            Repository repo = new Repository();

            List<Car> cars = repo.GetFeaturedCars();

            return View(cars);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact Us";

            return View();
        }

        public ActionResult Specials()
        {
            ViewBag.Message = "Specials";

            Repository repo = new Repository();

            List<Special> specials = repo.GetSpecials();

            return View(specials);
        }
    }
}