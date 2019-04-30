using Common;
using Common.Interfaces;
using Common.Models;
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
            var cinema = await GetAsync(id);
            if (cinema != null)
            {
                _context.Cinemas.Remove(cinema);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Cinema> GetAsync(ID id)
        {
           return await _context.Cinemas.SingleOrDefaultAsync(c=>c.CinemaID.Value == id.Value);
        }

        public async Task<List<Cinema>> GetAsync()
        {
            return await _context.Cinemas.ToListAsync();
        }

        public async Task<ID> InsertAsync(Cinema item)
        {
            var latest = await _context.Cinemas.OrderByDescending(c => c.CinemaID.Value).FirstOrDefaultAsync();
            item.CinemaID = new ID(latest.CinemaID.Value+1);
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
