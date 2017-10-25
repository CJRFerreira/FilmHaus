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
    public class UserShowViewModel : MediaViewModel
    {
        public UserShowViewModel() : base()
        {
        }

        public UserShowViewModel(Show show)
        {
            MediaId = show.MediaId;
            PosterUri = show.PosterUri;
            MediaName = show.MediaName;
            DateOfRelease = show.DateOfRelease;
            NumberOfSeasons = show.NumberOfSeasons;
            Accolades = show.Accolades;
        }

        public UserShowViewModel(EditShowViewModel show)
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

    public class GeneralShowViewModel : MediaViewModel
    {
        public GeneralShowViewModel() : base()
        {
        }

        public GeneralShowViewModel(Show show)
        {
            MediaId = show.MediaId;
            PosterUri = show.PosterUri;
            MediaName = show.MediaName;
            DateOfRelease = show.DateOfRelease;
            NumberOfSeasons = show.NumberOfSeasons;
            Accolades = show.Accolades;
        }

        public GeneralShowViewModel(EditShowViewModel show)
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

        public EditShowViewModel(UserShowViewModel show)
        {
            MediaId = show.MediaId;
            PosterUri = show.PosterUri;
            MediaName = show.MediaName;
            DateOfRelease = show.DateOfRelease;
            NumberOfSeasons = show.NumberOfSeasons;
            Accolades = show.Accolades;
        }

        public EditShowViewModel(GeneralShowViewModel show)
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