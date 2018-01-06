using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FilmHaus.Models.Base;
using System.ComponentModel.DataAnnotations;
using FilmHaus.Localization;
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
    public class ShowViewModel : MediaViewModel
    {
        public ShowViewModel() : base()
        {
        }

        public ShowViewModel(Show show) : base(show)
        {
            NumberOfSeasons = show.NumberOfSeasons;
        }

        public ShowViewModel(EditShowViewModel show) : base(show)
        {
            NumberOfSeasons = show.NumberOfSeasons;
        }

        [Display(Name = "NumberOfSeasons", ResourceType = typeof(Locale))]
        public int NumberOfSeasons { get; set; }
    }



    public class CreateShowViewModel : CreateMediaViewModel
    {
        public CreateShowViewModel() : base()
        {
        }

        [Display(Name = "NumberOfSeasons", ResourceType = typeof(Locale))]
        public int NumberOfSeasons { get; set; }
    }

    public class EditShowViewModel : EditMediaViewModel
    {
        public EditShowViewModel() : base()
        {
        }

        public EditShowViewModel(Show show) : base(show)
        {
            NumberOfSeasons = show.NumberOfSeasons;
        }

        public EditShowViewModel(ShowViewModel show) : base(show)
        {
            NumberOfSeasons = show.NumberOfSeasons;
        }

        [Display(Name = "NumberOfSeasons", ResourceType = typeof(Locale))]
        public int NumberOfSeasons { get; set; }
    }
}