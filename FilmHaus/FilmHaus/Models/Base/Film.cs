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
    [Table("Film")]
    public class Film
    {
        public Film()
        {
        }

        [Key]
        [Required]
        public Guid FilmId { get; set; }

        [DataType(DataType.ImageUrl)]
        public Uri PosterUri { get; set; }

        [Required]
        public string FilmName { get; set; }

        [DataType(DataType.Date)]
        public DateTimeOffset DateOfRelease { get; set; }

        public int Runtime { get; set; }

        public string Accolades { get; set; }

        public virtual ICollection<FilmGenre> FilmGenre { get; set; }

        public virtual ICollection<FilmTag> FilmTag { get; set; }
    }
}