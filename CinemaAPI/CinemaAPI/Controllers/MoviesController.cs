using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common;
using Common.Interfaces;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace CinemaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private ICRUD<Movie> _movieService;

        public MoviesController(ICRUD<Movie> movieService)
        {
            _movieService = movieService;
        }

        // GET api/movies
        [HttpGet]
        public ActionResult<IEnumerable<Movie>> Get()
        {
            return _movieService.Get(); 
        }

        // GET api/movies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> Get(int id)
        {
            return await _movieService.GetAsync(new ID(id));
        }

        // POST api/movies
        [HttpPost]
        public async Task<ID> Post([FromBody] Movie movie)
        {
            return await _movieService.InsertAsync(movie);
        }

        // PUT api/movies/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Movie movie)
        {
            movie.MovieID = new ID(id);
            await _movieService.UpdateAsync(movie);
        }

        // DELETE api/movies/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _movieService.DeleteAsync(new ID(id));
        }
    }
}
