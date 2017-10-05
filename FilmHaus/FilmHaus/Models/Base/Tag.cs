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
    [Table("Tag")]
    public class Tag : Detail
    {
        public virtual ICollection<FilmTag> FilmTag { get; set; }

        public virtual ICollection<ShowTag> ShowTag { get; set; }

        public virtual ICollection<ListTag> ListTag { get; set; }
    }
}