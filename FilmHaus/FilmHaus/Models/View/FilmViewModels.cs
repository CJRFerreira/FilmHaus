using System;
using FilmHaus.Models.Base;
using System.ComponentModel.DataAnnotations;
using FilmHaus.Localization;
using System.Collections.Generic;

namespace FilmHaus.Models.View
{
    public class FilmViewModel
    {
        public FilmViewModel()
        {
        }

        public FilmViewModel(Film film)
        {
            PosterUri = film.PosterUri;
            FilmName = film.FilmName;
            DateOfRelease = film.DateOfRelease;
            Runtime = film.Runtime;
            Accolades = film.Accolades;
        }

        [DataType(DataType.ImageUrl)]
        public Uri PosterUri { get; set; }

        [Display(Name = "Title", ResourceType = typeof(Locale))]
        public string FilmName { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "ReleaseDate", ResourceType = typeof(Locale))]
        public DateTime DateOfRelease { get; set; }

        [Display(Name = "Runtime", ResourceType = typeof(Locale))]
        public int Runtime { get; set; }

        [Display(Name = "Rating", ResourceType = typeof(Locale))]
        public int? Rating { get; set; }

        [Display(Name = "Accolades", ResourceType = typeof(Locale))]
        public string Accolades { get; set; }
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
        public string FilmName { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "ReleaseDate", ResourceType = typeof(Locale))]
        public DateTime DateOfRelease { get; set; }

        [Display(Name = "Runtime", ResourceType = typeof(Locale))]
        public int Runtime { get; set; }

        [Display(Name = "Accolades", ResourceType = typeof(Locale))]
        public string Accolades { get; set; }
    }

    public class EditFilmViewModel
    {
        public EditFilmViewModel()
        {
        }

        public EditFilmViewModel(Film film)
        {
            PosterUri = film.PosterUri;
            FilmName = film.FilmName;
            DateOfRelease = film.DateOfRelease;
            Runtime = film.Runtime;
            Accolades = film.Accolades;
        }

        public EditFilmViewModel(FilmViewModel film)
        {
            PosterUri = film.PosterUri;
            FilmName = film.FilmName;
            DateOfRelease = film.DateOfRelease;
            Runtime = film.Runtime;
            Accolades = film.Accolades;
        }

        [DataType(DataType.ImageUrl)]
        public Uri PosterUri { get; set; }

        [Required]
        [Display(Name = "Title", ResourceType = typeof(Locale))]
        public string FilmName { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "ReleaseDate", ResourceType = typeof(Locale))]
        public DateTime DateOfRelease { get; set; }

        [Display(Name = "Runtime", ResourceType = typeof(Locale))]
        public int Runtime { get; set; }

        [Display(Name = "Accolades", ResourceType = typeof(Locale))]
        public string Accolades { get; set; }
    }
}