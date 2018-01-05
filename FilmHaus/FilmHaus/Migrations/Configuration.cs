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
        private List<Film> Films { get; set; } = new List<Film>();

        private List<Show> Shows { get; set; } = new List<Show>();

        private List<Genre> Genres { get; set; } = new List<Genre>();

        private List<Person> People { get; set; } = new List<Person>();

        private List<Title> Titles { get; set; } = new List<Title>();

        private List<Tag> Tags { get; set; } = new List<Tag>();

        private List<FilmPersonTitle> FilmPersonTitles { get; set; } = new List<FilmPersonTitle>();

        private List<ShowPersonTitle> ShowPersonTitles { get; set; } = new List<ShowPersonTitle>();

        private List<FilmTag> FilmTags { get; set; } = new List<FilmTag>();

        private List<ShowTag> ShowTags { get; set; } = new List<ShowTag>();

        private List<FilmGenre> FilmGenres { get; set; } = new List<FilmGenre>();

        private List<ShowGenre> ShowGenres { get; set; } = new List<ShowGenre>();


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
        }

        private void SeedBaseModels(FilmHausDbContext filmHausDbContext)
        {
            foreach (var film in Films)
                filmHausDbContext.Films.AddOrUpdate(film);

            foreach (var show in Shows)
                filmHausDbContext.Shows.AddOrUpdate(show);

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
                PersonId = Guid.Parse("797FFB80-AB97-4A2C-883B-4630982D1E67"),
                DetailId = Guid.Parse("D74FF8E0-8333-46C7-B3BB-DC52C0D5C09C")
            });

            ShowPersonTitles.Add(new ShowPersonTitle
            {
                ShowPersonTitleId = Guid.Parse("80AE0A98-9280-4923-BC0D-12EC5C873894"),
                MediaId = Guid.Parse("387271A1-4009-4667-BC49-5053BBC8E841"),
                PersonId = Guid.Parse("15954285-7423-4504-A9F8-6A2E6BFF6FD1"),
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
                PersonId = Guid.Parse("797FFB80-AB97-4A2C-883B-4630982D1E67"),
                FirstName = "Matthew",
                LastName = "McConaughey",
                CreatedOn = DateTime.Now
            });

            People.Add(new Person
            {
                PersonId = Guid.Parse("15954285-7423-4504-A9F8-6A2E6BFF6FD1"),
                FirstName = "Woody",
                LastName = "Harrelson",
                CreatedOn = DateTime.Now
            });
        }
    }
}