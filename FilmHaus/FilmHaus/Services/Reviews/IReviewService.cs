using FilmHaus.Models.View;
using System;
using System.Collections.Generic;

namespace FilmHaus.Services.Reviews
{
    public interface IReviewService
    {
        void CreateReviewForFilm(CreateReviewViewModel review, string userId);

        void CreateReviewForShow(CreateReviewViewModel review, string userId);

        void DeleteReviewByReviewId(Guid reviewId);

        void UpdateReviewByReviewId(Guid reviewId, EditReviewViewModel review);
    }
}