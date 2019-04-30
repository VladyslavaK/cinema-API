
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
    public class HallService : ICRUD<Hall>
    {
        private CinemaContext _context;
        public HallService(CinemaContext context)
        {
            _context = context;
        }

        public async Task DeleteAsync(ID id)
        {
            var hall = await GetAsync(id);
            if (hall != null)
            {
                _context.Halls.Remove(hall);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Hall> GetAsync(ID id)
        {
            return await _context.Halls.SingleOrDefaultAsync(h => h.HallID.Value == id.Value); 
        }

        public async Task<List<Hall>> GetAsync()
        {
            return await _context.Halls.ToListAsync();
        }

        public async Task<ID> InsertAsync(Hall item)
        {
            var latest = await _context.Halls.OrderByDescending(c => c.HallID.Value).FirstOrDefaultAsync();
            item.HallID = new ID(latest.HallID.Value + 1);
            var hall = await _context.Halls.AddAsync(item);
            await _context.SaveChangesAsync();
            return hall.Entity.HallID;
        }

        public async Task UpdateAsync(Hall item)
        {
            var id = _context.Halls.Update(item);
            await _context.SaveChangesAsync();
        }
    }
}
