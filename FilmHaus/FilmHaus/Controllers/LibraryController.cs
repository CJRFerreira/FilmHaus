using FilmHaus.Models.View;
using FilmHaus.Services.Films;
using FilmHaus.Services.Shows;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;

namespace FilmHaus.Controllers
{
    [Authorize]
    [RoutePrefix("Library")]
    public class LibraryController : Controller
    {
        private IFilmService FilmService { get; set; }

        private IShowService ShowService { get; set; }

        public LibraryController(IFilmService filmService, IShowService showService)
        {
            FilmService = filmService;
            ShowService = showService;
        }

        // GET: Library
        public ActionResult Index()
        {
            var userId = this.User.Identity.GetUserId();

            return View(new LibraryViewModel
                (
                    films: FilmService.GetAllFilmsForUser(userId),
                    shows: ShowService.GetAllShowsForUser(userId)
                ));
        }

        // GET: Library/MyFilms
        public ActionResult MyFilms()
        {
            return View(new FilmLibraryViewModel
                (
                    films: FilmService.GetAllFilmsForUser(this.User.Identity.GetUserId())
                ));
        }

        // GET: Library/MyShows
        public ActionResult MyShows()
        {
            return View(new ShowLibraryViewModel
                (
                    shows: ShowService.GetAllShowsForUser(this.User.Identity.GetUserId())
                ));
        }
    }
}