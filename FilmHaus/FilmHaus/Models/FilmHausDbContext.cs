using FilmHaus.Models.Base;
using FilmHaus.Models.Connector;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FilmHaus.Models
{
    public class FilmHausDbContext : IdentityDbContext<User>
    {
        public FilmHausDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static FilmHausDbContext Create()
        {
            return new FilmHausDbContext();
        }

        public DbSet<Film> Films { get; set; }

        public DbSet<UserFilm> UserFilms { get; set; }

        public DbSet<List> Lists { get; set; }

        public DbSet<Review> Reviews { get; set; }

        public DbSet<Report> Reports { get; set; }
    }
}