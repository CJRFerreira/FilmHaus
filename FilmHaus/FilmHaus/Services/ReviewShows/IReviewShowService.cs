using FilmHaus.Models.View;
using System;
using System.Collections.Generic;

namespace FilmHaus.Services.ReviewShows
{
    public interface IReviewShowService
    {
        List<ReviewViewModel> GetAllSharedReviewsByShowId(Guid mediaId);

        List<ReviewViewModel> GetAllFlaggedReviewsByShowId(Guid mediaId);

        List<ReviewViewModel> GetAllReviewsByShowId(Guid mediaId);

        void CreateReviewShow(Guid reviewId, Guid mediaId);

        void DeleteReviewShow(Guid reviewShowId);

        void ObsoleteReviewShow(Guid reviewShowId);
    }
}