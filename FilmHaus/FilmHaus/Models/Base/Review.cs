﻿using FilmHaus.Enums;
using FilmHaus.Localization;
using FilmHaus.Models.Connector;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

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
    public class Review
    {
        [Key]
        public Guid ReviewId { get; set; }

        [ForeignKey("User")]
        public string Id { get; set; }

        public virtual User User { get; set; }

        [DataType(DataType.MultilineText)]
        public string Body { get; set; }

        [Required]
        public bool Shared { get; set; }

        public bool Flagged { get; set; }

        public bool IsActive { get; set; }

        public ReportReason? ReportReason { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreatedOn { get; set; }

        [Required]
        public ReviewType ReviewType { get; set; }

        public virtual ICollection<Report> ReviewReports { get; set; }

        public virtual ICollection<ReviewFilm> ReviewFilm { get; set; }

        public virtual ICollection<ReviewShow> ReviewShow { get; set; }
    }
}