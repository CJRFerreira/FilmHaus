﻿using FilmHaus.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/// <summary>
/// Name: Christian Ferreira
/// Date: September 6th - January 5th
///
/// Statement of Authorship:
/// I, Christian Ferreira (Student #: 000346210), certify that this material is my original work.
/// No other person's work has been used without due acknowledgement.
/// </summary>
namespace FilmHaus.Models.Base
{
    public class Report
    {
        [Key]
        [Index(name: "IX_Report", order: 0, IsUnique = true)]
        public Guid ReportId { get; set; }

        [ForeignKey("Review"), Column(Order = 1)]
        [Index(name: "IX_Report", order: 1, IsUnique = true)]
        public Guid ReviewReportedId { get; set; }

        public virtual Review Review { get; set; }

        [Required]
        [Index(name: "IX_Report", order: 2, IsUnique = true)]
        public string ReportingUserId { get; set; }

        [ForeignKey("ReportingUserId"), Column(Order = 2)]
        public virtual User ReportingUser { get; set; }

        [Required]
        [Index(name: "IX_Report", order: 3, IsUnique = true)]
        public string UserReportedId { get; set; }

        [ForeignKey("UserReportedId"), Column(Order = 3)]
        public virtual User UserReported { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime ReportedOn { get; set; }

        [Index(name: "IX_Report", order: 4, IsUnique = true)]
        public DateTime? ResolvedOn { get; set; }

        [Required]
        public ReportReason ReportReason { get; set; }

        public ReportStatus ReportStatus { get; set; }
    }
}