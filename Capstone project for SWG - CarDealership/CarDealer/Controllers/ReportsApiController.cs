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
    public class ReportsApiController : ApiController
    {
        [Route("newreports")]
        [AcceptVerbs("GET")]
        public IHttpActionResult NewInventoryReport()
        {
            Repository repo = new Repository();
            List<Report> reports = repo.NewInventoryReport();
            return Ok(reports);
        }

        [Route("usedreports")]
        [AcceptVerbs("GET")]
        public IHttpActionResult UsedInventoryReport()
        {
            Repository repo = new Repository();
            List<Report> reports = repo.UsedInventoryReport();
            return Ok(reports);
        }

        [Route("salesrep")]
        [AcceptVerbs("POST")]
        public IHttpActionResult SalesReport(SalesReport rep)
        {
            Repository repo = new Repository();
            List<SalesReport> reports = repo.SalesReport(rep);
            return Ok(reports);
        }
    }
}
