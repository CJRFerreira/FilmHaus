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
        public Guid Id { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "FirstName", ResourceType = typeof(Locale))]
        public String FirstName { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "LastName", ResourceType = typeof(Locale))]
        public String LastName { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Name", ResourceType = typeof(Locale))]
        [NotMapped]
        public String FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }

        public virtual ICollection<FilmPerson> FilmPerson { get; set; }
    }
}