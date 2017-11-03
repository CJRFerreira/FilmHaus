using FilmHaus.Models.View;
using FilmHaus.Services.Reviews;
using Microsoft.AspNet.Identity;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ReviewHaus.Controllers
{
    [Authorize]
    public class ReviewsController : Controller
    {
        public IReviewService ReviewService { get; private set; }

        public ReviewsController(IReviewService reviewService)
        {
            ReviewService = reviewService;
        }

        // GET: Review
        public ActionResult Index(string searchTerm, string currentFilter, int? page)
        {
            var sharedReviews = ReviewService.GetAllSharedReviews();

            if (searchTerm != null)
                page = 1;
            else
                searchTerm = currentFilter;

            ViewBag.CurrentFilter = searchTerm;

            if (!String.IsNullOrEmpty(searchTerm))
            {
                sharedReviews = sharedReviews.Where(sr => sr.Media.MediaName.ToUpperInvariant().Contains(searchTerm.ToUpperInvariant())).ToList();
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(sharedReviews.ToPagedList(pageNumber, pageSize));
        }

        // GET: Review/Details/5
        public ActionResult Details(string reviewId)
        {
            var result = ReviewService.GetReviewByReviewId(Guid.Parse(reviewId));

            if (result != null)
                return View(result);

            return View("Index");
        }

        public ActionResult Details(ReviewViewModel viewModel)
        {
            if (viewModel != null)
                return View(viewModel);

            return View("Index", ReviewService.GetAllSharedReviews());
        }

        // GET: Reviews/Edit/5
        public ActionResult Edit(string reviewId)
        {
            var result = ReviewService.GetReviewByReviewId(Guid.Parse(reviewId));

            if (result.Id == this.User.Identity.GetUserId())
                return View(new EditReviewViewModel(result));
            return View("Index");
        }

        // GET: Reviews/Edit/5
        public ActionResult Edit(ReviewViewModel viewModel)
        {
            if (viewModel.Id == this.User.Identity.GetUserId())
                return View(new EditReviewViewModel(viewModel));

            return View("Index");
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
                    return View("Details", ReviewService.GetReviewByReviewId(viewModel.ReviewId));
                }
                else
                    return View("Index");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}