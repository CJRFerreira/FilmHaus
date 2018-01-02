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

        [HttpGet]
        [ChildActionOnly]
        public ActionResult Details(string reviewId)
        {
            var result = ReviewService.GetReviewByReviewId(Guid.Parse(reviewId));

            if (result != null)
                return PartialView(result);

            return RedirectToAction("Index", "Library");
        }

        // GET: Reviews/Edit/5
        [HttpGet]
        [ChildActionOnly]
        public ActionResult Edit(string reviewId)
        {
            var result = ReviewService.GetReviewByReviewId(Guid.Parse(reviewId));

            if (result.Id == this.User.Identity.GetUserId())
                return PartialView(new EditReviewViewModel(result));

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
                    return RedirectToAction("Details", new { mediaId = viewModel.MediaId });
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
        [ChildActionOnly]
        public ActionResult Create(Guid mediaId, ReviewType reviewType)
        {
            return PartialView("CreateReviewPartial", new CreateReviewViewModel(mediaId, reviewType));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
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