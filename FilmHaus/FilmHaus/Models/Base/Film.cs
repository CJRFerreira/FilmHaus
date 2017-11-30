using FilmHaus.Models.Connector;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

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