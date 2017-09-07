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
        public Uri PicUri { get; set; }

        [Required]
        public String FilmName { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfRelease { get; set; }

        public Int32 Runtime { get; set; }

        public Int32 Rating { get; set; }

        public String Accolades { get; set; }

        
        public virtual ICollection<FilmGenre> FilmGenre { get; set; }

        
        public virtual ICollection<FilmTag> FilmTag { get; set; }
    }
}