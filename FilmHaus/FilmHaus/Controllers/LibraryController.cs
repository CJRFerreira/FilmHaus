using FilmHaus.Models.View;
using FilmHaus.Services.Films;
using FilmHaus.Services.Shows;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;

namespace FilmHaus.Controllers
{
    [Authorize]
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
    }
}