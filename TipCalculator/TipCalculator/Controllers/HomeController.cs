using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TipCalculator.BLL;
using TipCalculator.Models;

namespace TipCalculator.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            Order order = new Order();
            return View(order);
        }

        [HttpPost]
        public ActionResult Index(Order order)
        {
            OrderManager manager = new OrderManager();
            order.Total = 0;

            manager.CalculateTotal(order);
            return View(order);
        }
    }
}