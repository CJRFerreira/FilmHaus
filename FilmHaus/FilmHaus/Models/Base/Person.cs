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

        public String FirstName { get; set; }

        public String LastName { get; set; }

        public String FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
    }
}