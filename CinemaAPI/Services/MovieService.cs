using Common;
using Common.Interfaces;
using Common.Models;
using Domain;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services
{
    public class MovieService : ICRUD<Movie>
    {
        private CinemaContext _context;
        public MovieService(CinemaContext context)
        {
            _context = context;
        }

        public async Task DeleteAsync(ID id)
        {
            var movie = await GetAsync(id);
            if (movie != null)
            {
                _context.Movies.Remove(movie);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Movie> GetAsync(ID id)
        {
            return await _context.Movies.SingleOrDefaultAsync(m => m.MovieID.Value == id.Value);
        }

        public async Task<List<Movie>> GetAsync()
        {
            return await _context.Movies.Include(m=> m.AtTheBoxOffice).ToListAsync();
        }

        public async Task<ID> InsertAsync(Movie item)
        {
            var latest = await _context.Movies.OrderByDescending(c => c.MovieID.Value).FirstOrDefaultAsync();
            item.MovieID = new ID(latest.MovieID.Value + 1);
            var movie = await _context.Movies.AddAsync(item);
            await _context.SaveChangesAsync();
            return movie.Entity.MovieID;
        }

        public async Task UpdateAsync(Movie item)
        {
            var id = _context.Movies.Update(item);
            await _context.SaveChangesAsync();
        }
    }
}
