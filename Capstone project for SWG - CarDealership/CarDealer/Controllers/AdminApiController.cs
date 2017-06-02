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
    public class AdminApiController : ApiController
    {
        [Route("admin")]
        [AcceptVerbs("POST")]
        public IHttpActionResult SelectAllCars(CarSearchModel car)
        {
            Repository repo = new Repository();
            List<Car> cars = repo.SelectAllCars(car);
            return Ok(cars);
        }

        [Route("add")]
        [AcceptVerbs("POST")]
        public IHttpActionResult CarEntry(Car car)
        {
            Repository repo = new Repository();
            int carID = repo.CarEntry(car);
            int typeID;
            if(car.Mileage > 0)
            {
                typeID = 2;
            }else
            {
                typeID = 1;
            }
            repo.InsertCarBodyStyle(carID, car.BodyStyleID);
            repo.InsertCarType(carID, typeID);
            repo.InsertCarColor(carID, car.ColorID);
            repo.InsertCarInterior(carID, car.InteriorID);
            return Ok(car);
        }

        [Route("makes")]
        [AcceptVerbs("Get")]
        public IHttpActionResult GetMakes()
        {
            Repository repo = new Repository();
            repo.GetMakes();
            return Ok(repo.GetMakes());
        }

        [Route("models/{id}")]
        [AcceptVerbs("Get")]
        public IHttpActionResult GetModels(int id)
        {
            Repository repo = new Repository();
            return Ok(repo.GetModels(id));
        }

        [Route("mdls/{id}")]
        [AcceptVerbs("Get")]
        public IHttpActionResult GetMdls(string id)
        {
            Repository repo = new Repository();
            return Ok(repo.GetMdls(id));
        }

        [Route("edit")]
        [AcceptVerbs("PUT")]
        public IHttpActionResult CarEdit(Car car)
        {
            int typeID;
            if (car.Mileage > 0)
            {
                typeID = 2;
            }
            else
            {
                typeID = 1;
            }

            Repository repo = new Repository();
            repo.DeleteCarBodyStyle(car.CarID);
            repo.DeleteCarColor(car.CarID);
            repo.DeleteCarInterior(car.CarID);
            repo.DeleteCarType(car.CarID);

            repo.InsertCarBodyStyle(car.CarID, car.BodyStyleID);
            repo.InsertCarType(car.CarID, typeID);
            repo.InsertCarColor(car.CarID, car.ColorID);
            repo.InsertCarInterior(car.CarID, car.InteriorID);

            repo.CarEdit(car);

            return Ok(car);
        }

        [Route("delete/{id}")]
        [AcceptVerbs("DELETE")]
        public IHttpActionResult DeleteCar(int id)
        {
            Repository repo = new Repository();
            repo.DeleteCarBodyStyle(id);
            repo.DeleteCarColor(id);
            repo.DeleteCarInterior(id);
            repo.DeleteCarType(id);
            repo.DeleteCar(id);
            return Ok(id);
        }

        [Route("mkreport")]
        [AcceptVerbs("GET")]
        public IHttpActionResult MakeReport()
        {
            Repository repo = new Repository();
            List<MakeModel> makes = repo.MakeReport();
            return Ok(makes);
        }

        [Route("mdlreport")]
        [AcceptVerbs("GET")]
        public IHttpActionResult ModelReport()
        {
            Repository repo = new Repository();
            List<ModelModel> models = repo.ModelReport();
            return Ok(models);
        }

        [Route("mkcreate")]
        [AcceptVerbs("POST")]
        public IHttpActionResult CreateMake(MakeModel make)
        {
            Repository repo = new Repository();
            make.Date = DateTime.Now;
            repo.CreateMake(make);
            return Ok(make);
        }

        [Route("mdcreate")]
        [AcceptVerbs("POST")]
        public IHttpActionResult CreateModel(ModelModel model)
        {
            Repository repo = new Repository();
            model.Date = DateTime.Now;
            repo.CreateModel(model);
            return Ok(model);
        }

        [Route("specialadd")]
        [AcceptVerbs("POST")]
        public IHttpActionResult CreateSpecial(Special special)
        {
            Repository repo = new Repository();
            repo.CreateSpecial(special);
            return Ok(special);
        }

        [Route("specialdelete/{id}")]
        [AcceptVerbs("DELETE")]
        public IHttpActionResult DeleteSpecial(int id)
        {
            Repository repo = new Repository();
            repo.DeleteSpecial(id);
            return Ok(id);
        }
    }
}
