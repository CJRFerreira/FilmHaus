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

        List<ReviewViewModel> GetAllReviewsForUser(string userId);

        void CreateReview(CreateReviewViewModel film);

        void DeleteReviewByReviewId(Guid reviewId);

        void UpdateReviewByReviewId(Guid reviewId, EditReviewViewModel list);
    }
}