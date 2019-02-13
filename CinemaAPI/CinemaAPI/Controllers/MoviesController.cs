using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace CinemaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        // GET api/movies
        [HttpGet]
        public ActionResult<IEnumerable<Movie>> Get()
        {
            return new Movie[10]; 
        }

        // GET api/movies/5
        [HttpGet("{id}")]
        public ActionResult<Movie> Get(int id)
        {
            return new Movie();
        }

        // POST api/movies
        [HttpPost]
        public void Post([FromBody] Movie movie)
        {
        }

        // PUT api/movies/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Movie movie)
        {
        }

        // DELETE api/movies/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
