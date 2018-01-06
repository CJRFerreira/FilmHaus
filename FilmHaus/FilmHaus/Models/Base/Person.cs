using FilmHaus.Models.Connector;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/// <summary>
/// Name: Christian Ferreira
/// Date: September 6th - January 5th
///
/// Statement of Authorship:
/// I, Christian Ferreira (Student #: 000346210), certify that this material is my original work.
/// No other person's work has been used without due acknowledgement.
/// </summary>
namespace FilmHaus.Models.Base
{
    public class Person
    {
        [Key]
        public Guid PersonId { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }

        [DataType(DataType.Text)]
        public string LastName { get; set; }

        [NotMapped]
        [DataType(DataType.Text)]
        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime CreatedOn { get; set; }

        public virtual ICollection<FilmPersonTitle> FilmPersonTitle { get; set; }

        public virtual ICollection<ShowPersonTitle> ShowPersonTitle { get; set; }
    }
}