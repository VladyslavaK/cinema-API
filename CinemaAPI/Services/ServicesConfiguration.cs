using Common.Interfaces;
using Domain;
using Infrastructure;
using Infrastructure.Context;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public static class ServicesConfiguration
    {
        public static void ConfigureServices(IServiceCollection services, string connString)
        {
            DbSeed.ConfigureContext(services, connString);
            services.AddScoped(typeof(ICRUD<Cinema>), typeof(CinemaService));
            services.AddScoped(typeof(ICRUD<Hall>), typeof(HallService));
            services.AddScoped(typeof(ICRUD<Movie>), typeof(MovieService));
        }

    }
}
