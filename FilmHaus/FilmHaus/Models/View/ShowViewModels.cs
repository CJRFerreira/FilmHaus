using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FilmHaus.Models.Base;
using System.ComponentModel.DataAnnotations;
using FilmHaus.Localization;
using FilmHaus.Enums;

namespace FilmHaus.Models.View
{
    public class ShowViewModel : MediaViewModel
    {
        public ShowViewModel() : base()
        {
        }

        public ShowViewModel(Show show)
        {
            MediaId = show.MediaId;
            PosterUri = show.PosterUri;
            MediaName = show.MediaName;
            DateOfRelease = show.DateOfRelease;
            NumberOfSeasons = show.NumberOfSeasons;
            Accolades = show.Accolades;
        }

        public ShowViewModel(EditShowViewModel show)
        {
            MediaId = show.MediaId;
            PosterUri = show.PosterUri;
            MediaName = show.MediaName;
            DateOfRelease = show.DateOfRelease;
            NumberOfSeasons = show.NumberOfSeasons;
            Accolades = show.Accolades;
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

        public EditShowViewModel(Show show)
        {
            MediaId = show.MediaId;
            PosterUri = show.PosterUri;
            MediaName = show.MediaName;
            DateOfRelease = show.DateOfRelease;
            NumberOfSeasons = show.NumberOfSeasons;
            Accolades = show.Accolades;
        }

        public EditShowViewModel(ShowViewModel show)
        {
            MediaId = show.MediaId;
            PosterUri = show.PosterUri;
            MediaName = show.MediaName;
            DateOfRelease = show.DateOfRelease;
            NumberOfSeasons = show.NumberOfSeasons;
            Accolades = show.Accolades;
        }

        [Display(Name = "NumberOfSeasons", ResourceType = typeof(Locale))]
        public int NumberOfSeasons { get; set; }
    }
}