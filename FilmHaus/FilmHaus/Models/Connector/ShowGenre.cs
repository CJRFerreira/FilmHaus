using FilmHaus.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilmHaus.Models.Connector
{
    public class ShowGenre
    {
        [Key]
        public Guid ShowGenreId { get; set; }

        [ForeignKey("Show"), Column(Order = 0)]
        public Guid MediaId { get; set; }

        public virtual Show Show { get; set; }

        [ForeignKey("Genre"), Column(Order = 1)]
        public Guid DetailId { get; set; }

        public virtual Genre Genre { get; set; }
    }
}