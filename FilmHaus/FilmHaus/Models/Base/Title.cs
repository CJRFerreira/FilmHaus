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
    [Table("Title")]
    public class Title
    {
        [Key]
        public Guid TitleId { get; set; }

        [DataType(DataType.Text)]
        public String TitleName { get; set; }

        public virtual ICollection<FilmPersonTitle> FilmPersonTitle { get; set; }
    }
}