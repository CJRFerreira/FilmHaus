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

    public class ExpandedReportViewModel : BaseReportViewModel
    {
        public ExpandedReportViewModel() : base()
        {

        }

        public BaseReviewViewModel Review { get; set; }
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

        [DataType(DataType.Date)]
        public DateTime ReportedOn { get; set; }

        public ReportReason ReportReason { get; set; }

        public ReportStatus? ReportStatus { get; set; }
    }
}