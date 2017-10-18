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

        List<ReviewViewModel> GetAllFlaggedReviews();

        List<ReviewViewModel> GetAllFlaggedReviewsForShow(Guid reviewId);

        List<ReviewViewModel> GetAllFlaggedReviewsForFilm(Guid reviewId);

        List<ReviewViewModel> GetAllFlaggedReviewsForUser(string userId);

        List<ReviewViewModel> GetAllReviewsForUser(string userId);

        List<ReviewViewModel> GetAllReviewsForShow(Guid reviewId);

        List<ReviewViewModel> GetAllReviewsForFilm(Guid reviewId);

        void CreateReview(CreateReviewViewModel review);

        void DeleteReviewByReviewId(Guid reviewId);

        void ObsoleteReviewByReviewId(Guid reviewId);

        void UpdateReviewByReviewId(Guid reviewId, EditReviewViewModel review);
    }
}