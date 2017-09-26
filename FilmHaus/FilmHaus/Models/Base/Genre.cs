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
    [Table("Genre")]
    public class Genre
    {
        [Key]
        public Guid GenreId { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        public virtual ICollection<FilmGenre> FilmGenre { get; set; }
    }
}