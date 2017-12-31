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
            PersonId = person.PersonId;
            FirstName = person.FirstName;
            LastName = person.LastName;
        }

        public PersonViewModel(EditPersonViewModel person)
        {
            PersonId = person.PersonId;
            FirstName = person.FirstName;
            LastName = person.LastName;
        }

        [Display(Name = "Id", ResourceType = typeof(Locale))]
        public Guid PersonId { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "FirstName", ResourceType = typeof(Locale))]
        public string FirstName { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "LastName", ResourceType = typeof(Locale))]
        public string LastName { get; set; }
    }

    public class CreatePersonViewModel
    {
        public CreatePersonViewModel()
        {
        }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "FirstName", ResourceType = typeof(Locale))]
        public string FirstName { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "LastName", ResourceType = typeof(Locale))]
        public string LastName { get; set; }
    }

    public class EditPersonViewModel
    {
        public EditPersonViewModel()
        {
        }

        public EditPersonViewModel(Person person)
        {
            PersonId = person.PersonId;
            FirstName = person.FirstName;
            LastName = person.LastName;
        }

        public EditPersonViewModel(PersonTitleViewModel person)
        {
            PersonId = person.PersonId;
            FirstName = person.FirstName;
            LastName = person.LastName;
        }

        [Display(Name = "Id", ResourceType = typeof(Locale))]
        public Guid PersonId { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "FirstName", ResourceType = typeof(Locale))]
        public string FirstName { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "LastName", ResourceType = typeof(Locale))]
        public string LastName { get; set; }
    }
}