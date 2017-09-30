using FilmHaus.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilmHaus.Models.Connector
{
    [Table("ShowGenre")]
    public class ShowGenre
    {
        [Key]
        [Column(Order = 1)]
        [ForeignKey("Show")]
        public Guid MediaId { get; set; }

        public virtual Show Show { get; set; }

        [Key]
        [Column(Order = 2)]
        [ForeignKey("Genre")]
        public Guid GenreId { get; set; }

        public virtual Genre Genre { get; set; }
    }
}