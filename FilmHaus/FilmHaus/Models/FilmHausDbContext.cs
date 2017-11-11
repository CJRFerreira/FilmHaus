using FilmHaus.Models.Base;
using FilmHaus.Models.Connector;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations.Schema;
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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Report>()
                    .HasRequired(m => m.ReportingUser)
                    .WithMany(t => t.AsReporter)
                    .HasForeignKey(m => m.ReportingUserId)
                    .WillCascadeOnDelete(false);

            modelBuilder.Entity<Report>()
                        .HasRequired(m => m.UserReported)
                        .WithMany(t => t.AsReportee)
                        .HasForeignKey(m => m.UserReportedId)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<Media>()
                .Property(m => m.MediaId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            modelBuilder.Entity<Film>().Map(f =>
            {
                f.MapInheritedProperties();
                f.ToTable("Films");
            });

            modelBuilder.Entity<Show>().Map(s =>
            {
                s.MapInheritedProperties();
                s.ToTable("Shows");
            });

            modelBuilder.Entity<Detail>()
                .Property(d => d.DetailId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            modelBuilder.Entity<Genre>().Map(g =>
            {
                g.MapInheritedProperties();
                g.ToTable("Genres");
            });

            modelBuilder.Entity<Tag>().Map(t =>
            {
                t.MapInheritedProperties();
                t.ToTable("Tags");
            });

            modelBuilder.Entity<Title>().Map(t =>
            {
                t.MapInheritedProperties();
                t.ToTable("Titles");
            });
        }

        public DbSet<Film> Films { get; set; }

        public DbSet<Show> Shows { get; set; }

        public DbSet<Media> Media { get; set; }

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

        public DbSet<UserFilmRating> UserFilmRatings { get; set; }

        public DbSet<UserShowRating> UserShowRatings { get; set; }

        public DbSet<FilmTag> FilmTags { get; set; }

        public DbSet<ShowTag> ShowTags { get; set; }

        public DbSet<FilmGenre> FilmGenres { get; set; }

        public DbSet<ShowGenre> ShowGenres { get; set; }

        public DbSet<ListFilm> ListFilms { get; set; }

        public DbSet<ListShow> ListShows { get; set; }

        public DbSet<ReviewFilm> ReviewFilms { get; set; }

        public DbSet<ReviewShow> ReviewShows { get; set; }

    }
}