using CarDealer.Data;
using CarDealer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealer.Controllers
{
    public class InventoryController : Controller
    {
        public ActionResult Details()
        {
            ViewBag.Message = "Vehicle Details";

            return View();
        }

        public ActionResult New(CarSearchModel car)
        {
            Repository repo = new Repository();
            List<Car> cars = repo.SelectNewCars(car);
            return View(cars);
        }


        public ActionResult Used()
        {
            ViewBag.Message = "Used Inventory";

            return View();
        }
    }
}