﻿using FilmHaus.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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

        public int Rating { get; set; }
    }
}