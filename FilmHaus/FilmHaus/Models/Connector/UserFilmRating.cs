﻿using FilmHaus.Models.Base;
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
namespace FilmHaus.Models.Connector
{
    public class UserFilmRating
    {
        [Key]
        public Guid UserFilmRatingId { get; set; }

        [ForeignKey("User"), Column(Order = 0)]
        [Index(name: "IX_UserFilmRating", order: 0, IsUnique = true)]
        public string Id { get; set; }

        public virtual User User { get; set; }

        [ForeignKey("Film"), Column(Order = 1)]
        [Index(name: "IX_UserFilmRating", order: 1, IsUnique = true)]
        public Guid MediaId { get; set; }

        public virtual Film Film { get; set; }

        public DateTime CreatedOn { get; set; }

        [Index(name: "IX_UserFilmRating", order: 2, IsUnique = true)]
        public DateTime? ObsoletedOn { get; set; }

        [Range(1, 10)]
        public int Rating { get; set; }
    }
}