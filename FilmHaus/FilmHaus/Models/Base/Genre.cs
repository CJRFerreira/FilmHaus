using FilmHaus.Models.Connector;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

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