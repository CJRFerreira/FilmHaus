using Autofac;
using Autofac.Integration.Mvc;
using FilmHaus.Models;
using FilmHaus.Services.Films;
using FilmHaus.Services.Shows;
using FilmHaus.Services.UserFilmRatings;
using FilmHaus.Services.UserShowRatings;
using FilmHaus.Services.UserFilms;
using FilmHaus.Services.UserShows;
using FilmHaus.Services.Reviews;
using System.Web.Mvc;
using FilmHaus.Services.ReviewFilms;
using FilmHaus.Services.ReviewShows;
using FilmHaus.Services.Reports;
using FilmHaus.Services.Lists;
using FilmHaus.Services.ListFilms;
using FilmHaus.Services.ListShows;
using FilmHaus.Services.Genres;
using FilmHaus.Services.Tags;
using FilmHaus.Services.Persons;
using FilmHaus.Services.Titles;
using FilmHaus.Services.FilmGenres;
using FilmHaus.Services.ShowGenres;
using FilmHaus.Services.FilmTags;
using FilmHaus.Services.ShowTags;
using FilmHaus.Services.ListTags;
using FilmHaus.Services.FilmPersonTitles;
using FilmHaus.Services.ShowPersonTitles;

/// <summary>
/// Name: Christian Ferreira
/// Date: September 6th - January 5th
///
/// Statement of Authorship:
/// I, Christian Ferreira (Student #: 000346210), certify that this material is my original work.
/// No other person's work has been used without due acknowledgement.
/// </summary>
namespace FilmHaus
{
    public class DependencyConfig
    {
        public static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterModelBinders(typeof(MvcApplication).Assembly);
            builder.RegisterModelBinderProvider();

            builder.RegisterModule<AutofacWebTypesModule>();

            builder.RegisterSource(new ViewRegistrationSource());

            builder.RegisterFilterProvider();

            builder.RegisterType<FilmHausDbContext>();

            builder.RegisterType<FilmService>().As<IFilmService>();
            builder.RegisterType<UserFilmService>().As<IUserFilmService>();
            builder.RegisterType<UserFilmRatingService>().As<IUserFilmRatingService>();

            builder.RegisterType<ShowService>().As<IShowService>();
            builder.RegisterType<UserShowService>().As<IUserShowService>();
            builder.RegisterType<UserShowRatingService>().As<IUserShowRatingService>();

            builder.RegisterType<GenreService>().As<IGenreService>();
            builder.RegisterType<FilmGenreService>().As<IFilmGenreService>();
            builder.RegisterType<ShowGenreService>().As<IShowGenreService>();

            builder.RegisterType<PersonService>().As<IPersonService>();
            builder.RegisterType<TitleService>().As<ITitleService>();
            builder.RegisterType<FilmPersonTitleService>().As<IFilmPersonTitleService>();
            builder.RegisterType<ShowPersonTitleService>().As<IShowPersonTitleService>();

            builder.RegisterType<ListService>().As<IListService>();
            builder.RegisterType<ListFilmService>().As<IListFilmService>();
            builder.RegisterType<ListShowService>().As<IListShowService>();

            builder.RegisterType<TagService>().As<ITagService>();
            builder.RegisterType<FilmTagService>().As<IFilmTagService>();
            builder.RegisterType<ShowTagService>().As<IShowTagService>();
            builder.RegisterType<ListTagService>().As<IListTagService>();

            builder.RegisterType<ReviewService>().As<IReviewService>();
            builder.RegisterType<ReviewFilmService>().As<IReviewFilmService>();
            builder.RegisterType<ReviewShowService>().As<IReviewShowService>();

            builder.RegisterType<ReportService>().As<IReportService>();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}