using FilmHaus.Models.Base;
using FilmHaus.Models.Connector;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

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

        public DbSet<List> Lists { get; set; }

        public DbSet<Review> Reviews { get; set; }

        public DbSet<Report> Reports { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Person> Persons { get; set; }

        public DbSet<Title> Titles { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<FilmPersonTitle> FilmPersonTitles { get; set; }

        public DbSet<ShowPersonTitle> ShowPersonTitles { get; set; }

        public DbSet<UserFilm> UserFilms { get; set; }

        public DbSet<UserShow> UserShows { get; set; }

        public DbSet<FilmTag> FilmTags { get; set; }

        public DbSet<ShowTag> ShowTags { get; set; }

        public DbSet<FilmGenre> FilmGenres { get; set; }

        public DbSet<ShowGenre> ShowGenres { get; set; }

        public DbSet<ListFilm> ListFilms { get; set; }

        public DbSet<ListShow> ListShows { get; set; }

        public DbSet<ListTag> ListTags { get; set; }
    }
}