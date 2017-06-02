using DVDLibraryADONET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DVDLibraryADONET.Controllers
{
    public class MovieController : ApiController
    {
        IMovieRepository _repo;

        public MovieController(IMovieRepository repo)
        {
            _repo = repo;
        }

        [Route("dvds")]
        [AcceptVerbs("GET")]
        public IHttpActionResult All()
        {
            return Ok(_repo.GetAll());
        }


        [Route("dvds/{category}/{term}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetSpecific(string category, string term)
        {
            return Ok(_repo.GetSpecific(category, term));
        }

        [Route("dvds/{id}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetSpecific(int id)
        {
            return Ok(_repo.GetById(id));
        }

        [Route("dvds")]
        [AcceptVerbs("POST")]
        public IHttpActionResult Add(Movie movie)
        {
            _repo.AddDVD(movie);
            return Ok(movie);
        }

        [Route("dvds")]
        [AcceptVerbs("PUT")]
        public IHttpActionResult Edit(Movie movie)
        {
            _repo.EditDVD(movie);
            return Ok(movie);
        }

        [Route("dvd/{id}")]
        [AcceptVerbs("DELETE")]
        public IHttpActionResult Delete(int id)
        {
            _repo.DeleteDVD(id);
            return Ok();
        }
    }
}
