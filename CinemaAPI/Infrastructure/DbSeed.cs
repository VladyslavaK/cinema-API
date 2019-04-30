using Common.Models;
using Domain;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class DbSeed
    {
        public static void ConfigureContext(IServiceCollection services, string connString)
        {
            services.AddDbContext<CinemaContext>(c =>
            {
                c.UseSqlServer(connString)
                .ConfigureWarnings(warnings => warnings.Throw(CoreEventId.IncludeIgnoredWarning)); 
            });
        }

        public static async Task SeedAsync(IServiceProvider services)
        {
            var context = (CinemaContext)services
                .GetService(typeof(CinemaContext));
            using (context)
            {
                context.Database.EnsureCreated();
                if (!context.Cinemas.Any())
                {
                    context.Cinemas.AddRange(GetPredefinedCinemas());
                    context.Movies.AddRange(GetPredefinedMovies());
                    await context.SaveChangesAsync();

                }
            }
        }

        static IEnumerable<Cinema> GetPredefinedCinemas()
        {
            return new List<Cinema>()
            {
                new Cinema() { CinemaID = new ID(1), Name = "Multiplex", CinemaAddress = new Common.Models.Address("NY", "Manhattan", 12), OpenYear = 2010,
                    Halls = GetPredefinedHalls().ToList()}                
            };
        }

        static IEnumerable<Hall> GetPredefinedHalls()
        {
            return new List<Hall>()
            {
                new Hall() { HallID = new ID(1), Name = "Yellow", Capacity=120 },
                new Hall() { HallID = new ID(2), Name = "Green", Capacity=80 },
                new Hall() { HallID = new ID(3), Name = "Blue", Capacity=150 },
            };
        }

        static IEnumerable<Movie> GetPredefinedMovies()
        {
            return new List<Movie>()
            {
                new Movie() { MovieID = new ID(1), Name = "Aquaman", Director="Van" , Year=2019, AtTheBoxOffice = new DateRange("01/12/2018", "01/01/2019") }
            };
        }
    }
}
