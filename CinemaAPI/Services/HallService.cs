
using Common;
using Common.Interfaces;
using Domain;
using Infrastructure.Context;
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
            _context.Halls.Remove(new Hall { HallID = id });
            await _context.SaveChangesAsync();
        }

        public async Task<Hall> GetAsync(ID id)
        {
            return await _context.Halls.FindAsync(new Hall { HallID = id });
        }

        public List<Hall> Get()
        {
            return _context.Halls.ToList();
        }

        public async Task<ID> InsertAsync(Hall item)
        {
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
