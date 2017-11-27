using FilmHaus.Models.View;
using FilmHaus.Enums;
using FilmHaus.Services.ReviewFilms;
using FilmHaus.Services.Reviews;
using FilmHaus.Services.ReviewShows;
using Microsoft.AspNet.Identity;
using System;
using System.Web.Mvc;

namespace FilmHaus.Controllers
{
    [Authorize]
    public class ReviewsController : Controller
    {
        public IReviewService ReviewService { get; private set; }

        public IReviewFilmService ReviewFilmService { get; private set; }

        public IReviewShowService ReviewShowService { get; private set; }

        public ReviewsController(IReviewService reviewService, IReviewFilmService reviewFilmService, IReviewShowService reviewShowService)
        {
            ReviewService = reviewService;
            ReviewFilmService = reviewFilmService;
            ReviewShowService = reviewShowService;
        }

        [HttpGet]
        public ActionResult Details(string reviewId)
        {
            var result = ReviewService.GetReviewByReviewId(Guid.Parse(reviewId));

            if (result != null)
                return View(result);

            return RedirectToAction("Index", "Library");
        }

        // GET: Reviews/Edit/5
        [HttpGet]
        public ActionResult Edit(string reviewId)
        {
            var result = ReviewService.GetReviewByReviewId(Guid.Parse(reviewId));

            if (result.Id == this.User.Identity.GetUserId())
                return View(new EditReviewViewModel(result));

            return RedirectToAction("Index", "Library");
        }

        // POST: Reviews/Edit/5 To protect from overposting attacks, please enable the specific
        // properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditReviewViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            try
            {
                if (viewModel.Id == this.User.Identity.GetUserId())
                {
                    ReviewService.UpdateReviewByReviewId(viewModel.ReviewId, viewModel);
                    return RedirectToAction("Details", "Films", new { mediaId = viewModel.MediaId });
                }
                else
                    return RedirectToAction("Index", "Library");
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public ActionResult Create(Guid mediaId, ReviewType reviewType)
        {
            return PartialView("CreateReviewPartial", new CreateReviewViewModel(mediaId, reviewType));
        }

        [HttpPost]
        public ActionResult Create(CreateReviewViewModel viewModel)
        {
            switch (viewModel.ReviewType)
            {
                case ReviewType.Film:
                    ReviewService.CreateReviewForFilm(viewModel, this.User.Identity.GetUserId());
                    break;

                case ReviewType.Show:
                    ReviewService.CreateReviewForShow(viewModel, this.User.Identity.GetUserId());
                    break;

                case ReviewType.Season:
                    //ReviewService.CreateReviewForSeason(viewModel, this.User.Identity.GetUserId());
                    break;

                case ReviewType.Episode:
                    //ReviewService.CreateReviewForEpisode(viewModel, this.User.Identity.GetUserId());
                    break;

                default:
                    break;
            }

            return RedirectToAction("Details", "Films", new { mediaId = viewModel.MediaId });
        }
    }
}