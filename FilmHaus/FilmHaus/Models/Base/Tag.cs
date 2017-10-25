using FilmHaus.Models.Connector;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilmHaus.Models.Base
{
    public class Tag : Detail
    {
        public virtual ICollection<FilmTag> FilmTag { get; set; }

        public virtual ICollection<ShowTag> ShowTag { get; set; }

        public virtual ICollection<ListTag> ListTag { get; set; }
    }
}