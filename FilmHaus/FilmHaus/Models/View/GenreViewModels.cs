﻿using FilmHaus.Localization;
using FilmHaus.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FilmHaus.Models.View
{
    public class GenreViewModel
    {
        public GenreViewModel()
        {
        }

        public GenreViewModel(Genre genre)
        {
            Name = genre.Name;
        }

        [DataType(DataType.Text)]
        [Display(Name = "Genre", ResourceType = typeof(Locale))]
        public String Name { get; set; }
    }

    public class CreateGenreViewModel
    {
        public CreateGenreViewModel()
        {
        }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Genre", ResourceType = typeof(Locale))]
        public String Name { get; set; }
    }

    public class EditGenreViewModel
    {
        public EditGenreViewModel()
        {
        }

        public EditGenreViewModel(Genre genre)
        {
            Name = genre.Name;
        }

        public EditGenreViewModel(GenreViewModel genre)
        {
            Name = genre.Name;
        }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Genre", ResourceType = typeof(Locale))]
        public String Name { get; set; }
    }
}