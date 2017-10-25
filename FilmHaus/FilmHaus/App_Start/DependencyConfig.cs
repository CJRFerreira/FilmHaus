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

            builder.RegisterType<UserFilmService>().As<IUserFilmService>();
            builder.RegisterType<UserFilmRatingService>().As<IUserFilmRatingService>();
            builder.RegisterType<FilmService>().As<IFilmService>();

            builder.RegisterType<UserShowService>().As<IUserShowService>();
            builder.RegisterType<UserShowRatingService>().As<IUserShowRatingService>();
            builder.RegisterType<ShowService>().As<IShowService>();

            builder.RegisterType<ReviewService>().As<IReviewService>();
            //builder.RegisterType<ListService>().As<IListService>();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}