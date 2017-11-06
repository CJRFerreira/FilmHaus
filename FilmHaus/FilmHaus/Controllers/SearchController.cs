using FilmHaus.Services.Films;
using FilmHaus.Services.Shows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FilmHaus.Controllers
{
    [Authorize]
    public class SearchController : Controller
    {
        private IShowService ShowService { get; }

        private IFilmService FilmService { get; }

        public SearchController(IShowService showService, IFilmService filmService)
        {
            ShowService = showService;
            FilmService = filmService;
        }

        // GET: Search
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        // GET: Search/Films
        [HttpGet]
        public ActionResult Films()
        {
            return View();
        }

        // POST: Search/Films
        [HttpPost]
        public ActionResult SearchFilms(string searchTerm)
        {
            return View();
        }

        // GET: Search/Shows
        [HttpGet]
        public ActionResult Shows()
        {
            return View();
        }

        // POST: Search/Shows
        [HttpPost]
        public ActionResult SearchShows(string searchTerm)
        {
            return View();
        }
    }
}