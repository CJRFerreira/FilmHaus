using FilmHaus.Models.View;
using FilmHaus.Services.Films;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace FilmHaus.Controllers
{
    [Authorize]
    [RoutePrefix("Film")]
    public class FilmsController : Controller
    {
        private IFilmService FilmService { get; }

        public FilmsController(IFilmService filmService)
        {
            FilmService = filmService;
        }

        // GET: Film
        public ActionResult Index()
        {
            return View(FilmService.GetAllFilms());
        }

        // GET: Film/Details/5
        public ActionResult Details(string mediaId)
        {
            var result = FilmService.GetFilmByMediaId(Guid.Parse(mediaId));

            if (result != null)
                return View(result);

            return View("Index");
        }

        public ActionResult Details(FilmViewModel viewModel)
        {
            if (viewModel != null)
                return View(viewModel);

            return View("Index", FilmService.GetAllFilms());
        }

        // GET: Films/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Films/Create To protect from overposting attacks, please enable the specific
        // properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateFilmViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            try
            {
                FilmService.CreateFilm(viewModel);
            }
            catch (Exception)
            {
                throw;
            }

            return View("Details");
        }

        // GET: Films/Edit/5
        public ActionResult Edit(string mediaId)
        {
            return View();
        }

        // GET: Films/Edit/5
        public ActionResult Edit(FilmViewModel viewModel)
        {
            return View(new EditFilmViewModel(viewModel));
        }

        // POST: Films/Edit/5 To protect from overposting attacks, please enable the specific
        // properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditFilmViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            try
            {
                FilmService.UpdateFilmByMediaId(viewModel.MediaId, viewModel);
            }
            catch (Exception)
            {
                throw;
            }

            return View("Index");
        }

        // GET: Films/Delete/5
        public ActionResult Delete(string mediaId)
        {
            var result = FilmService.GetFilmByMediaId(Guid.Parse(mediaId));

            if (result != null)
                return View(result);

            return View("Index");
        }

        // POST: Films/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string mediaId)
        {
            try
            {
                FilmService.ObsoleteFilmByMediaId(Guid.Parse(mediaId));
            }
            catch (Exception)
            {
                throw;
            }
            return RedirectToAction("Index");
        }
    }
}