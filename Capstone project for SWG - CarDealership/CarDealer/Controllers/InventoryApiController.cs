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
    public class InventoryApiController : ApiController
    {
        [Route("new")]
        [AcceptVerbs("POST")]
        public IHttpActionResult New(CarSearchModel car)
        {
            Repository repo = new Repository();
            List<Car> cars = repo.SelectNewCars(car);
            return Ok(cars);
        }

        [Route("used")]
        [AcceptVerbs("POST")]
        public IHttpActionResult Used(CarSearchModel car)
        {
            Repository repo = new Repository();
            List<Car> cars = repo.SelectUsedCars(car);
            return Ok(cars);
        }

        [Route("details/{id}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult Details(int id)
        {
            Repository repo = new Repository();
            Car car = repo.GetCarByID(id);
            return Ok(car);
        }
    }
}
