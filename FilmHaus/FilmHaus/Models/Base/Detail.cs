using System;
using System.ComponentModel.DataAnnotations;

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
    public abstract class Detail
    {
        public Detail()
        {
        }

        public Detail(Detail detail)
        {
            DetailId = detail.DetailId;
            Name = detail.Name;
            CreatedOn = detail.CreatedOn;
        }

        [Key]
        public Guid DetailId { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedOn { get; set; }
    }
}