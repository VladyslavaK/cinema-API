using Common;
using Common.Models;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
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

            var idConverter = new ValueConverter<ID, Int32>(
                                v => v.Value,
                                v => new ID(v));

            modelBuilder.Entity<Cinema>()
                .Property(p => p.CinemaID)
                .HasConversion(idConverter)
                .IsRequired();

            modelBuilder.Entity<Hall>()
                .Property(p => p.HallID)
                .HasConversion(idConverter)
                .IsRequired();

            modelBuilder.Entity<Movie>()
                .Property(p => p.MovieID)
                .HasConversion(idConverter)
                .IsRequired();

            modelBuilder.Entity<Movie>().OwnsOne(m => m.AtTheBoxOffice).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Cinema>().OwnsOne(c => c.CinemaAddress).OnDelete(DeleteBehavior.Cascade);
        }

        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Hall> Halls { get; set; }
        public DbSet<Movie> Movies { get; set; }

    }
}
