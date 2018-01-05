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
        private IReviewService ReviewService { get; }

        private IReviewFilmService ReviewFilmService { get; }

        private IReviewShowService ReviewShowService { get; }

        public ReviewsController(IReviewService reviewService, IReviewFilmService reviewFilmService, IReviewShowService reviewShowService)
        {
            ReviewService = reviewService;
            ReviewFilmService = reviewFilmService;
            ReviewShowService = reviewShowService;
        }

        // GET: Reviews/MyReviews
        [HttpGet]
        [Route("MyReviews")]
        public ActionResult MyReviews()
        {
            return View(ReviewService.GetAllReviewsByUserId(this.User.Identity.GetUserId()));
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
                    return RedirectToAction("Details", new { mediaId = viewModel.MediaId });
                }
                else
                    return RedirectToAction("MyReviews", "Reviews");
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult Create(Guid mediaId, ReviewType reviewType)
        {
            return PartialView("CreateReviewPartial", new CreateReviewViewModel(mediaId, reviewType));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateReviewViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            switch (viewModel.ReviewType)
            {
                case ReviewType.Film:
                    ReviewService.CreateReviewForFilm(viewModel, this.User.Identity.GetUserId());
                    return RedirectToAction("Details", "Films", new { mediaId = viewModel.MediaId });

                case ReviewType.Show:
                    ReviewService.CreateReviewForShow(viewModel, this.User.Identity.GetUserId());
                    return RedirectToAction("Details", "Shows", new { mediaId = viewModel.MediaId });

                case ReviewType.Season:
                    //ReviewService.CreateReviewForSeason(viewModel, this.User.Identity.GetUserId());
                    break;

                case ReviewType.Episode:
                    //ReviewService.CreateReviewForEpisode(viewModel, this.User.Identity.GetUserId());
                    break;

                default:
                    return RedirectToAction("MyReviews", "Reviews");
            }

            return RedirectToAction("MyReviews", "Reviews");
        }

        public ActionResult Delete(Guid reviewId, Guid mediaId, ReviewType reviewType)
        {
            switch (reviewType)
            {
                case ReviewType.Film:
                    ReviewService.ObsoleteReviewForFilm(reviewId, mediaId);
                    return RedirectToAction("Reviews", "Films", new { mediaId });

                case ReviewType.Show:
                    ReviewService.ObsoleteReviewForShow(reviewId, mediaId);
                    return RedirectToAction("Reviews", "Shows", new { mediaId });

                case ReviewType.Season:
                    break;

                case ReviewType.Episode:
                    break;

                default:
                    return RedirectToAction("MyReviews", "Reviews");
            }

            return RedirectToAction("MyReviews", "Reviews");
        }
    }
}