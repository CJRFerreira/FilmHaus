using FilmHaus.Models.View;
using FilmHaus.Services.Films;
using FilmHaus.Services.Shows;
using FilmHaus.Services.UserFilms;
using FilmHaus.Services.UserShows;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;

namespace FilmHaus.Controllers
{
    [Authorize]
    [RoutePrefix("Library")]
    public class LibraryController : Controller
    {
        private IUserFilmService UserFilmService { get; }

        private IUserShowService UserShowService { get; }

        public LibraryController(IUserFilmService userFilmService, IUserShowService userShowService)
        {
            UserFilmService = userFilmService;
            UserShowService = userShowService;
        }

        // GET: Library
        public ActionResult Index()
        {
            var userId = this.User.Identity.GetUserId();

            return View(new LibraryViewModel
                (
                    films: UserFilmService.GetAllFilmsForUser(userId),
                    shows: UserShowService.GetAllShowsForUser(userId)
                ));
        }

        // GET: Library/MyFilms
        public ActionResult MyFilms()
        {
            return View(new FilmLibraryViewModel
                (
                    films: UserFilmService.GetAllFilmsForUser(this.User.Identity.GetUserId())
                ));
        }

        // GET: Library/MyShows
        public ActionResult MyShows()
        {
            return View(new ShowLibraryViewModel
                (
                    shows: UserShowService.GetAllShowsForUser(this.User.Identity.GetUserId())
                ));
        }
    }
}