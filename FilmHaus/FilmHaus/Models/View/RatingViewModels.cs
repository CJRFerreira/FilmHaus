using FilmHaus.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

/// <summary>
/// Name: Christian Ferreira
/// Date: September 6th - January 5th
///
/// Statement of Authorship:
/// I, Christian Ferreira (Student #: 000346210), certify that this material is my original work.
/// No other person's work has been used without due acknowledgement.
/// </summary>
namespace FilmHaus.Models.View
{
    public class AddRatingViewModel
    {
        public AddRatingViewModel()
        {
        }

        public AddRatingViewModel(Guid mediaId, MediaType mediaType)
        {
            MediaId = mediaId;
            MediaType = mediaType;
        }

        public Guid MediaId { get; set; }

        public MediaType MediaType { get; set; }

        [Range(1,10)]
        public int Rating { get; set; } = 1;
    }

    public class ChangeRatingViewModel
    {
        public ChangeRatingViewModel()
        {
        }

        public ChangeRatingViewModel(Guid mediaId, MediaType mediaType)
        {
            MediaId = mediaId;
            MediaType = mediaType;
        }

        public ChangeRatingViewModel(Guid mediaId, MediaType mediaType, int rating)
        {
            MediaId = mediaId;
            MediaType = mediaType;
            Rating = rating;
        }

        public Guid MediaId { get; set; }

        public MediaType MediaType { get; set; }

        [Range(1, 10)]
        public int Rating { get; set; }
    }
}