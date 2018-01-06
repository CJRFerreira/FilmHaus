using FilmHaus.Models.Connector;
using System.Collections.Generic;

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
    public class Genre : Detail
    {
        public Genre() : base()
        {
        }

        public Genre(Genre genre) : base(genre)
        {
        }

        public virtual ICollection<FilmGenre> FilmGenre { get; set; }

        public virtual ICollection<ShowGenre> ShowGenre { get; set; }
    }
}