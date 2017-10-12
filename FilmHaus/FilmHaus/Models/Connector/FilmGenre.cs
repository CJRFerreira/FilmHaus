using FilmHaus.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FilmHaus.Models.Connector
{
    [Table("FilmGenre")]
    public class FilmGenre
    {
        [Key]
        public Guid FilmGenreId { get; set; }

        [ForeignKey("Film"), Column(Order = 0)]
        public Guid MediaId { get; set; }

        public virtual Film Film { get; set; }

        [ForeignKey("Genre"), Column(Order = 1)]
        public Guid DetailId { get; set; }

        public virtual Genre Genre { get; set; }
    }
}