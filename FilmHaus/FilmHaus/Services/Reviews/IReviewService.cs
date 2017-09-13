using FilmHaus.Models.Base;
using FilmHaus.Models.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmHaus.Services.Reviews
{
    public interface IReviewService
    {
        Review GetReviewByReviewId(string id);

        List<Review> GetAllReviews();

        List<Review> GetAllSharedReviews();

        List<Review> GetAllReviewsForUser(string id);

        void CreateReview(CreateReviewViewModel film);

        void DeleteReviewByReviewId(string id);

        void UpdateReviewByReviewId(string id, EditReviewViewModel list);
    }
}