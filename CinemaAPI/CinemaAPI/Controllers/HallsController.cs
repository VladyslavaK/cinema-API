using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common;
using Common.Interfaces;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CinemaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HallsController : ControllerBase
    {
        private ICRUD<Hall> _hallsService;

        public HallsController(ICRUD<Hall> hallsService)
        {
            _hallsService = hallsService;
        }

        // GET: api/Halls
        [HttpGet]
        public async Task<IEnumerable<Hall>> Get()
        {
            return await _hallsService.GetAsync();
        }

        // GET: api/Halls/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Hall>> Get(int id)
        {
            return await _hallsService.GetAsync(new ID(id));
        }

        // POST: api/Halls
        [HttpPost]
        public async Task<ID> Post([FromBody] Hall hall)
        {
            return await _hallsService.InsertAsync(hall);
        }

        // PUT: api/Halls/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Hall hall)
        {
            hall.HallID = new ID(id);
            await _hallsService.UpdateAsync(hall);
        }

        // DELETE: api/Halls/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _hallsService.DeleteAsync(new ID(id));
        }
    }
}
