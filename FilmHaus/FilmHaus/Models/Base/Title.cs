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
    public class Title : Detail
    {
        public Title() : base()
        {
        }

        public Title(Title title) : base(title)
        {
        }

        public virtual ICollection<FilmPersonTitle> FilmPersonTitle { get; set; }

        public virtual ICollection<ShowPersonTitle> ShowPersonTitle { get; set; }
    }
}