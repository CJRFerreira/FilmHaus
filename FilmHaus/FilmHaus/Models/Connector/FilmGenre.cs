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

        [Column(Order = 1)]
        [ForeignKey("Film")]
        public Guid MediaId { get; set; }

        public virtual Film Film { get; set; }

        [Column(Order = 2)]
        [ForeignKey("Genre")]
        public Guid GenreId { get; set; }

        public virtual Genre Genre { get; set; }
    }
}