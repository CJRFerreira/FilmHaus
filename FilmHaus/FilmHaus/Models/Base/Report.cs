using FilmHaus.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilmHaus.Models.Base
{
    [Table("Report")]
    public class Report
    {
        [Key]
        public Guid Id { get; set; }

        [Column(Order = 1)]
        [ForeignKey("Review")]
        public Guid ReviewReportedId { get; set; }

        public virtual Review Review { get; set; }

        [Column(Order = 2)]
        [ForeignKey("User")]
        public Guid ReportingUserId { get; set; }

        [Column(Order = 3)]
        [ForeignKey("User")]
        public Guid UserReportedId { get; set; }

        public virtual User User { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReportedOn { get; set; }

        public ReportReason ReportReason { get; set; }

        public ReportStatus ReportStatus { get; set; }
    }
}