using System;
using FilmHaus.Models.Base;
using System.ComponentModel.DataAnnotations;
using FilmHaus.Localization;
using System.Collections.Generic;
using FilmHaus.Enums;

namespace FilmHaus.Models.View
{
    public class UserFilmViewModel : MediaViewModel
    {
        public UserFilmViewModel() : base()
        {
        }

        public UserFilmViewModel(Film film)
        {
            MediaId = film.MediaId;
            PosterUri = film.PosterUri;
            MediaName = film.MediaName;
            DateOfRelease = film.DateOfRelease;
            Runtime = film.Runtime;
            Accolades = film.Accolades;
        }

        public UserFilmViewModel(EditFilmViewModel film)
        {
            MediaId = film.MediaId;
            PosterUri = film.PosterUri;
            MediaName = film.MediaName;
            DateOfRelease = film.DateOfRelease;
            Runtime = film.Runtime;
            Accolades = film.Accolades;
        }

        [Display(Name = "Runtime", ResourceType = typeof(Locale))]
        public int Runtime { get; set; }
    }

    public class GeneralFilmViewModel : MediaViewModel
    {
        public GeneralFilmViewModel() : base()
        {
        }

        public GeneralFilmViewModel(Film film)
        {
            MediaId = film.MediaId;
            PosterUri = film.PosterUri;
            MediaName = film.MediaName;
            DateOfRelease = film.DateOfRelease;
            Runtime = film.Runtime;
            Accolades = film.Accolades;
        }

        public GeneralFilmViewModel(EditFilmViewModel film)
        {
            MediaId = film.MediaId;
            PosterUri = film.PosterUri;
            MediaName = film.MediaName;
            DateOfRelease = film.DateOfRelease;
            Runtime = film.Runtime;
            Accolades = film.Accolades;
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

        public EditFilmViewModel(Film film)
        {
            MediaId = film.MediaId;
            PosterUri = film.PosterUri;
            MediaName = film.MediaName;
            DateOfRelease = film.DateOfRelease;
            Runtime = film.Runtime;
            Accolades = film.Accolades;
        }

        public EditFilmViewModel(UserFilmViewModel film)
        {
            MediaId = film.MediaId;
            PosterUri = film.PosterUri;
            MediaName = film.MediaName;
            DateOfRelease = film.DateOfRelease;
            Runtime = film.Runtime;
            Accolades = film.Accolades;
        }

        public EditFilmViewModel(GeneralFilmViewModel film)
        {
            MediaId = film.MediaId;
            PosterUri = film.PosterUri;
            MediaName = film.MediaName;
            DateOfRelease = film.DateOfRelease;
            Runtime = film.Runtime;
            Accolades = film.Accolades;
        }

        [Display(Name = "Runtime", ResourceType = typeof(Locale))]
        public int Runtime { get; set; }
    }
}