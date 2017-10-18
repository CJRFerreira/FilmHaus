using FilmHaus.Models.View;
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
    [RoutePrefix("Show")]
    public class ShowsController : Controller
    {
        private IShowService ShowService { get; }

        public ShowsController(IShowService showService)
        {
            ShowService = showService;
        }

        // GET: Show
        public ActionResult Index()
        {
            return View(ShowService.GetAllShows());
        }

        // GET: Show/Details/5
        public ActionResult Details(string mediaId)
        {
            var result = ShowService.GetShowByMediaId(Guid.Parse(mediaId));

            if (result != null)
                return View(result);

            return View("Index");
        }

        public ActionResult Details(ShowViewModel viewModel)
        {
            if (viewModel != null)
                return View(viewModel);

            return View("Index", ShowService.GetAllShows());
        }

        // GET: Shows/Create
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
        public ActionResult Edit(string mediaId)
        {
            return View();
        }

        // GET: Shows/Edit/5
        public ActionResult Edit(ShowViewModel viewModel)
        {
            return View(new EditShowViewModel(viewModel));
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
        public ActionResult Delete(string mediaId)
        {
            var result = ShowService.GetShowByMediaId(Guid.Parse(mediaId));

            if (result != null)
                return View(result);

            return View("Index");
        }

        // POST: Shows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string mediaId)
        {
            try
            {
                ShowService.ObsoleteShowByMediaId(Guid.Parse(mediaId));
            }
            catch (Exception)
            {
                throw;
            }
            return RedirectToAction("Index");
        }
    }
}