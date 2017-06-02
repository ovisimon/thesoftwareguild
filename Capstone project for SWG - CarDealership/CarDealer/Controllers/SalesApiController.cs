using CarDealer.Data;
using CarDealer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CarDealer.Controllers
{
    public class SalesApiController : ApiController
    {
        [Route("sale")]
        [AcceptVerbs("POST")]
        public IHttpActionResult SelectAllCars(CarSearchModel car)
        {
            Repository repo = new Repository();
            List<Car> cars = repo.SelectAllCars(car);
            return Ok(cars);
        }

        [Route("purchase")]
        [AcceptVerbs("POST")]
        public IHttpActionResult PurchaseEntry(Purchase purchase)
        {
            purchase.Date = DateTime.Now;
            Repository repo = new Repository();
            repo.UpdateCarInventory(purchase.CarID);
            repo.PurchaseEntry(purchase);
            return Ok(repo.GetCarByID(purchase.CarID));
        }
    }
}
