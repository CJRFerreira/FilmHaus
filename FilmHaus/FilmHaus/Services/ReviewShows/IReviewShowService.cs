using FilmHaus.Models.View;
using System;
using System.Collections.Generic;

namespace FilmHaus.Services.ReviewShows
{
    public interface IReviewShowService
    {
        List<BaseReviewViewModel> GetAllSharedReviewsByShowId(Guid mediaId);

        List<BaseReviewViewModel> GetAllFlaggedReviewsByShowId(Guid mediaId);

        List<BaseReviewViewModel> GetAllReviewsByShowId(Guid mediaId);

        void CreateReviewShow(Guid reviewId, Guid mediaId);

        void DeleteReviewShow(Guid reviewShowId);

        void ObsoleteReviewShow(Guid reviewShowId);
    }
}