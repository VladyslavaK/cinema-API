using Common;
using Common.Interfaces;
using Domain;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CinemaService : ICRUD<Cinema>
    {
        private CinemaContext _context;
        public CinemaService(CinemaContext context)
        {
            _context = context;
        }

        public async Task DeleteAsync(ID id)
        {
            _context.Cinemas.Remove(new Cinema { CinemaID = id });
            await _context.SaveChangesAsync();
        }

        public async Task<Cinema> GetAsync(ID id)
        {
           return await _context.Cinemas.FindAsync( new Cinema { CinemaID = id });
        }

        public async Task<List<Cinema>> GetAsync()
        {
            return await _context.Cinemas.ToListAsync();
        }

        public async Task<ID> InsertAsync(Cinema item)
        {
            var cinema = await _context.Cinemas.AddAsync(item);
            await _context.SaveChangesAsync();
            return cinema.Entity.CinemaID;
        }

        public async Task UpdateAsync(Cinema item)
        {
            var id = _context.Cinemas.Update(item);
            await _context.SaveChangesAsync();
        }
    }
}
