using FilmHaus.Models.Connector;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FilmHaus.Models.Base
{
    [Table("Show")]
    public class Show
    {
        public Show()
        {
        }

        [Key]
        [Required]
        public Guid ShowId { get; set; }

        [DataType(DataType.ImageUrl)]
        public Uri PosterUri { get; set; }

        [Required]
        public string ShowName { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfRelease { get; set; }

        public int NumberOfSeasons { get; set; }

        public string Accolades { get; set; }

        public virtual ICollection<ShowGenre> FilmGenre { get; set; }

        public virtual ICollection<ShowTag> FilmTag { get; set; }
    }
}