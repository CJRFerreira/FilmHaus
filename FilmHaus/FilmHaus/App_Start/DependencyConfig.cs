using Autofac;
using Autofac.Integration.Mvc;
using FilmHaus.Services.Films;
using FilmHaus.Services.Lists;
using FilmHaus.Services.Reviews;
using FilmHaus.Services.Shows;
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

            builder.RegisterType<FilmService>().As<IFilmService>();
            //builder.RegisterType<ShowService>().As<IShowService>();
            //builder.RegisterType<ListService>().As<IListService>();
            //builder.RegisterType<ReviewService>().As<IReviewService>();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}