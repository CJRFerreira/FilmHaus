using FilmHaus.Models.Base;
using FilmHaus.Models.View;
using System;
using System.Collections.Generic;

namespace FilmHaus.Services.Reviews
{
    public interface IReviewService
    {
        Review CreateReview(CreateReviewViewModel review, string userId);

        void CreateReviewForFilm(CreateReviewViewModel review, string userId);

        void CreateReviewForShow(CreateReviewViewModel review, string userId);

        void DeleteReviewByReviewId(Guid reviewId);

        void UpdateReviewByReviewId(Guid reviewId, EditReviewViewModel review);

        BaseReviewViewModel GetReviewByReviewId(Guid reviewId);

        ExpandedReviewViewModel GetReviewWithMediaByReviewId(Guid reviewId);

        ReviewLibraryViewModel GetAllSharedReviews();

        ReviewLibraryViewModel GetAllReviewsByUserId(string userId);

        ReviewLibraryViewModel GetAllReviews();

        ReviewLibraryViewModel GetAllFlaggedReviewsByUserId(string userId);

        ReviewLibraryViewModel GetAllFlaggedReviews();
    }
}