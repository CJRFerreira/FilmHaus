using System;
using FilmHaus.Models.Base;
using System.ComponentModel.DataAnnotations;
using FilmHaus.Localization;
using System.Collections.Generic;
using FilmHaus.Enums;

namespace FilmHaus.Models.View
{
    public class FilmViewModel
    {
        public FilmViewModel()
        {
        }

        public FilmViewModel(Film film)
        {
            MediaId = film.MediaId;
            PosterUri = film.PosterUri;
            MediaName = film.MediaName;
            DateOfRelease = film.DateOfRelease;
            Runtime = film.Runtime;
            Accolades = film.Accolades;
        }

        public FilmViewModel(EditFilmViewModel film)
        {
            MediaId = film.MediaId;
            PosterUri = film.PosterUri;
            MediaName = film.MediaName;
            DateOfRelease = film.DateOfRelease;
            Runtime = film.Runtime;
            Accolades = film.Accolades;
        }

        [Display(Name = "Id", ResourceType = typeof(Locale))]
        public Guid MediaId { get; set; }

        [DataType(DataType.ImageUrl)]
        public Uri PosterUri { get; set; }

        [Display(Name = "Title", ResourceType = typeof(Locale))]
        public string MediaName { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "ReleaseDate", ResourceType = typeof(Locale))]
        public DateTimeOffset DateOfRelease { get; set; }

        [Display(Name = "Runtime", ResourceType = typeof(Locale))]
        public int Runtime { get; set; }

        [Display(Name = "Rating", ResourceType = typeof(Locale))]
        public int? Rating { get; set; }

        [Display(Name = "Accolades", ResourceType = typeof(Locale))]
        public AwardStatus Accolades { get; set; }
    }

    public class CreateFilmViewModel
    {
        public CreateFilmViewModel()
        {
        }

        [DataType(DataType.ImageUrl)]
        public Uri PosterUri { get; set; }

        [Display(Name = "Title", ResourceType = typeof(Locale))]
        [Required]
        public string MediaName { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "ReleaseDate", ResourceType = typeof(Locale))]
        public DateTime DateOfRelease { get; set; }

        [Display(Name = "Runtime", ResourceType = typeof(Locale))]
        public int Runtime { get; set; }

        [Display(Name = "Accolades", ResourceType = typeof(Locale))]
        public AwardStatus Accolades { get; set; }
    }

    public class EditFilmViewModel
    {
        public EditFilmViewModel()
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

        public EditFilmViewModel(FilmViewModel film)
        {
            MediaId = film.MediaId;
            PosterUri = film.PosterUri;
            MediaName = film.MediaName;
            DateOfRelease = film.DateOfRelease;
            Runtime = film.Runtime;
            Accolades = film.Accolades;
        }

        [Display(Name = "Id", ResourceType = typeof(Locale))]
        public Guid MediaId { get; set; }

        [DataType(DataType.ImageUrl)]
        public Uri PosterUri { get; set; }

        [Required]
        [Display(Name = "Title", ResourceType = typeof(Locale))]
        public string MediaName { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "ReleaseDate", ResourceType = typeof(Locale))]
        public DateTimeOffset DateOfRelease { get; set; }

        [Display(Name = "Runtime", ResourceType = typeof(Locale))]
        public int Runtime { get; set; }

        [Display(Name = "Accolades", ResourceType = typeof(Locale))]
        public AwardStatus Accolades { get; set; }
    }
}