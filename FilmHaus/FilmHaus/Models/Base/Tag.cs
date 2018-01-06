using FilmHaus.Models.Connector;
using System.Collections.Generic;
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
    public class Tag : Detail
    {
        public Tag() : base()
        {
        }

        public Tag(Tag tag) : base(tag)
        {
        }

        public virtual ICollection<FilmTag> FilmTag { get; set; }

        public virtual ICollection<ShowTag> ShowTag { get; set; }
    }
}