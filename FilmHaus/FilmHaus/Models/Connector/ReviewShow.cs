using FilmHaus.Models.Base;
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
    public class ReviewShow
    {
        [Key]
        public Guid ReviewShowId { get; set; }

        [ForeignKey("Show"), Column(Order = 0)]
        [Index(name: "IX_ReviewShow", order: 0, IsUnique = true)]
        public Guid MediaId { get; set; }

        public virtual Show Show { get; set; }

        [ForeignKey("Review"), Column(Order = 1)]
        [Index(name: "IX_ReviewShow", order: 1, IsUnique = true)]
        public Guid ReviewId { get; set; }

        public virtual Review Review { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime CreatedOn { get; set; }

        [Index(name: "IX_ReviewShow", order: 2, IsUnique = true)]
        public DateTime? ObsoletedOn { get; set; }
    }
}