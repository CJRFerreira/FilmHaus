using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FilmHaus.Models.Base;
using FilmHaus.Localization;
using FilmHaus.Enums;

namespace FilmHaus.Models.View
{
    public abstract class MediaViewModel
    {
        public MediaViewModel()
        {
        }

        public MediaViewModel(Media media)
        {
            MediaId = media.MediaId;
            PosterUri = media.PosterUri;
            MediaName = media.MediaName;
            DateOfRelease = media.DateOfRelease;
            Accolades = media.Accolades;
        }

        public MediaViewModel(EditMediaViewModel media)
        {
            MediaId = media.MediaId;
            PosterUri = media.PosterUri;
            MediaName = media.MediaName;
            DateOfRelease = media.DateOfRelease;
            Accolades = media.Accolades;
        }

        [Display(Name = "Id", ResourceType = typeof(Locale))]
        public Guid MediaId { get; set; }

        [DataType(DataType.ImageUrl)]
        [Display(Name = "Poster", ResourceType = typeof(Locale))]
        public string PosterUri { get; set; }

        [Display(Name = "Title", ResourceType = typeof(Locale))]
        public string MediaName { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "ReleaseDate", ResourceType = typeof(Locale))]
        public DateTime DateOfRelease { get; set; }

        [Display(Name = "Rating", ResourceType = typeof(Locale))]
        public double? Rating { get; set; }

        [Display(Name = "Accolades", ResourceType = typeof(Locale))]
        public AwardStatus Accolades { get; set; }

        public BaseReviewViewModel UserReview { get; set; }

        public bool InCurrentUserLibrary { get; set; }

        public bool UserHasRated { get; set; }

        public ICollection<PersonTitleViewModel> Collaborators { get; set; }

        public ICollection<GenreViewModel> Genres { get; set; }

        public ICollection<TagViewModel> Tags { get; set; }

        public ICollection<BaseReviewViewModel> Reviews { get; set; }
    }

    public abstract class CreateMediaViewModel
    {
        public CreateMediaViewModel()
        {
        }

        [Required]
        [DataType(DataType.ImageUrl)]
        [Display(Name = "Poster", ResourceType = typeof(Locale))]
        public string PosterUri { get; set; }

        [Required]
        [Display(Name = "Title", ResourceType = typeof(Locale))]
        public string MediaName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "ReleaseDate", ResourceType = typeof(Locale))]
        public DateTime DateOfRelease { get; set; } = DateTime.Now;

        [Required]
        [Display(Name = "Accolades", ResourceType = typeof(Locale))]
        public AwardStatus Accolades { get; set; }
    }

    public abstract class EditMediaViewModel
    {
        public EditMediaViewModel()
        {
        }

        public EditMediaViewModel(Media media)
        {
            MediaId = media.MediaId;
            PosterUri = media.PosterUri;
            MediaName = media.MediaName;
            DateOfRelease = media.DateOfRelease;
            Accolades = media.Accolades;
        }

        public EditMediaViewModel(MediaViewModel media)
        {
            MediaId = media.MediaId;
            PosterUri = media.PosterUri;
            MediaName = media.MediaName;
            DateOfRelease = media.DateOfRelease;
            Accolades = media.Accolades;
        }

        [Display(Name = "Id", ResourceType = typeof(Locale))]
        public Guid MediaId { get; set; }

        [Required]
        [DataType(DataType.ImageUrl)]
        [Display(Name = "Poster", ResourceType = typeof(Locale))]
        public string PosterUri { get; set; }

        [Required]
        [Display(Name = "Title", ResourceType = typeof(Locale))]
        public string MediaName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "ReleaseDate", ResourceType = typeof(Locale))]
        public DateTime DateOfRelease { get; set; }

        [Required]
        [Display(Name = "Accolades", ResourceType = typeof(Locale))]
        public AwardStatus Accolades { get; set; }
    }
}