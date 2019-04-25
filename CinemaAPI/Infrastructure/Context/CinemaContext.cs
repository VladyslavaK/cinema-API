using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Context
{
    public class CinemaContext : DbContext
    {

        public CinemaContext(DbContextOptions<CinemaContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cinema>()
                .HasMany<Hall>(c => c.Halls);

            modelBuilder.Entity<Cinema>()
                .HasMany<Movie>(c => c.Movies);           
        }

        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Hall> Halls { get; set; }
        public DbSet<Movie> Movies { get; set; }

    }
}
