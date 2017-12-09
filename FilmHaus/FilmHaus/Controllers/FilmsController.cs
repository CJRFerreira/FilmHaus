using FilmHaus.Models.View;
using FilmHaus.Services.Films;
using System;
using System.Web.Mvc;

namespace FilmHaus.Controllers
{
    [Authorize]
    public class FilmsController : Controller
    {
        public IFilmService FilmService { get; private set; }

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
        public ActionResult Details(string id)
        {
            var result = FilmService.GetFilmByMediaId(Guid.Parse(id));

            if (result != null)
                return View(result);

            return RedirectToAction("Index");
        }

        // GET: Films/Create
        [HttpGet]
        public ActionResult Create()
        {
            if (User.IsInRole("Administrator"))
                return View(new CreateFilmViewModel());

            return RedirectToAction("Index");
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

            return RedirectToAction("Index");
        }

        // GET: Films/Edit/5
        public ActionResult Edit(string id)
        {
            return View(new EditFilmViewModel(FilmService.GetFilmByMediaId(Guid.Parse(id))));
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

            return RedirectToAction("Index");
        }

        // GET: Films/Delete/5
        public ActionResult Delete(string id)
        {
            var result = FilmService.GetFilmByMediaId(Guid.Parse(id));

            if (result != null)
                return View(result);

            return RedirectToAction("Index");
        }

        // POST: Films/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            try
            {
                FilmService.DeleteFilmByMediaId(Guid.Parse(id));
            }
            catch (Exception)
            {
                throw;
            }
            return RedirectToAction("Index");
        }
    }
}