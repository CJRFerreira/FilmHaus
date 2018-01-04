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

        public BaseReportViewModel(BaseReportViewModel report)
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

        [Display(Name = "Id", ResourceType = typeof(Locale))]
        public Guid ReportId { get; set; }

        [Display(Name = "Id", ResourceType = typeof(Locale))]
        public Guid ReviewReportedId { get; set; }

        [Display(Name = "Id", ResourceType = typeof(Locale))]
        public string ReportingUserId { get; set; }

        public UserViewModel ReportingUser { get; set; }
        [Display(Name = "Id", ResourceType = typeof(Locale))]
        public string UserReportedId { get; set; }

        public UserViewModel UserReported { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "ReportedOn", ResourceType = typeof(Locale))]
        public DateTime ReportedOn { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "ResolvedOn", ResourceType = typeof(Locale))]
        public DateTime? ResolvedOn { get; set; }

        [Display(Name = "Reason", ResourceType = typeof(Locale))]
        public ReportReason ReportReason { get; set; }

        [Display(Name = "Resolution", ResourceType = typeof(Locale))]
        public ReportStatus ReportStatus { get; set; }
    }

    public class ExpandedReportBaseReviewViewModel : BaseReportViewModel
    {
        public ExpandedReportBaseReviewViewModel() : base()
        {
        }

        public ExpandedReportBaseReviewViewModel(BaseReportViewModel viewModel) : base(viewModel)
        {
        }

        public ExpandedReportBaseReviewViewModel(ExpandedReportBaseReviewViewModel viewModel) : base(viewModel)
        {
            Review = viewModel.Review;
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

        public ExpandedReportExpandedReviewViewModel(BaseReportViewModel viewModel) : base(viewModel)
        {
        }

        public ExpandedReportExpandedReviewViewModel(ExpandedReportExpandedReviewViewModel viewModel) : base(viewModel)
        {
            Review = viewModel.Review;
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

        public CreateReportViewModel(Guid reviewReportedId, string reportingUserId, string userReportedId)
        {
            ReviewReportedId = reviewReportedId;
            ReportingUserId = reportingUserId;
            UserReportedId = userReportedId;
        }

        [Display(Name = "Id", ResourceType = typeof(Locale))]
        public Guid ReviewReportedId { get; set; }

        [Display(Name = "Id", ResourceType = typeof(Locale))]
        public string ReportingUserId { get; set; }

        [Display(Name = "Id", ResourceType = typeof(Locale))]
        public string UserReportedId { get; set; }

        [Required]
        [Display(Name = "Reason", ResourceType = typeof(Locale))]
        public ReportReason ReportReason { get; set; }
    }

    public class ResolveReportViewModel
    {
        public ResolveReportViewModel()
        {
        }

        public ResolveReportViewModel(BaseReportViewModel viewModel)
        {
            ReportId = viewModel.ReportId;
            ReportStatus = viewModel.ReportStatus;
        }

        [Display(Name = "Id", ResourceType = typeof(Locale))]
        public Guid ReportId { get; set; }

        [Display(Name = "Resolution", ResourceType = typeof(Locale))]
        public ReportStatus ReportStatus { get; set; }
    }
}