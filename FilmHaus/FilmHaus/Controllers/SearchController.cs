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
            var films = FilmService.GetAllFilms()
                .Where(f => f.MediaName.Contains(searchViewModel.SearchTerm)
                && f.Accolades == searchViewModel.Accolades
                && f.DateOfRelease.Year == searchViewModel.ReleaseYear
                && f.Rating >= searchViewModel.Rating)
                .ToList();

            var shows = ShowService.GetAllShows()
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
            return View(new SearchFilmsViewModel
            {
                Films = FilmService.GetAllFilms()
            });
        }

        // POST: Search/SearchFilms
        [HttpPost]
        public ActionResult SearchFilms(SearchFilmsViewModel searchViewModel)
        {
            searchViewModel.Films = FilmService.GetAllFilms()
                .Where(f => f.MediaName.Contains(searchViewModel.SearchTerm)
                && f.Accolades == searchViewModel.Accolades
                && f.DateOfRelease.Year == searchViewModel.ReleaseYear
                && f.Rating >= searchViewModel.Rating)
                .ToList();

            return View("Films", searchViewModel);
        }

        // GET: Search/Shows
        [HttpGet]
        public ActionResult Shows()
        {
            return View(new SearchShowsViewModel
            {
                Shows = ShowService.GetAllShows()
            });
        }

        // POST: Search/SearchShows
        [HttpPost]
        public ActionResult SearchShows(SearchShowsViewModel searchViewModel)
        {
            searchViewModel.Shows = ShowService.GetAllShows()
                .Where(s => s.MediaName.Contains(searchViewModel.SearchTerm)
                && s.Accolades == searchViewModel.Accolades
                && s.DateOfRelease.Year == searchViewModel.ReleaseYear
                && s.Rating >= searchViewModel.Rating)
                .ToList();

            return View("Shows", searchViewModel);
        }
    }
}