using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FilmHaus.Models.Base;
using System.ComponentModel.DataAnnotations;
using FilmHaus.Localization;

namespace FilmHaus.Models.View
{
    public class ShowViewModel
    {
        public ShowViewModel()
        {
        }

        public ShowViewModel(Show show)
        {
            PosterUri = show.PosterUri;
            ShowName = show.ShowName;
            DateOfRelease = show.DateOfRelease;
            NumberOfSeasons = show.NumberOfSeasons;
            Accolades = show.Accolades;
        }

        [DataType(DataType.ImageUrl)]
        public Uri PosterUri { get; set; }

        [Display(Name = "Title", ResourceType = typeof(Locale))]
        public String ShowName { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "ReleaseDate", ResourceType = typeof(Locale))]
        public DateTime DateOfRelease { get; set; }

        [Display(Name = "Runtime", ResourceType = typeof(Locale))]
        public Int32 NumberOfSeasons { get; set; }

        [Display(Name = "Rating", ResourceType = typeof(Locale))]
        public Int32 Rating { get; set; }

        [Display(Name = "Accolades", ResourceType = typeof(Locale))]
        public String Accolades { get; set; }
    }

    public class CreateShowViewModel
    {
        public CreateShowViewModel()
        {
        }

        [DataType(DataType.ImageUrl)]
        public Uri PosterUri { get; set; }

        [Display(Name = "Title", ResourceType = typeof(Locale))]
        [Required]
        public String ShowName { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "ReleaseDate", ResourceType = typeof(Locale))]
        public DateTime DateOfRelease { get; set; }

        [Display(Name = "Runtime", ResourceType = typeof(Locale))]
        public Int32 Runtime { get; set; }

        [Display(Name = "Accolades", ResourceType = typeof(Locale))]
        public String Accolades { get; set; }
    }

    public class EditShowViewModel
    {
        public EditShowViewModel()
        {
        }

        public EditShowViewModel(Show show)
        {
            PosterUri = show.PosterUri;
            ShowName = show.ShowName;
            DateOfRelease = show.DateOfRelease;
            NumberOfSeasons = show.NumberOfSeasons;
            Accolades = show.Accolades;
        }

        public EditShowViewModel(ShowViewModel show)
        {
            PosterUri = show.PosterUri;
            ShowName = show.ShowName;
            DateOfRelease = show.DateOfRelease;
            NumberOfSeasons = show.NumberOfSeasons;
            Accolades = show.Accolades;
        }

        [DataType(DataType.ImageUrl)]
        public Uri PosterUri { get; set; }

        [Display(Name = "Title", ResourceType = typeof(Locale))]
        [Required]
        public String ShowName { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "ReleaseDate", ResourceType = typeof(Locale))]
        public DateTime DateOfRelease { get; set; }

        [Display(Name = "Runtime", ResourceType = typeof(Locale))]
        public Int32 NumberOfSeasons { get; set; }

        [Display(Name = "Accolades", ResourceType = typeof(Locale))]
        public String Accolades { get; set; }
    }
}