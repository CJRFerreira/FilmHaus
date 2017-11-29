using FilmHaus.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilmHaus.Models.Base
{
    public class Report
    {
        [Key, Index(name: "IX_Report", order: 0, IsUnique = true)]
        public Guid ReportId { get; set; }

        [ForeignKey("Review"), Column(Order = 1)]
        [Index(name: "IX_Report", order: 1, IsUnique = true)]
        public Guid ReviewReportedId { get; set; }

        public virtual Review Review { get; set; }

        [Required]
        public string ReportingUserId { get; set; }

        [ForeignKey("ReportingUserId"), Column(Order = 2)]
        public virtual User ReportingUser { get; set; }

        [Required]
        public string UserReportedId { get; set; }

        [ForeignKey("UserReportedId"), Column(Order = 3)]
        public virtual User UserReported { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReportedOn { get; set; }

        [Index(name: "IX_Report", order: 2, IsUnique = true)]
        public DateTime ResolvedOn { get; set; }

        public ReportReason ReportReason { get; set; }

        public ReportStatus ReportStatus { get; set; }
    }
}