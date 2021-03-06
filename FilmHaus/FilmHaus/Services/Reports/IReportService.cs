﻿using FilmHaus.Models.Base;
using FilmHaus.Models.View;
using System;
using System.Collections.Generic;

/// <summary>
/// Name: Christian Ferreira
/// Date: September 6th - January 5th
///
/// Statement of Authorship:
/// I, Christian Ferreira (Student #: 000346210), certify that this material is my original work.
/// No other person's work has been used without due acknowledgement.
/// </summary>
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

        void Resolve(Guid reportId, ResolveReportViewModel viewModel);

        void Delete(Guid reportId);

        void Obsolete(Guid reportId);
    }
}