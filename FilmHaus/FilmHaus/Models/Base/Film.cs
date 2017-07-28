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
            this.FilmId = Guid.NewGuid();
        }

        [Key]
        [Required]
        public Guid FilmId { get; set; }

        [DataType(DataType.ImageUrl)]
        public Uri PicUri { get; set; }

        [Required]
        [Display(Name = "Title", ResourceType = typeof(Locale))]
        public String FilmName { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "ReleaseDate", ResourceType = typeof(Locale))]
        public DateTime DateOfRelease { get; set; }

        [Display(Name = "Runtime", ResourceType = typeof(Locale))]
        public Int32 Runtime { get; set; }

        [Display(Name = "Rating", ResourceType = typeof(Locale))]
        public Int32 Rating { get; set; }

        [Display(Name = "Accolades", ResourceType = typeof(Locale))]
        public String Accolades { get; set; }

        [NotMapped]
        public virtual ICollection<FilmGenre> FilmGenre { get; set; }

        [NotMapped]
        public virtual ICollection<FilmTag> FilmTag { get; set; }
    }
}