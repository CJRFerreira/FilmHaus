using FilmHaus.Models.Base;
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
namespace FilmHaus.Models.Connector
{
    public class ShowGenre
    {
        [Key]
        public Guid ShowGenreId { get; set; }

        [ForeignKey("Show"), Column(Order = 0)]
        public Guid MediaId { get; set; }

        public virtual Show Show { get; set; }

        [ForeignKey("Genre"), Column(Order = 1)]
        public Guid DetailId { get; set; }

        public virtual Genre Genre { get; set; }
    }
}