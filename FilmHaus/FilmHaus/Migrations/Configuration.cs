using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using FilmHaus.Enums;
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

            SeedBaseModels(context);
            SeedConnectorModels(context);
        }

        private void SeedConnectorModels(FilmHausDbContext filmHausDbContext)
        {
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

        private void SeedBaseModels(FilmHausDbContext filmHausDbContext)
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
        }

        private void GenerateConnectorData()
        {
            GenerateFilmGenres();
            GenerateShowGenres();
            GenerateFilmTags();
            GenerateShowTags();
            GenerateFilmPersonTitles();
            GenerateShowPersonTitles();
        }

        private void GenerateFilmPersonTitles()
        {
            FilmPersonTitles.Add(new FilmPersonTitle
            {
                FilmPersonTitleId = Guid.Parse("D98840C6-8259-44A1-8B17-99665E275DBA"),
                MediaId = Guid.Parse("3B14C9FF-E104-4847-B243-F1ADE305363C"),
                PersonId = Guid.Parse("0A0EF19C-D9D9-4A2C-925A-0D766D28DE74"),
                DetailId = Guid.Parse("2B639A0E-DCA1-4455-9FA4-FCC6EE1827B4")
            });

            FilmPersonTitles.Add(new FilmPersonTitle
            {
                FilmPersonTitleId = Guid.Parse("ABF18B2A-1F12-4746-A39F-7D0882859477"),
                MediaId = Guid.Parse("3B14C9FF-E104-4847-B243-F1ADE305363C"),
                PersonId = Guid.Parse("9DB6C69E-AE5F-4522-B358-91177B6A103E"),
                DetailId = Guid.Parse("D74FF8E0-8333-46C7-B3BB-DC52C0D5C09C")
            });
        }

        private void GenerateShowPersonTitles()
        {
            ShowPersonTitles.Add(new ShowPersonTitle
            {
                ShowPersonTitleId = Guid.Parse("27E81D62-B700-4437-93D5-4FD037F1F3AE"),
                MediaId = Guid.Parse("387271A1-4009-4667-BC49-5053BBC8E841"),
                PersonId = Guid.Parse("83ED21CF-04E4-4DA3-81A8-A6816E2BE91E"),
                DetailId = Guid.Parse("2B639A0E-DCA1-4455-9FA4-FCC6EE1827B4")
            });

            ShowPersonTitles.Add(new ShowPersonTitle
            {
                ShowPersonTitleId = Guid.Parse("A579FEAF-8A32-4354-A19C-790A2077FE6F"),
                MediaId = Guid.Parse("387271A1-4009-4667-BC49-5053BBC8E841"),
                PersonId = Guid.Parse("83ED21CF-04E4-4DA3-81A8-A6816E2BE91E"),
                DetailId = Guid.Parse("D74FF8E0-8333-46C7-B3BB-DC52C0D5C09C")
            });

            ShowPersonTitles.Add(new ShowPersonTitle
            {
                ShowPersonTitleId = Guid.Parse("80AE0A98-9280-4923-BC0D-12EC5C873894"),
                MediaId = Guid.Parse("387271A1-4009-4667-BC49-5053BBC8E841"),
                PersonId = Guid.Parse("83ED21CF-04E4-4DA3-81A8-A6816E2BE91E"),
                DetailId = Guid.Parse("D74FF8E0-8333-46C7-B3BB-DC52C0D5C09C")
            });
        }

        private void GenerateFilmTags()
        {
            FilmTags.Add(new FilmTag
            {
                FilmTagId = Guid.Parse("526321DE-00FC-438C-9FC1-AF9AEDD701AD"),
                MediaId = Guid.Parse("3B14C9FF-E104-4847-B243-F1ADE305363C"),
                DetailId = Guid.Parse("0E2C4051-2459-4319-B18C-B285EE87503A")
            });

            FilmTags.Add(new FilmTag
            {
                FilmTagId = Guid.Parse("5E3DBF03-225A-4F02-989F-B07095215C9A"),
                MediaId = Guid.Parse("3B14C9FF-E104-4847-B243-F1ADE305363C"),
                DetailId = Guid.Parse("A2D708A5-8483-4E53-8E46-1332D9F5727B")
            });
        }

        private void GenerateShowTags()
        {
            ShowTags.Add(new ShowTag
            {
                ShowTagId = Guid.Parse("A4DC32A2-7B67-4AC7-994C-3ED2B6241BB7"),
                MediaId = Guid.Parse("387271A1-4009-4667-BC49-5053BBC8E841"),
                DetailId = Guid.Parse("A2D708A5-8483-4E53-8E46-1332D9F5727B")
            });

            ShowTags.Add(new ShowTag
            {
                ShowTagId = Guid.Parse("059FDA88-29A6-40AB-B513-83082C13A840"),
                MediaId = Guid.Parse("387271A1-4009-4667-BC49-5053BBC8E841"),
                DetailId = Guid.Parse("902F7EC9-3C13-41D7-9ABB-3ED1197E4B0A")
            });
        }

        private void GenerateFilmGenres()
        {
            FilmGenres.Add(new FilmGenre
            {
                FilmGenreId = Guid.Parse("9935A7B6-BA86-4B5D-B771-3170BA906613"),
                MediaId = Guid.Parse("3B14C9FF-E104-4847-B243-F1ADE305363C"),
                DetailId = Guid.Parse("D9787903-38C0-4DBB-95C6-99A396DA0090")
            });

            FilmGenres.Add(new FilmGenre
            {
                FilmGenreId = Guid.Parse("52F815ED-55D5-4808-B0BC-6DAABFF745B8"),
                MediaId = Guid.Parse("3B14C9FF-E104-4847-B243-F1ADE305363C"),
                DetailId = Guid.Parse("FEFF914A-149B-4C44-9688-7B287F650AA1")
            });
        }

        private void GenerateShowGenres()
        {
            ShowGenres.Add(new ShowGenre
            {
                ShowGenreId = Guid.Parse("81AF4BAE-4E2F-4B9B-99A7-D1B9DE11D903"),
                MediaId = Guid.Parse("387271A1-4009-4667-BC49-5053BBC8E841"),
                DetailId = Guid.Parse("46DA9B76-478E-4D92-AAD9-2AFB83A27553")
            });

            ShowGenres.Add(new ShowGenre
            {
                ShowGenreId = Guid.Parse("B7959A23-F379-4E93-BDF4-9558AE0B9E72"),
                MediaId = Guid.Parse("387271A1-4009-4667-BC49-5053BBC8E841"),
                DetailId = Guid.Parse("FEFF914A-149B-4C44-9688-7B287F650AA1")
            });
        }

        private void GenerateBaseData()
        {
            GenerateFilms();
            GenerateShows();
            //GenerateLists();
            //GenerateReviews();
            //GenerateReports();
            GeneratePeople();
            GenerateGenres();
            GenerateTitles();
            GenerateTags();
        }

        private void GenerateFilms()
        {
            Films.Add(new Film
            {
                MediaId = Guid.Parse("3B14C9FF-E104-4847-B243-F1ADE305363C"),
                MediaName = "Blade Runner 2049",
                PosterUri = "http://www.joblo.com/posters/images/full/runner-poster-main-large.jpg",
                Accolades = AwardStatus.Won,
                Runtime = 164,
                DateOfRelease = DateTime.Parse("2017-10-06"),
                CreatedOn = DateTime.Now
            });
        }

        private void GenerateShows()
        {
            Shows.Add(new Show
            {
                MediaId = Guid.Parse("387271A1-4009-4667-BC49-5053BBC8E841"),
                MediaName = "True Detective",
                PosterUri = "http://store.hbo.com/imgcache/product/resized/000/506/911/catl/true-detective-touch-darkness-poster-11x17_1000.jpg",
                Accolades = AwardStatus.Won,
                NumberOfSeasons = 2,
                DateOfRelease = DateTime.Parse("2014-01-12"),
                CreatedOn = DateTime.Now
            });
        }

        private void GenerateLists()
        {
            Lists.Add(new List
            {
                ListId = Guid.Parse("55747052-7799-4AB7-8035-9A539178A163")
            });
        }

        private void GenerateReviews()
        {
            Reviews.Add(new Review
            {
                ReviewId = Guid.Parse("FDAC7BC5-AFA3-4720-AFB5-A5EF9243F10C")
            });

            Reviews.Add(new Review
            {
                ReviewId = Guid.Parse("CAE6B81F-F97F-42C8-AAF3-0E1FCF14D17C")
            });
        }

        private void GenerateReports()
        {
            Reports.Add(new Report
            {
                ReportId = Guid.Parse("802A1F62-A801-4976-8597-CC8DF6BEF4FC")
            });

            Reports.Add(new Report
            {
                ReportId = Guid.Parse("21B8D2B0-8D2C-451C-9C5D-5BF325BAE522")
            });
        }

        private void GenerateGenres()
        {
            Genres.Add(new Genre
            {
                DetailId = Guid.Parse("D9787903-38C0-4DBB-95C6-99A396DA0090"),
                Name = "Film Noir",
                CreatedOn = DateTime.Now
            });

            Genres.Add(new Genre
            {
                DetailId = Guid.Parse("46DA9B76-478E-4D92-AAD9-2AFB83A27553"),
                Name = "Crime",
                CreatedOn = DateTime.Now
            });

            Genres.Add(new Genre
            {
                DetailId = Guid.Parse("FEFF914A-149B-4C44-9688-7B287F650AA1"),
                Name = "Mystery",
                CreatedOn = DateTime.Now
            });
        }

        private void GenerateTags()
        {
            Tags.Add(new Tag
            {
                DetailId = Guid.Parse("0E2C4051-2459-4319-B18C-B285EE87503A"),
                Name = "Atmospheric",
                CreatedOn = DateTime.Now
            });

            Tags.Add(new Tag
            {
                DetailId = Guid.Parse("A2D708A5-8483-4E53-8E46-1332D9F5727B"),
                Name = "Thought Provoking",
                CreatedOn = DateTime.Now
            });

            Tags.Add(new Tag
            {
                DetailId = Guid.Parse("902F7EC9-3C13-41D7-9ABB-3ED1197E4B0A"),
                Name = "Adult Themes",
                CreatedOn = DateTime.Now
            });
        }

        private void GenerateTitles()
        {
            Titles.Add(new Title
            {
                DetailId = Guid.Parse("2B639A0E-DCA1-4455-9FA4-FCC6EE1827B4"),
                Name = "Director",
                CreatedOn = DateTime.Now
            });

            Titles.Add(new Title
            {
                DetailId = Guid.Parse("7679B9C2-9244-4866-A4E0-0B811144A8B2"),
                Name = "Writer",
                CreatedOn = DateTime.Now
            });

            Titles.Add(new Title
            {
                DetailId = Guid.Parse("D74FF8E0-8333-46C7-B3BB-DC52C0D5C09C"),
                Name = "Actor",
                CreatedOn = DateTime.Now
            });
        }

        private void GeneratePeople()
        {
            People.Add(new Person
            {
                PersonId = Guid.Parse("0A0EF19C-D9D9-4A2C-925A-0D766D28DE74"),
                FirstName = "Denis",
                LastName = "Villeneuve",
                CreatedOn = DateTime.Now
            });

            People.Add(new Person
            {
                PersonId = Guid.Parse("9DB6C69E-AE5F-4522-B358-91177B6A103E"),
                FirstName = "Ryan",
                LastName = "Gosling",
                CreatedOn = DateTime.Now
            });

            People.Add(new Person
            {
                PersonId = Guid.Parse("83ED21CF-04E4-4DA3-81A8-A6816E2BE91E"),
                FirstName = "Cary",
                LastName = "Joji Fukunaga",
                CreatedOn = DateTime.Now
            });

            People.Add(new Person
            {
                PersonId = Guid.Parse("83ED21CF-04E4-4DA3-81A8-A6816E2BE91E"),
                FirstName = "Matthew",
                LastName = "McConaughey",
                CreatedOn = DateTime.Now
            });

            People.Add(new Person
            {
                PersonId = Guid.Parse("83ED21CF-04E4-4DA3-81A8-A6816E2BE91E"),
                FirstName = "Woody",
                LastName = "Harrelson",
                CreatedOn = DateTime.Now
            });
        }
    }
}