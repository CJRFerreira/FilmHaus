using FilmHaus.Localization;
using FilmHaus.Models.Connector;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FilmHaus.Models.Base
{
    [Table("Film")]
    public class Film : Media
    {
        public Film()
        {
        }

        public Film(Film film)
        {
            MediaId = film.MediaId;
            PosterUri = film.PosterUri;
            MediaName = film.MediaName;
            DateOfRelease = film.DateOfRelease;
            Accolades = film.Accolades;
            Runtime = film.Runtime;
            CreatedOn = film.CreatedOn;
        }

        public int Runtime { get; set; }

        public virtual ICollection<FilmGenre> FilmGenre { get; set; }

        public virtual ICollection<FilmTag> FilmTag { get; set; }

        public virtual ICollection<ListFilm> ListFilm { get; set; }

        public virtual ICollection<FilmPersonTitle> FilmPersonTitle { get; set; }

        public virtual ICollection<UserFilm> UserFilm { get; set; }

        public virtual ICollection<UserFilmRating> UserFilmRating { get; set; }
    }
}