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
    [Table("Person")]
    public class Person
    {
        [Key]
        public Guid PersonId { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }

        [DataType(DataType.Text)]
        public string LastName { get; set; }

        public virtual ICollection<FilmPersonTitle> FilmPersonTitle { get; set; }

        public virtual ICollection<ShowPersonTitle> ShowPersonTitle { get; set; }
    }
}