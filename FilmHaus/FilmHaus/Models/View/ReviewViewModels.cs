using FilmHaus.Enums;
using FilmHaus.Localization;
using FilmHaus.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FilmHaus.Models.View
{
    public class BaseReviewViewModel
    {
        public BaseReviewViewModel()
        {
        }

        public BaseReviewViewModel(Review review)
        {
            ReviewId = review.ReviewId;
            Id = review.Id;
            Body = review.Body;
            Shared = review.Shared;
            Flagged = review.Flagged;
            CreatedOn = review.CreatedOn;
            ReviewType = review.ReviewType;
        }

        [Display(Name = "Id", ResourceType = typeof(Locale))]
        public Guid ReviewId { get; set; }

        [Display(Name = "Id", ResourceType = typeof(Locale))]
        public string Id { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Description", ResourceType = typeof(Locale))]
        public string Body { get; set; }

        [Display(Name = "Shared", ResourceType = typeof(Locale))]
        public bool Shared { get; set; }

        [Display(Name = "", ResourceType = typeof(Locale))]
        public bool? Flagged { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "", ResourceType = typeof(Locale))]
        public DateTime CreatedOn { get; set; }

        public ReviewType ReviewType { get; set; }
    }

    public class ExpandedReviewViewModel : BaseReviewViewModel
    {
        public ExpandedReviewViewModel() : base()
        {
        }

        public ExpandedReviewViewModel(Review review) : base(review)
        {
        }

        public MediaViewModel Media { get; set; }
    }

    public class CreateReviewViewModel
    {
        public CreateReviewViewModel()
        {
        }

        public CreateReviewViewModel(Guid mediaId, ReviewType reviewType)
        {
            MediaId = mediaId;
            ReviewType = reviewType;
        }

        public Guid MediaId { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Description", ResourceType = typeof(Locale))]
        public string Body { get; set; }

        [Required]
        [Display(Name = "Shared", ResourceType = typeof(Locale))]
        public bool Shared { get; set; }

        [Required]
        public ReviewType ReviewType { get; set; }
    }

    public class EditReviewViewModel
    {
        public EditReviewViewModel()
        {
        }

        public EditReviewViewModel(Review review)
        {
            ReviewId = review.ReviewId;
            Id = review.Id;
            Body = review.Body;
            Shared = review.Shared;
            ReviewType = review.ReviewType;
        }

        public EditReviewViewModel(BaseReviewViewModel review)
        {
            ReviewId = review.ReviewId;
            Id = review.Id;
            Body = review.Body;
            Shared = review.Shared;
            ReviewType = review.ReviewType;
        }

        [Display(Name = "Id", ResourceType = typeof(Locale))]
        public Guid ReviewId { get; set; }

        [Display(Name = "Id", ResourceType = typeof(Locale))]
        public string Id { get; set; }

        [Display(Name = "Id", ResourceType = typeof(Locale))]
        public Guid MediaId { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Description", ResourceType = typeof(Locale))]
        public string Body { get; set; }

        [Required]
        [Display(Name = "Shared", ResourceType = typeof(Locale))]
        public bool Shared { get; set; }

        [Required]
        public ReviewType ReviewType { get; set; }
    }
}