using FilmHaus.Localization;
using FilmHaus.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FilmHaus.Models.View
{
    public class ReviewViewModel
    {
        public ReviewViewModel()
        {
        }

        public ReviewViewModel(Review review)
        {
            Body = review.Body;
            Shared = review.Shared;
            Flagged = review.Flagged;
            DateOfCreation = review.DateOfCreation;
        }

        [DataType(DataType.MultilineText)]
        [Display(Name = "", ResourceType = typeof(Locale))]
        public string Body { get; set; }

        [Display(Name = "", ResourceType = typeof(Locale))]
        public bool Shared { get; set; }

        [Display(Name = "", ResourceType = typeof(Locale))]
        public bool? Flagged { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "", ResourceType = typeof(Locale))]
        public DateTime DateOfCreation { get; set; }
    }

    public class CreateReviewViewModel
    {
        public CreateReviewViewModel()
        {
        }

        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "", ResourceType = typeof(Locale))]
        public string Body { get; set; }

        [Required]
        [Display(Name = "", ResourceType = typeof(Locale))]
        public bool Shared { get; set; }

    }

    public class EditReviewViewModel
    {
        public EditReviewViewModel()
        {
        }

        public EditReviewViewModel(Review review)
        {
            Body = review.Body;
            Shared = review.Shared;
        }

        public EditReviewViewModel(ReviewViewModel review)
        {
            Body = review.Body;
            Shared = review.Shared;
        }

        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "", ResourceType = typeof(Locale))]
        public string Body { get; set; }

        [Required]
        [Display(Name = "", ResourceType = typeof(Locale))]
        public bool Shared { get; set; }

    }
}