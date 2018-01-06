using System;
using FilmHaus.Models.Base;
using System.ComponentModel.DataAnnotations;
using FilmHaus.Localization;
using System.Collections.Generic;
using FilmHaus.Enums;

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