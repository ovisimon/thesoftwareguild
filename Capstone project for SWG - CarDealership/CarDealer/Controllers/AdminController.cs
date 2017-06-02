using CarDealer.Data;
using CarDealer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealer.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult AddUser()
        {
            ViewBag.Message = "Add User";

            return View();
        }

        public ActionResult AddVehicle()
        {
            ViewBag.Message = "Add Vehicle";

            return View();
        }

        public ActionResult EditUser()
        {
            ViewBag.Message = "Edit User";

            return View();
        }

        public ActionResult EditVehicle()
        {
            ViewBag.Message = "edit Vehicle";

            return View();
        }

        public ActionResult Makes()
        {
            ViewBag.Message = "Makes";

            return View();
        }

        public ActionResult Models()
        {
            ViewBag.Message = "Models";

            return View();
        }

        public ActionResult Specials()
        {
            ViewBag.Message = "Specials";

            return View();
        }

        public ActionResult Users()
        {
            ViewBag.Message = "Users";

            return View();
        }

        public ActionResult Vehicles()
        {
            ViewBag.Message = "Vehicles";

            return View();
        }

        public ActionResult SpecialsAd()
        {
            ViewBag.Message = "Specials";

            Repository repo = new Repository();

            List<Special> specials = repo.GetSpecials();

            return View(specials);
        }
    }
}