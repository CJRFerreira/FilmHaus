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

        [DataType(DataType.Text)]
        public String FirstName { get; set; }

        [DataType(DataType.Text)]
        public String LastName { get; set; }

        public virtual ICollection<FilmPersonRole> FilmPerson { get; set; }
    }
}