using FilmHaus.Models.View;
using FilmHaus.Services.Reports;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace FilmHaus.Controllers
{
    [Authorize]
    [RoutePrefix("Reports")]
    public class ReportsController : Controller
    {
        private IReportService ReportService { get; }

        public ReportsController(IReportService reportService)
        {
            ReportService = reportService;
        }

        // GET: Reports
        [HttpGet]
        [Route("Index")]
        public ActionResult Index()
        {
            return View(ReportService.RetrieveAllActiveReports());
        }

        // GET: Reports/Details/5
        [Route("Details/{reportId:guid}")]
        public ActionResult Details(Guid reportId)
        {
            var result = ReportService.RetrieveSpecificReport(reportId);

            if (result != null)
                return PartialView(result);

            return RedirectToAction("Index");
        }

        // POST: Reports/Create To protect from overposting attacks, please enable the specific
        // properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateReportViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Index", "Library");

            try
            {
                ReportService.Create(viewModel);
            }
            catch
            {
                throw;
            }

            return RedirectToAction("Index", "Search");
        }

        // GET: Reports/Resolve/5
        [Route("Resolve/{reportId:guid}")]
        public ActionResult Resolve(Guid reportId)
        {
            var result = ReportService.RetrieveSpecificReport(reportId);

            if (result != null && this.User.IsInRole("Administrator"))
                return PartialView(new ResolveReportViewModel(result));

            return RedirectToAction("Index");
        }

        // POST: Reports/Resolve/5 To protect from overposting attacks, please enable the specific
        // properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Resolve(ResolveReportViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            try
            {
                ReportService.Resolve(viewModel.ReportId, viewModel);
            }
            catch
            {
                throw;
            }

            return RedirectToAction("Index");
        }
    }
}