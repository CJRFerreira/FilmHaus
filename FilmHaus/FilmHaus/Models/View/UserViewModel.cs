using FilmHaus.Localization;
using FilmHaus.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

/// <summary>
/// Name: Christian Ferreira
/// Date: September 6th - January 5th
///
/// Statement of Authorship:
/// I, Christian Ferreira (Student #: 000346210), certify that this material is my original work.
/// No other person's work has been used without due acknowledgement.
/// </summary>
namespace FilmHaus.Models.View
{
    public class UserViewModel
    {
        public UserViewModel()
        {
        }

        public UserViewModel(User user)
        {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            CreatedOn = user.CreatedOn;
            Email = user.Email;
            PhoneNumber = user.PhoneNumber;
        }

        [Display(Name = "Id", ResourceType = typeof(Locale))]
        public string Id { get; set; }

        [StringLength(50, MinimumLength = 1)]
        public string FirstName { get; set; }

        [StringLength(50, MinimumLength = 1)]
        public string LastName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        [NotMapped]
        [DataType(DataType.Text)]
        [Display(Name = "Name", ResourceType = typeof(Locale))]
        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }

        [DataType(DataType.DateTime)]
        public DateTime CreatedOn { get; set; }
    }
}