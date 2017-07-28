using FilmHaus.Localization;
using FilmHaus.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FilmHaus.Models.View
{
    public class PersonViewModel
    {
        public PersonViewModel()
        {
        }

        public PersonViewModel(Person person)
        {
            FirstName = person.FirstName;
            LastName = person.LastName;
        }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "FirstName", ResourceType = typeof(Locale))]
        public String FirstName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "LastName", ResourceType = typeof(Locale))]
        public String LastName { get; set; }
    }
}