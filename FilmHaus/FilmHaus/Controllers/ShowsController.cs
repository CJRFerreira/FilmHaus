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
        public ActionResult Details(string id)
        {
            var result = ShowService.GetShowByMediaId(Guid.Parse(id));

            if (result != null)
                return View(result);

            return View("Index");
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
        public ActionResult Edit(string id)
        {
            return View(new EditShowViewModel(ShowService.GetShowByMediaId(Guid.Parse(id))));
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
        public ActionResult Delete(string id)
        {
            var result = ShowService.GetShowByMediaId(Guid.Parse(id));

            if (result != null)
                return View(result);

            return View("Index");
        }

        // POST: Shows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            try
            {
                ShowService.DeleteShowByMediaId(Guid.Parse(id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RedirectToAction("Index");
        }
    }
}