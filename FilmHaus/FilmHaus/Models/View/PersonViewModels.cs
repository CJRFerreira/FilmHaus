﻿using FilmHaus.Localization;
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

        [DataType(DataType.Text)]
        [Display(Name = "FirstName", ResourceType = typeof(Locale))]
        public String FirstName { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "LastName", ResourceType = typeof(Locale))]
        public String LastName { get; set; }
    }

    public class CreatePersonViewModel
    {
        public CreatePersonViewModel()
        {
        }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "FirstName", ResourceType = typeof(Locale))]
        public String FirstName { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "LastName", ResourceType = typeof(Locale))]
        public String LastName { get; set; }
    }

    public class EditPersonViewModel
    {
        public EditPersonViewModel()
        {
        }

        public EditPersonViewModel(Person person)
        {
            FirstName = person.FirstName;
            LastName = person.LastName;
        }

        public EditPersonViewModel(PersonViewModel person)
        {
            FirstName = person.FirstName;
            LastName = person.LastName;
        }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "FirstName", ResourceType = typeof(Locale))]
        public String FirstName { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "LastName", ResourceType = typeof(Locale))]
        public String LastName { get; set; }
    }
}