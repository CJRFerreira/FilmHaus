using System.Web.Mvc;
using System.Web.Routing;

namespace FilmHaus
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                name: "FilmDetails",
                url: "Films/Details/{id}",
                defaults: new { controller = "Films", action = "Details" }
            );

            routes.MapRoute(
                name: "EditFilm",
                url: "Films/Edit/{id}",
                defaults: new { controller = "Films", action = "Edit" }
            );

            routes.MapRoute(
                name: "FilmDefault",
                url: "Films/{action}",
                defaults: new { controller = "Films", action = "Index" }
            );

            routes.MapRoute(
                name: "ShowDetails",
                url: "Shows/Details/{id}",
                defaults: new { controller = "Shows", action = "Details" }
            );

            routes.MapRoute(
                name: "EditShow",
                url: "Shows/Edit/{id}",
                defaults: new { controller = "Shows", action = "Edit" }
            );

            routes.MapRoute(
                name: "ShowDefault",
                url: "Shows/{action}",
                defaults: new { controller = "Shows", action = "Index" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}