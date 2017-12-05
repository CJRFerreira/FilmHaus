using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using FilmHaus.Models;
using FilmHaus.Models.Base;
using FilmHaus.Models.Connector;

namespace FilmHaus.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<FilmHausDbContext>
    {
        private List<Film> Films { get; set; }

        private List<Show> Shows { get; set; }

        private List<List> Lists { get; set; }

        private List<Review> Reviews { get; set; }

        private List<Report> Reports { get; set; }

        private List<Genre> Genres { get; set; }

        private List<Person> People { get; set; }

        private List<Title> Titles { get; set; }

        private List<Tag> Tags { get; set; }

        private List<FilmPersonTitle> FilmPersonTitles { get; set; }

        private List<ShowPersonTitle> ShowPersonTitles { get; set; }

        private List<UserFilm> UserFilms { get; set; }

        private List<UserShow> UserShows { get; set; }

        private List<UserFilmRating> UserFilmRatings { get; set; }

        private List<UserShowRating> UserShowRatings { get; set; }

        private List<FilmTag> FilmTags { get; set; }

        private List<ShowTag> ShowTags { get; set; }

        private List<ListTag> ListTags { get; set; }

        private List<FilmGenre> FilmGenres { get; set; }

        private List<ShowGenre> ShowGenres { get; set; }

        private List<ListFilm> ListFilms { get; set; }

        private List<ListShow> ListShows { get; set; }

        private List<ReviewFilm> ReviewFilms { get; set; }

        private List<ReviewShow> ReviewShows { get; set; }

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(FilmHausDbContext context)
        {
            GenerateBaseData();
            GenerateConnectorData();
            // This method will be called after migrating to the latest version.

            // You can use the DbSet<T>.AddOrUpdate() helper extension method to avoid creating
            // duplicate seed data. E.g.
            //
            // context.People.AddOrUpdate( p => p.FullName, new Person { FullName = "Andrew Peters"
            // }, new Person { FullName = "Brice Lambson" }, new Person { FullName = "Rowan Miller" } );

            SeedModels(context);
        }

        private void SeedModels(FilmHausDbContext filmHausDbContext)
        {
            foreach (var film in Films)
                filmHausDbContext.Films.AddOrUpdate(film);

            foreach (var show in Shows)
                filmHausDbContext.Shows.AddOrUpdate(show);

            foreach (var list in Lists)
                filmHausDbContext.Lists.AddOrUpdate(list);

            foreach (var review in Reviews)
                filmHausDbContext.Reviews.AddOrUpdate(review);

            foreach (var report in Reports)
                filmHausDbContext.Reports.AddOrUpdate(report);

            foreach (var genre in Genres)
                filmHausDbContext.Genres.AddOrUpdate(genre);

            foreach (var title in Titles)
                filmHausDbContext.Titles.AddOrUpdate(title);

            foreach (var tag in Tags)
                filmHausDbContext.Tags.AddOrUpdate(tag);

            foreach (var person in People)
                filmHausDbContext.People.AddOrUpdate(person);

            foreach (var fpt in FilmPersonTitles)
                filmHausDbContext.FilmPersonTitles.AddOrUpdate(fpt);

            foreach (var spt in ShowPersonTitles)
                filmHausDbContext.ShowPersonTitles.AddOrUpdate(spt);

            foreach (var fg in FilmGenres)
                filmHausDbContext.FilmGenres.AddOrUpdate(fg);

            foreach (var sg in ShowGenres)
                filmHausDbContext.ShowGenres.AddOrUpdate(sg);

            foreach (var ft in FilmTags)
                filmHausDbContext.FilmTags.AddOrUpdate(ft);

            foreach (var st in ShowTags)
                filmHausDbContext.ShowTags.AddOrUpdate(st);

            foreach (var lf in ListFilms)
                filmHausDbContext.ListFilms.AddOrUpdate(lf);

            foreach (var ls in ListShows)
                filmHausDbContext.ListShows.AddOrUpdate(ls);

            foreach (var lt in ListTags)
                filmHausDbContext.ListTags.AddOrUpdate(lt);

            foreach (var rf in ReviewFilms)
                filmHausDbContext.ReviewFilms.AddOrUpdate(rf);

            foreach (var rs in ReviewShows)
                filmHausDbContext.ReviewShows.AddOrUpdate(rs);

            foreach (var uf in UserFilms)
                filmHausDbContext.UserFilms.AddOrUpdate(uf);

            foreach (var us in UserShows)
                filmHausDbContext.UserShows.AddOrUpdate(us);

            foreach (var ufr in UserFilmRatings)
                filmHausDbContext.UserFilmRatings.AddOrUpdate(ufr);

            foreach (var usr in UserShowRatings)
                filmHausDbContext.UserShowRatings.AddOrUpdate(usr);
        }

        private void GenerateConnectorData()
        {
            throw new NotImplementedException();
        }

        private void GenerateBaseData()
        {
            GenerateFilms();
            GenerateShows();
            GenerateLists();
            GenerateReviews();
            GenerateReports();
            GeneratePeople();
            GenerateGenres();
            GenerateTitles();
            GenerateTags();
        }

        private void GenerateFilms()
        {
        }

        private void GenerateShows()
        {
        }

        private void GenerateLists()
        {
        }

        private void GenerateReviews()
        {
        }

        private void GenerateReports()
        {
        }

        private void GenerateGenres()
        {
        }

        private void GenerateTags()
        {
        }

        private void GenerateTitles()
        {
        }

        private void GeneratePeople()
        {
        }
    }
}