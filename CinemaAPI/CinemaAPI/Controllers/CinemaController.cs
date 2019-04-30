using System.Collections.Generic;
using System.Threading.Tasks;
using Common;
using Common.Interfaces;
using Common.Models;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace CinemaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CinemaController : ControllerBase
    {
        private ICRUD<Cinema> _cinemaService;

        public CinemaController(ICRUD<Cinema> cinemaService)
        {
            _cinemaService = cinemaService;
        }

        // GET: api/Cinema
        [HttpGet]
        public async Task<IEnumerable<Cinema>> Get()
        {
            return await _cinemaService.GetAsync();
        }

        // GET: api/Cinema/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cinema>> Get(int id)
        {
            var item =  await _cinemaService.GetAsync(new ID(id));
            if (item != null)
                return item;
            return NotFound();

        }

        // POST: api/Cinema
        [HttpPost]
        public async Task<ID> Post([FromBody] Cinema cinema)
        {
           return await _cinemaService.InsertAsync(cinema);
        }

        // PUT: api/Cinema/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Cinema cinema)
        {
            cinema.CinemaID = new ID(id);
            await _cinemaService.UpdateAsync(cinema);
        }

        // DELETE: api/Cinema/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _cinemaService.DeleteAsync(new ID(id));
        }
    }
}
