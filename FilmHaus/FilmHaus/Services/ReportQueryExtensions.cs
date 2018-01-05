using FilmHaus.Models.Base;
using FilmHaus.Models.View;
using LinqKit;
using System;
using System.Linq.Expressions;
using static FilmHaus.Services.ReviewQueryExtensions;
using static FilmHaus.Services.UserQueryExtensions;

namespace FilmHaus.Services
{
    internal static class ReportQueryExtensions
    {
        /// <summary>
        /// Given a <see cref="Report"/>, return a view model
        /// </summary>
        /// <returns><see cref="BaseReportViewModel"/> representing the under lying <see cref="Report"/></returns>
        public static Expression<Func<Report, BaseReportViewModel>> GetBaseReportViewModel()
        {
            var reportingUser = GetUserViewModel();
            var userReported = GetUserViewModel();

            return r => new BaseReportViewModel()
            {
                ReportId = r.ReportId,
                ReviewReportedId = r.ReviewReportedId,
                ReportingUserId = r.ReportingUserId,
                ReportingUser = reportingUser.Invoke(r.ReportingUser),
                UserReportedId = r.UserReportedId,
                UserReported = userReported.Invoke(r.UserReported),
                ReportedOn = r.ReportedOn,
                ResolvedOn = r.ResolvedOn,
                ReportReason = r.ReportReason,
                ReportStatus = r.ReportStatus
            };
        }

        /// <summary>
        /// Given a <see cref="Report"/>, return a view model with the <see cref="Review"/> attached
        /// </summary>
        /// <returns><see cref="ExpandedReportBaseReviewViewModel"/> representing the under lying <see cref="Report"/></returns>
        public static Expression<Func<Report, ExpandedReportBaseReviewViewModel>> GetExpandedReportViewModel()
        {
            var review = GetReviewViewModel();
            var reportingUser = GetUserViewModel();
            var userReported = GetUserViewModel();

            return r => new ExpandedReportBaseReviewViewModel()
            {
                ReportId = r.ReportId,
                ReviewReportedId = r.ReviewReportedId,
                ReportingUserId = r.ReportingUserId,
                ReportingUser = reportingUser.Invoke(r.ReportingUser),
                UserReportedId = r.UserReportedId,
                UserReported = userReported.Invoke(r.UserReported),
                ReportedOn = r.ReportedOn,
                ResolvedOn = r.ResolvedOn,
                ReportReason = r.ReportReason,
                ReportStatus = r.ReportStatus,
                Review = review.Invoke(r.Review)
            };
        }

        /// <summary>
        /// Given a <see cref="Report"/>, return a view model with the <see cref="Review"/> and <see cref="Film"/> attached
        /// </summary>
        /// <returns><see cref="ExpandedReportExpandedReviewViewModel"/> representing the under lying <see cref="Report"/></returns>
        public static Expression<Func<Report, ExpandedReportExpandedReviewViewModel>> GetReportForFilmReview()
        {
            var review = GetReviewViewModelWithFilm();
            var reportingUser = GetUserViewModel();
            var userReported = GetUserViewModel();

            return r => new ExpandedReportExpandedReviewViewModel()
            {
                ReportId = r.ReportId,
                ReviewReportedId = r.ReviewReportedId,
                ReportingUserId = r.ReportingUserId,
                ReportingUser = reportingUser.Invoke(r.ReportingUser),
                UserReportedId = r.UserReportedId,
                UserReported = userReported.Invoke(r.UserReported),
                ReportedOn = r.ReportedOn,
                ResolvedOn = r.ResolvedOn,
                ReportReason = r.ReportReason,
                ReportStatus = r.ReportStatus,
                Review = review.Invoke(r.Review)
            };
        }

        /// <summary>
        /// Given a <see cref="Report"/>, return a view model with the <see cref="Review"/> and <see cref="Show"/> attached
        /// </summary>
        /// <returns><see cref="ExpandedReportExpandedReviewViewModel"/> representing the under lying <see cref="Report"/></returns>
        public static Expression<Func<Report, ExpandedReportExpandedReviewViewModel>> GetReportForShowReview()
        {
            var review = GetReviewViewModelWithShow();
            var reportingUser = GetUserViewModel();
            var userReported = GetUserViewModel();

            return r => new ExpandedReportExpandedReviewViewModel()
            {
                ReportId = r.ReportId,
                ReviewReportedId = r.ReviewReportedId,
                ReportingUserId = r.ReportingUserId,
                ReportingUser = reportingUser.Invoke(r.ReportingUser),
                UserReportedId = r.UserReportedId,
                UserReported = userReported.Invoke(r.UserReported),
                ReportedOn = r.ReportedOn,
                ResolvedOn = r.ResolvedOn,
                ReportReason = r.ReportReason,
                ReportStatus = r.ReportStatus,
                Review = review.Invoke(r.Review)
            };
        }
    }
}