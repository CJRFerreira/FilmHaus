using FilmHaus.Models.View;
using FilmHaus.Services.Films;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FilmHaus.Controllers
{
    [Authorize]
    [RoutePrefix("Films")]
    public class FilmController : Controller
    {
        private IFilmService FilmService { get; set; }

        public FilmController(IFilmService filmService)
        {
            FilmService = filmService;
        }

        // GET: Film
        public ActionResult Index()
        {
            var films = FilmService.GetAllFilms();

            return View(films);
        }

        // GET: Film/Details/5
        public ActionResult Details(string mediaId)
        {
            return View(FilmService.GetFilmByMediaId(Guid.Parse(mediaId)));
        }

        // GET: Film/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Film/Create
        [HttpPost]
        public ActionResult Create(CreateFilmViewModel film)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Details");
            }
            catch
            {
                return View(film);
            }
        }

        // GET: Film/Edit/5
        public ActionResult Edit(string mediaId)
        {
            return View(new EditFilmViewModel(FilmService.GetFilmByMediaId(Guid.Parse(mediaId))));
        }

        // POST: Film/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, EditFilmViewModel film)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // POST: Film/Delete/5
        [HttpPost]
        public ActionResult Delete(string mediaId)
        {
            try
            {
                FilmService.DeleteFilmByMediaId(Guid.Parse(mediaId));

                return RedirectToAction("Index");
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}