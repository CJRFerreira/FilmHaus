﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FilmHaus.Models.Base;
using System.ComponentModel.DataAnnotations;
using FilmHaus.Localization;

namespace FilmHaus.Models.View
{
    public class FilmViewModel
    {
        public FilmViewModel()
        {
        }

        public FilmViewModel(Film film)
        {
            PicUri = film.PicUri;
            FilmName = film.FilmName;
            DateOfRelease = film.DateOfRelease;
            Runtime = film.Runtime;
            Rating = film.Rating;
            Accolades = film.Accolades;
        }

        public Uri PicUri { get; set; }

        [Display(Name = "Title", ResourceType = typeof(Locale))]
        [Required]
        public String FilmName { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "ReleaseDate", ResourceType = typeof(Locale))]
        public DateTime DateOfRelease { get; set; }

        [Display(Name = "Runtime", ResourceType = typeof(Locale))]
        public Int32 Runtime { get; set; }

        [Display(Name = "Rating", ResourceType = typeof(Locale))]
        public Int32 Rating { get; set; }

        [Display(Name = "Accolades", ResourceType = typeof(Locale))]
        public String Accolades { get; set; }
    }
}