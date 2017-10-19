using FilmHaus.Models.View;
using System;
using System.Collections.Generic;

namespace FilmHaus.Services.Reviews
{
    public interface IReviewService
    {
        ReviewViewModel GetReviewByReviewId(Guid reviewId);

        List<ReviewViewModel> GetAllReviews();

        List<ReviewViewModel> GetAllSharedReviews();

        List<ReviewViewModel> GetAllSharedReviewsByFilmId(Guid mediaId);

        List<ReviewViewModel> GetAllSharedReviewsByShowId(Guid mediaId);

        List<ReviewViewModel> GetAllFlaggedReviews();

        List<ReviewViewModel> GetAllFlaggedReviewsByFilmId(Guid mediaId);

        List<ReviewViewModel> GetAllFlaggedReviewsByShowId(Guid mediaId);

        List<ReviewViewModel> GetAllFlaggedReviewsByUserId(string userId);

        List<ReviewViewModel> GetAllReviewsByUserId(string userId);

        List<ReviewViewModel> GetAllReviewsByShowId(Guid mediaId);

        List<ReviewViewModel> GetAllReviewsByFilmId(Guid mediaId);

        void CreateReviewForFilm(CreateReviewViewModel review, string userId);

        void CreateReviewForShow(CreateReviewViewModel review, string userId);

        void DeleteReviewByReviewId(Guid reviewId);

        void ObsoleteReviewByReviewId(Guid reviewId);

        void UpdateReviewByReviewId(Guid reviewId, EditReviewViewModel review);
    }
}