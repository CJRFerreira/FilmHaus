using FilmHaus.Enums;
using FilmHaus.Localization;
using FilmHaus.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FilmHaus.Models.View
{
    public class BaseReportViewModel
    {
        public BaseReportViewModel()
        {
        }

        public BaseReportViewModel(Report report)
        {
            ReportId = report.ReportId;
            ReviewReportedId = report.ReviewReportedId;
            ReportingUserId = report.ReportingUserId;
            UserReportedId = report.UserReportedId;
            ReportedOn = report.ReportedOn;
            ResolvedOn = report.ResolvedOn;
            ReportReason = report.ReportReason;
            ReportStatus = report.ReportStatus;
        }

        public Guid ReportId { get; set; }

        public Guid ReviewReportedId { get; set; }

        public string ReportingUserId { get; set; }

        public string UserReportedId { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReportedOn { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ResolvedOn { get; set; }

        public ReportReason ReportReason { get; set; }

        public ReportStatus? ReportStatus { get; set; }
    }

    public class ExpandedReportBaseReviewViewModel : BaseReportViewModel
    {
        public ExpandedReportBaseReviewViewModel() : base()
        {

        }

        public ExpandedReportBaseReviewViewModel(Report report) : base(report)
        {

        }

        public BaseReviewViewModel Review { get; set; }
    }

    public class ExpandedReportExpandedReviewViewModel : BaseReportViewModel
    {
        public ExpandedReportExpandedReviewViewModel() : base()
        {

        }

        public ExpandedReportExpandedReviewViewModel(Report report) : base(report)
        {

        }

        public ExpandedReviewViewModel Review { get; set; }
    }

    public class CreateReportViewModel
    {
        public CreateReportViewModel()
        {
        }

        public Guid ReviewReportedId { get; set; }

        public string ReportingUserId { get; set; }

        public string UserReportedId { get; set; }

        [Required]
        public ReportReason ReportReason { get; set; }

    }

    public class EditReportViewModel
    {
        public EditReportViewModel()
        {

        }

        public Guid ReportId { get; set; }

        public ReportReason ReportReason { get; set; }

    }

    public class ResolveReportViewModel
    {
        public ResolveReportViewModel()
        {

        }

        public Guid ReportId { get; set; }

        public ReportStatus ReportStatus { get; set; }

    }
}