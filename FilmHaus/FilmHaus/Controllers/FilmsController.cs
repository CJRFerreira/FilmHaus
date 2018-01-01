using FilmHaus.Models.View;
using FilmHaus.Services.Films;
using FilmHaus.Services.ReviewFilms;
using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Web.Mvc;

namespace FilmHaus.Controllers
{
    [Authorize]
    [RoutePrefix("Films")]
    public class FilmsController : Controller
    {
        private IFilmService FilmService { get; }

        private IReviewFilmService ReviewFilmService { get; }

        public FilmsController(IFilmService filmService, IReviewFilmService reviewFilmService)
        {
            FilmService = filmService;
            ReviewFilmService = reviewFilmService;
        }

        // GET: Film
        [Route("Index")]
        public ActionResult Index()
        {
            return View(FilmService.GetAllFilms());
        }

        // GET: Film/Details/{mediaId}
        [Route("Details/{mediaId:guid}")]
        public ActionResult Details(Guid mediaId)
        {
            var result = FilmService.GetFilmByMediaId(mediaId);

            if (result != null)
                return View(result);

            return RedirectToAction("Index");
        }

        // GET: Film/Details/{mediaId}/Reviews
        [Route("Details/{mediaId:guid}/Reviews")]
        public ActionResult Reviews(Guid mediaId)
        {
            var film = FilmService.GetFilmByMediaId(mediaId);
            var reviews = ReviewFilmService.GetAllSharedReviewsByFilmId(mediaId);

            film.UserReview = reviews.Where(r => r.Id == this.User.Identity.GetUserId()).FirstOrDefault();
            film.Reviews = reviews.Where(r => r.Id != this.User.Identity.GetUserId()).ToList();


            if (film != null)
                return View(film);

            return RedirectToAction("Index");
        }

        // GET: Films/Create
        [HttpGet]
        [Route("Create")]
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
            catch
            {
                throw;
            }

            return RedirectToAction("Index");
        }

        // GET: Films/Edit/{mediaId}
        [Route("Edit/{mediaId:guid}")]
        public ActionResult Edit(Guid mediaId)
        {
            return View(new EditFilmViewModel(FilmService.GetFilmByMediaId(mediaId)));
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
            catch
            {
                throw;
            }

            return RedirectToAction("Index");
        }

        // GET: Films/Delete/{mediaId}
        [Route("Delete/{mediaId:guid}")]
        public ActionResult Delete(string id)
        {
            var result = FilmService.GetFilmByMediaId(Guid.Parse(id));

            if (result != null)
                return View(result);

            return RedirectToAction("Index");
        }

        // POST: Films/Delete/{mediaId}
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid mediaId)
        {
            try
            {
                FilmService.DeleteFilmByMediaId(mediaId);
            }
            catch
            {
                throw;
            }
            return RedirectToAction("Index");
        }
    }
}