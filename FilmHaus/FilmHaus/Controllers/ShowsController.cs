using FilmHaus.Models.View;
using FilmHaus.Services.ReviewShows;
using FilmHaus.Services.Shows;
using Microsoft.AspNet.Identity;
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
    [RoutePrefix("Shows")]
    public class ShowsController : Controller
    {
        private IShowService ShowService { get; }

        private IReviewShowService ReviewShowService { get; }

        public ShowsController(IShowService showService, IReviewShowService reviewShowService)
        {
            ShowService = showService;
            ReviewShowService = reviewShowService;
        }

        // GET: Show
        [Route("Index")]
        public ActionResult Index()
        {
            return View(ShowService.GetAllShows(User.Identity.GetUserId()));
        }

        // GET: Show/Details/5
        [Route("Details/{mediaId:guid}")]
        public ActionResult Details(Guid mediaId)
        {
            var result = ShowService.GetShowByMediaId(User.Identity.GetUserId(), mediaId);

            if (result != null)
                return View(result);

            return View("Index");
        }

        // GET: Show/Details/{mediaId}/Reviews
        [Route("Details/{mediaId:guid}/Reviews")]
        public ActionResult Reviews(Guid mediaId)
        {
            var show = ShowService.GetShowByMediaId(User.Identity.GetUserId(), mediaId);
            var reviews = ReviewShowService.GetAllSharedReviewsByShowId(mediaId);

            show.UserReview = ReviewShowService.GetUserReviewByShowId(mediaId, this.User.Identity.GetUserId());
            show.Reviews = reviews.Where(r => r.Id != this.User.Identity.GetUserId()).ToList();

            if (show != null)
                return View(show);

            return RedirectToAction("Index");
        }

        // GET: Shows/Create
        [Route("Create")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Shows/Create To protect from overposting attacks, please enable the specific
        // properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateShowViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            try
            {
                ShowService.CreateShow(viewModel);
            }
            catch (Exception)
            {
                throw;
            }

            return View("Details");
        }

        // GET: Shows/Edit/5
        [Route("Edit/{mediaId:guid}")]
        public ActionResult Edit(Guid mediaId)
        {
            return View(new EditShowViewModel(ShowService.GetShowByMediaId(User.Identity.GetUserId(), mediaId)));
        }

        // POST: Shows/Edit/5 To protect from overposting attacks, please enable the specific
        // properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditShowViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            try
            {
                ShowService.UpdateShowByMediaId(viewModel.MediaId, viewModel);
            }
            catch (Exception)
            {
                throw;
            }

            return View("Index");
        }

    }
}