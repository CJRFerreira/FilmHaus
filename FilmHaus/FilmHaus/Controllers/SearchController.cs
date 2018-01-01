using FilmHaus.Enums;
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
            return View("Index", new SearchLibraryViewModel()
            {
                SearchViewModel = searchViewModel,
                Films = EnactFilmSearch(searchViewModel.SearchTerm, searchViewModel.ReleaseYear, searchViewModel.Rating, searchViewModel.Accolades),
                Shows = EnactShowSearch(searchViewModel.SearchTerm, searchViewModel.ReleaseYear, searchViewModel.Rating, searchViewModel.Accolades)
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
            searchViewModel.Films = EnactFilmSearch(searchViewModel.SearchTerm, searchViewModel.ReleaseYear, searchViewModel.Rating, searchViewModel.Accolades);

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
            searchViewModel.Shows = EnactShowSearch(searchViewModel.SearchTerm, searchViewModel.ReleaseYear, searchViewModel.Rating, searchViewModel.Accolades);

            return View("Shows", searchViewModel);
        }

        private List<FilmViewModel> EnactFilmSearch(string searchTerm, int? releaseYear, int? rating, AwardStatus? accolades)
        {
            var results = FilmService.GetAllFilms();

            if (!String.IsNullOrEmpty(searchTerm))
                results = results.Where(r => r.MediaName.ToUpperInvariant().Contains(searchTerm.ToUpperInvariant())).ToList();

            if (releaseYear != null)
                results = results.Where(r => r.DateOfRelease.Year == releaseYear).ToList();

            if (rating != null)
                results = results.Where(r => (r.Rating == rating) || (r.Rating == rating - 1) || (r.Rating == rating + 1)).ToList();

            if (accolades != null)
                results = results.Where(r => r.Accolades == accolades).ToList();

            return results;
        }

        private List<ShowViewModel> EnactShowSearch(string searchTerm, int? releaseYear, int? rating, AwardStatus? accolades)
        {
            var results = ShowService.GetAllShows();

            if (!String.IsNullOrEmpty(searchTerm))
                results = results.Where(r => r.MediaName.ToUpperInvariant().Contains(searchTerm.ToUpperInvariant())).ToList();

            if (releaseYear != null)
                results = results.Where(r => r.DateOfRelease.Year == releaseYear).ToList();

            if (rating != null)
                results = results.Where(r => (r.Rating >= rating - 1) && (r.Rating <= rating + 1)).ToList();

            if (accolades != null)
                results = results.Where(r => r.Accolades == accolades).ToList();

            return results;
        }
    }
}