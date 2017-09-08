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
        public String ShowName { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfRelease { get; set; }

        public Int32 NumberOfSeasons { get; set; }

        public Int32 Rating { get; set; }

        public String Accolades { get; set; }

        public virtual ICollection<ShowGenre> FilmGenre { get; set; }

        public virtual ICollection<ShowTag> FilmTag { get; set; }
    }
}