using FilmHaus.Localization;
using FilmHaus.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FilmHaus.Models.View
{
    public class PersonTitleViewModel
    {
        public PersonTitleViewModel()
        {
        }

        public PersonViewModel Person { get; set; }

        public TitleViewModel Title { get; set; }
    }
}