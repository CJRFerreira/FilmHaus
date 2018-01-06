using FilmHaus.Localization;
using FilmHaus.Models.Connector;
using System;
using System.Collections.Generic;
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
    public class List
    {
        [Key]
        public Guid ListId { get; set; }

        [ForeignKey("User")]
        public string Id { get; set; }

        public virtual User User { get; set; }

        [Required]
        public string Title { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedOn { get; set; }

        [Required]
        [Display(Name = "Shared", ResourceType = typeof(Locale))]
        public bool Shared { get; set; }

        public virtual ICollection<ListFilm> ListFilm { get; set; }

        public virtual ICollection<ListShow> ListShow { get; set; }
    }
}