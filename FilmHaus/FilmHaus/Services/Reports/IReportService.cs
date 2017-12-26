using FilmHaus.Models.Base;
using FilmHaus.Models.View;
using System;
using System.Collections.Generic;

namespace FilmHaus.Services.Reports
{
    public interface IReportService
    {
        void Create(CreateReportViewModel viewModel);

        ExpandedReportExpandedReviewViewModel RetrieveSpecificReport(Guid reportId);

        List<ExpandedReportExpandedReviewViewModel> RetrieveAllReports();

        List<ExpandedReportBaseReviewViewModel> RetrieveAllReportsByReportee(string reporteeId);

        List<ExpandedReportBaseReviewViewModel> RetrieveAllReportsByReporter(string reporterId);

        List<BaseReportViewModel> RetrieveAllReportsByReview(Guid reviewId);

        List<ExpandedReportExpandedReviewViewModel> RetrieveAllActiveReports();

        List<ExpandedReportBaseReviewViewModel> RetrieveAllActiveReportsByReportee(string reporteeId);

        List<ExpandedReportBaseReviewViewModel> RetrieveAllActiveReportsByReporter(string reporterId);

        List<BaseReportViewModel> RetrieveAllActiveReportsByReview(Guid reviewId);

        void Update(Guid reportId, EditReportViewModel viewModel);

        void Resolve(Guid reportId, ResolveReportViewModel viewModel);

        void Delete(Guid reportId);

        void Obsolete(Guid reportId);
    }
}