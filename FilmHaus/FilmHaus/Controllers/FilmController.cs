using FilmHaus.Models.View;
using FilmHaus.Services.Films;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FilmHaus.Controllers
{
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
            return View();
        }

        // GET: Film/Details/5
        public ActionResult Details(string id)
        {
            return View();
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

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Film/Edit/5
        public ActionResult Edit(string id)
        {
            return View();
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

        // GET: Film/Delete/5
        public ActionResult Delete(string id)
        {
            return View();
        }

        // POST: Film/Delete/5
        [HttpPost]
        public ActionResult Delete(string filmId, string userId)
        {
            try
            {
                FilmService.DeleteFilmByFilmId(filmId);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}