using FilmHaus.Models.Base;
using FilmHaus.Models.Connector;
using FilmHaus.Models.View;
using LinqKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static FilmHaus.Services.ReviewQueryExtensions;

namespace FilmHaus.Services
{
    internal static class ReportQueryExtensions
    {
        public static Expression<Func<Report, BaseReportViewModel>> GetBaseReportViewModel()
        {
            return r => new BaseReportViewModel()
            {
                ReportId = r.ReportId,
                ReviewReportedId = r.ReviewReportedId,
                ReportingUserId = r.ReportingUserId,
                UserReportedId = r.UserReportedId,
                ReportedOn = r.ReportedOn,
                ResolvedOn = r.ResolvedOn,
                ReportReason = r.ReportReason,
                ReportStatus = r.ReportStatus
            };
        }

        public static Expression<Func<Report, ExpandedReportBaseReviewViewModel>> GetExpandedReportViewModel()
        {
            var review = GetReviewViewModel();

            return r => new ExpandedReportBaseReviewViewModel()
            {
                ReportId = r.ReportId,
                ReviewReportedId = r.ReviewReportedId,
                ReportingUserId = r.ReportingUserId,
                UserReportedId = r.UserReportedId,
                ReportedOn = r.ReportedOn,
                ResolvedOn = r.ResolvedOn,
                ReportReason = r.ReportReason,
                ReportStatus = r.ReportStatus,
                Review = review.Invoke(r.Review)
            };
        }

        public static Expression<Func<Report, ExpandedReportExpandedReviewViewModel>> GetReportForFilmReview()
        {
            var review = GetReviewViewModelWithFilm();

            return r => new ExpandedReportExpandedReviewViewModel()
            {
                ReportId = r.ReportId,
                ReviewReportedId = r.ReviewReportedId,
                ReportingUserId = r.ReportingUserId,
                UserReportedId = r.UserReportedId,
                ReportedOn = r.ReportedOn,
                ResolvedOn = r.ResolvedOn,
                ReportReason = r.ReportReason,
                ReportStatus = r.ReportStatus,
                Review = review.Invoke(r.Review)
            };
        }

        public static Expression<Func<Report, ExpandedReportExpandedReviewViewModel>> GetReportForShowReview()
        {
            var review = GetReviewViewModelWithShow();

            return r => new ExpandedReportExpandedReviewViewModel()
            {
                ReportId = r.ReportId,
                ReviewReportedId = r.ReviewReportedId,
                ReportingUserId = r.ReportingUserId,
                UserReportedId = r.UserReportedId,
                ReportedOn = r.ReportedOn,
                ResolvedOn = r.ResolvedOn,
                ReportReason = r.ReportReason,
                ReportStatus = r.ReportStatus,
                Review = review.Invoke(r.Review)
            };
        }
    }
}