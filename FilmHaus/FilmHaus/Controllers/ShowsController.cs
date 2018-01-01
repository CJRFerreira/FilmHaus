using FilmHaus.Models.View;
using FilmHaus.Services.ReviewShows;
using FilmHaus.Services.Shows;
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
            return View(ShowService.GetAllShows());
        }

        // GET: Show/Details/5
        [Route("Details/{mediaId:guid}")]
        public ActionResult Details(Guid mediaId)
        {
            var result = ShowService.GetShowByMediaId(mediaId);

            if (result != null)
                return View(result);

            return View("Index");
        }

        // GET: Show/Details/{mediaId}/Reviews
        [Route("Details/{mediaId:guid}/Reviews")]
        public ActionResult Reviews(Guid mediaId)
        {
            var result = ShowService.GetShowByMediaId(mediaId);
            result.Reviews = ReviewShowService.GetAllSharedReviewsByShowId(mediaId);

            if (result != null)
                return View(result);

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
            return View(new EditShowViewModel(ShowService.GetShowByMediaId(mediaId)));
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

        // GET: Shows/Delete/5
        [Route("Delete/{mediaId:guid}")]
        public ActionResult Delete(Guid mediaId)
        {
            var result = ShowService.GetShowByMediaId(mediaId);

            if (result != null)
                return View(result);

            return View("Index");
        }

        // POST: Shows/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid mediaId)
        {
            try
            {
                ShowService.DeleteShowByMediaId(mediaId);
            }
            catch
            {
                throw;
            }
            return RedirectToAction("Index");
        }
    }
}