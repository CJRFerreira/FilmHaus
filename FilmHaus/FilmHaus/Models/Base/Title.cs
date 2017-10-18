using FilmHaus.Models.Connector;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilmHaus.Models.Base
{
    [Table("Title")]
    public class Title : Detail
    {
        public virtual ICollection<FilmPersonTitle> FilmPersonTitle { get; set; }

        public virtual ICollection<ShowPersonTitle> ShowPersonTitle { get; set; }
    }
}