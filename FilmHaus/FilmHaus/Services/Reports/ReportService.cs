using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using LinqKit;
using FilmHaus.Enums;
using FilmHaus.Models;
using FilmHaus.Models.View;
using FilmHaus.Models.Base;
using FilmHaus.Exceptions;
using static FilmHaus.Services.ReportQueryExtensions;
using FilmHaus.Services.Reviews;

namespace FilmHaus.Services.Reports
{
    public class ReportService : IReportService
    {
        private FilmHausDbContext FilmHausDbContext { get; }

        private IReviewService ReviewService { get; }

        public ReportService(FilmHausDbContext filmHausDbContext, IReviewService reviewService)
        {
            FilmHausDbContext = filmHausDbContext;
            ReviewService = reviewService;
        }

        public void Create(CreateReportViewModel viewModel)
        {
            FilmHausDbContext.Reports.Add(new Report
            {
                ReportId = Guid.NewGuid(),
                ReviewReportedId = viewModel.ReviewReportedId,
                ReportedOn = DateTime.Now,
                ResolvedOn = null,
                ReportStatus = ReportStatus.Unresolved,
                ReportReason = viewModel.ReportReason,
                ReportingUserId = viewModel.ReportingUserId,
                UserReportedId = viewModel.UserReportedId
            });
            FilmHausDbContext.SaveChanges();

            ReviewService.FlagReviewByReviewId(viewModel.ReviewReportedId);
        }

        public ExpandedReportExpandedReviewViewModel RetrieveSpecificReport(Guid reportId)
        {
            var result = FilmHausDbContext.Reports.Where(r => r.ReportId == reportId).FirstOrDefault();

            switch (result.Review.ReviewType)
            {
                case ReviewType.Film:
                    var reportedFilmReview = GetReportForFilmReview();
                    return reportedFilmReview.Invoke(result);
                case ReviewType.Show:
                    var reportedShowReview = GetReportForShowReview();
                    return reportedShowReview.Invoke(result);
                //case ReviewType.Season:
                //    var report = GetReportForFilmReview();
                //    return report.Invoke(result);
                //case ReviewType.Episode:
                //    var report = GetReportForFilmReview();
                //    return report.Invoke(result);
                default:
                    return new ExpandedReportExpandedReviewViewModel(result);
            }
        }

        public List<ExpandedReportExpandedReviewViewModel> RetrieveAllReports()
        {
            var results = FilmHausDbContext.Reports.AsExpandable().ToList();
            var reports = new List<ExpandedReportExpandedReviewViewModel>();

            foreach (var result in results)
            {
                switch (result.Review.ReviewType)
                {
                    case ReviewType.Film:
                        reports.Add(GetReportForFilmReview().Invoke(result));
                        break;
                    case ReviewType.Show:
                        reports.Add(GetReportForShowReview().Invoke(result));
                        break;
                    //case ReviewType.Season:
                    //    break;
                    //case ReviewType.Episode:
                    //    break;
                    default:
                        reports.Add(new ExpandedReportExpandedReviewViewModel(result));
                        break;
                }
            }

            return reports;
        }

        public List<ExpandedReportBaseReviewViewModel> RetrieveAllReportsByReportee(string reporteeId)
        {
            return FilmHausDbContext.Reports.AsExpandable().Where(r => r.UserReportedId == reporteeId).Select(GetExpandedReportViewModel()).ToList();
        }

        public List<ExpandedReportBaseReviewViewModel> RetrieveAllReportsByReporter(string reporterId)
        {
            return FilmHausDbContext.Reports.AsExpandable().Where(r => r.ReportingUserId == reporterId).Select(GetExpandedReportViewModel()).ToList();
        }

        public List<BaseReportViewModel> RetrieveAllReportsByReview(Guid reviewId)
        {
            return FilmHausDbContext.Reports.AsExpandable().Where(r => r.ReviewReportedId == reviewId).Select(GetBaseReportViewModel()).ToList();
        }

        public void Update(Guid reportId, EditReportViewModel viewModel)
        {
            try
            {
                var result = FilmHausDbContext.Reports.Find(reportId);

                if (result == null)
                    throw new ArgumentNullException();

                result.ReportReason = viewModel.ReportReason;

                FilmHausDbContext.Entry(result).State = EntityState.Modified;
                FilmHausDbContext.SaveChanges();
            }
            catch (InvalidOperationException ex)
            {
                throw ex;
            }
        }

        public void Resolve(Guid reportId, ResolveReportViewModel viewModel)
        {
            try
            {
                var result = FilmHausDbContext.Reports.Find(reportId);

                if (result == null)
                    throw new ArgumentNullException();

                result.ReportStatus = viewModel.ReportStatus;

                switch (viewModel.ReportStatus)
                {
                    case ReportStatus.Accepted:
                        ReviewService.BanReviewByReviewId(result.ReviewReportedId, result.ReportReason);
                        result.ResolvedOn = DateTime.Now;
                        break;
                    case ReportStatus.Rejected:
                        ReviewService.UnflagReviewByReviewId(result.ReviewReportedId);
                        result.ResolvedOn = DateTime.Now;
                        break;
                    default:
                        break;
                }

                FilmHausDbContext.Entry(result).State = EntityState.Modified;
                FilmHausDbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void Delete(Guid reportId)
        {
            try
            {
                var report = FilmHausDbContext.Reports.Find(reportId);

                if (report == null)
                    throw new ArgumentNullException();

                FilmHausDbContext.Reports.Remove(report);
                FilmHausDbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void Obsolete(Guid reportId)
        {
            try
            {
                var result = FilmHausDbContext.Reports.Find(reportId);

                if (result == null)
                    throw new ArgumentNullException();

                result.ResolvedOn = DateTime.Now;

                FilmHausDbContext.Entry(result).State = EntityState.Modified;
                FilmHausDbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public List<ExpandedReportExpandedReviewViewModel> RetrieveAllActiveReports()
        {
            var results = FilmHausDbContext.Reports.AsExpandable().Where(r => r.ResolvedOn == null).ToList();
            var reports = new List<ExpandedReportExpandedReviewViewModel>();

            foreach (var result in results)
            {
                switch (result.Review.ReviewType)
                {
                    case ReviewType.Film:
                        reports.Add(GetReportForFilmReview().Invoke(result));
                        break;
                    case ReviewType.Show:
                        reports.Add(GetReportForShowReview().Invoke(result));
                        break;
                    //case ReviewType.Season:
                    //    break;
                    //case ReviewType.Episode:
                    //    break;
                    default:
                        reports.Add(new ExpandedReportExpandedReviewViewModel(result));
                        break;
                }
            }

            return reports;
        }

        public List<ExpandedReportBaseReviewViewModel> RetrieveAllActiveReportsByReportee(string reporteeId)
        {
            return FilmHausDbContext.Reports.AsExpandable().Where(r => r.UserReportedId == reporteeId && r.ResolvedOn == null).Select(GetExpandedReportViewModel()).ToList();
        }

        public List<ExpandedReportBaseReviewViewModel> RetrieveAllActiveReportsByReporter(string reporterId)
        {
            return FilmHausDbContext.Reports.AsExpandable().Where(r => r.ReportingUserId == reporterId && r.ResolvedOn == null).Select(GetExpandedReportViewModel()).ToList();
        }

        public List<BaseReportViewModel> RetrieveAllActiveReportsByReview(Guid reviewId)
        {
            return FilmHausDbContext.Reports.AsExpandable().Where(r => r.ReviewReportedId == reviewId && r.ResolvedOn == null).Select(GetBaseReportViewModel()).ToList();
        }
    }
}