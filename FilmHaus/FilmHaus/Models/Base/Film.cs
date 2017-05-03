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
        [Key]
        public Guid Id { get; set; }

        [Display(Name = "Film Name")]
        public String FilmName { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date of Release")]
        public DateTime DateOfRelease { get; set; }

        [Display(Name = "Runtime")]
        public Int32 Runtime { get; set; }

        [Display(Name = "Rating")]
        public Int32 Rating { get; set; }

        [Display(Name = "Accolades")]
        public String Accolades { get; set; }

        public virtual ICollection<FilmGenre> FilmGenre { get; set; }
    }
}