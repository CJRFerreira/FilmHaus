using FilmHaus.Models.View;
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
            return View(new SearchLibraryViewModel());
        }

        // POST: Search/Films
        [HttpPost]
        public ActionResult SearchAll(SearchViewModel searchViewModel)
        {
            var films = FilmService.GetAllActiveFilms()
                .Where(f => f.MediaName.Contains(searchViewModel.SearchTerm)
                && f.Accolades == searchViewModel.Accolades
                && f.DateOfRelease.Year == searchViewModel.ReleaseYear
                && f.Rating >= searchViewModel.Rating)
                .ToList();

            var shows = ShowService.GetAllActiveShows()
                .Where(s => s.MediaName.Contains(searchViewModel.SearchTerm)
                && s.Accolades == searchViewModel.Accolades
                && s.DateOfRelease.Year == searchViewModel.ReleaseYear
                && s.Rating >= searchViewModel.Rating)
                .ToList();

            return View("Index", new SearchLibraryViewModel()
            {
                SearchViewModel = searchViewModel,
                Films = films,
                Shows = shows
            });
        }

        // GET: Search/Films
        [HttpGet]
        public ActionResult Films()
        {
            return View();
        }

        // POST: Search/SearchFilms
        [HttpPost]
        public ActionResult SearchFilms(SearchViewModel searchViewModel)
        {
            return View("Films", FilmService.GetAllActiveFilms()
                .Where(f => f.MediaName.Contains(searchViewModel.SearchTerm)
                && f.Accolades == searchViewModel.Accolades
                && f.DateOfRelease.Year == searchViewModel.ReleaseYear
                && f.Rating >= searchViewModel.Rating)
                .ToList()
                );
        }

        // GET: Search/Shows
        [HttpGet]
        public ActionResult Shows()
        {
            return View();
        }

        // POST: Search/SearchShows
        [HttpPost]
        public ActionResult SearchShows(SearchViewModel searchViewModel)
        {
            return View("Shows", ShowService.GetAllActiveShows()
                .Where(s => s.MediaName.Contains(searchViewModel.SearchTerm)
                && s.Accolades == searchViewModel.Accolades
                && s.DateOfRelease.Year == searchViewModel.ReleaseYear
                && s.Rating >= searchViewModel.Rating)
                .ToList()
                );
        }
    }
}