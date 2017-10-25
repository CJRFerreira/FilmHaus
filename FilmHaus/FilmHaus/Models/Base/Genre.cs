using FilmHaus.Models.Connector;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilmHaus.Models.Base
{
    public class Genre : Detail
    {
        public virtual ICollection<FilmGenre> FilmGenre { get; set; }

        public virtual ICollection<ShowGenre> ShowGenre { get; set; }
    }
}