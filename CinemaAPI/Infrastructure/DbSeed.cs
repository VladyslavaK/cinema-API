using Domain;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
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
                c.UseSqlServer(connString);
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
                    context.Cinemas.AddRange(
                        GetPredefinedCinemas());
                    await context.SaveChangesAsync();
                }
            }
        }

        static IEnumerable<Cinema> GetPredefinedCinemas()
        {
            return new List<Cinema>()
            {
                new Cinema() { CinemaID = new Common.ID(1), Name = "Grande Hall", Address="NY", OpenYear = 2010 }                
            };
        }
    }
}
