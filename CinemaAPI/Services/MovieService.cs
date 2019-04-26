using Common;
using Common.Interfaces;
using Domain;
using Infrastructure.Context;
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
            _context.Movies.Remove(new Movie { MovieID = id });
            await _context.SaveChangesAsync();
        }

        public async Task<Movie> GetAsync(ID id)
        {
            return await _context.Movies.FindAsync(new Movie { MovieID = id });
        }

        public List<Movie> Get()
        {
            return _context.Movies.ToList();
        }

        public async Task<ID> InsertAsync(Movie item)
        {
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
