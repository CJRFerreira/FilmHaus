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
    public class Film : Media
    {
        public Film() : base()
        {
        }

        public Film(Film film) : base(film)
        {
            Runtime = film.Runtime;
        }

        public int Runtime { get; set; }

        public virtual ICollection<FilmGenre> FilmGenres { get; set; }

        public virtual ICollection<FilmTag> FilmTags { get; set; }

        public virtual ICollection<ListFilm> ListFilms { get; set; }

        public virtual ICollection<FilmPersonTitle> FilmPersonTitles { get; set; }

        public virtual ICollection<UserFilm> UserFilms { get; set; }

        public virtual ICollection<UserFilmRating> UserFilmRatings { get; set; }

        public virtual ICollection<ReviewFilm> ReviewFilms { get; set; }
    }
}