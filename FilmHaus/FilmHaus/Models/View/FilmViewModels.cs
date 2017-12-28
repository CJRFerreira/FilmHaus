using System;
using FilmHaus.Models.Base;
using System.ComponentModel.DataAnnotations;
using FilmHaus.Localization;
using System.Collections.Generic;
using FilmHaus.Enums;

namespace FilmHaus.Models.View
{
    public class FilmViewModel : MediaViewModel
    {
        public FilmViewModel() : base()
        {
        }

        public FilmViewModel(Film film) : base(film)
        {
            Runtime = film.Runtime;
        }

        public FilmViewModel(EditFilmViewModel film) : base(film)
        {
            Runtime = film.Runtime;
        }

        [Display(Name = "Runtime", ResourceType = typeof(Locale))]
        public int Runtime { get; set; }
    }

    public class CreateFilmViewModel : CreateMediaViewModel
    {
        public CreateFilmViewModel() : base()
        {
        }

        [Display(Name = "Runtime", ResourceType = typeof(Locale))]
        public int Runtime { get; set; }
    }

    public class EditFilmViewModel : EditMediaViewModel
    {
        public EditFilmViewModel() : base()
        {
        }

        public EditFilmViewModel(Film film) : base(film)
        {
            Runtime = film.Runtime;
        }

        public EditFilmViewModel(FilmViewModel film) : base(film)
        {
            Runtime = film.Runtime;
        }

        [Display(Name = "Runtime", ResourceType = typeof(Locale))]
        public int Runtime { get; set; }
    }
}