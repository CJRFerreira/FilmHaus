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
    [Table("FilmRole")]
    public class FilmRole
    {
        [Key]
        public Guid Id { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Role", ResourceType = typeof(Locale))]
        public String Name { get; set; }

        [NotMapped]
        public virtual ICollection<FilmPersonRole> FilmPersonRole { get; set; }
    }
}