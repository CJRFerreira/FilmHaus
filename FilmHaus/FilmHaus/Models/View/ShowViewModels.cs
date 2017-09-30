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
    public class ShowViewModel
    {
        public ShowViewModel()
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
        public int NumberOfSeasons { get; set; }

        [Display(Name = "Rating", ResourceType = typeof(Locale))]
        public int Rating { get; set; }

        [Display(Name = "Accolades", ResourceType = typeof(Locale))]
        public AwardStatus Accolades { get; set; }
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
        public string MediaName { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "ReleaseDate", ResourceType = typeof(Locale))]
        public DateTimeOffset DateOfRelease { get; set; }

        [Display(Name = "Runtime", ResourceType = typeof(Locale))]
        public int Runtime { get; set; }

        [Display(Name = "Accolades", ResourceType = typeof(Locale))]
        public AwardStatus Accolades { get; set; }
    }

    public class EditShowViewModel
    {
        public EditShowViewModel()
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

        [Display(Name = "Id", ResourceType = typeof(Locale))]
        public Guid MediaId { get; set; }

        [DataType(DataType.ImageUrl)]
        public Uri PosterUri { get; set; }

        [Display(Name = "Title", ResourceType = typeof(Locale))]
        [Required]
        public string MediaName { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "ReleaseDate", ResourceType = typeof(Locale))]
        public DateTimeOffset DateOfRelease { get; set; }

        [Display(Name = "Runtime", ResourceType = typeof(Locale))]
        public int NumberOfSeasons { get; set; }

        [Display(Name = "Accolades", ResourceType = typeof(Locale))]
        public AwardStatus Accolades { get; set; }
    }
}