using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FilmHaus.Models.View;
using FilmHaus.Models;
using FilmHaus.Models.Base;

namespace FilmHaus.Services.Reviews
{
    public class ReviewService : IReviewService
    {
        private FilmHausDbContext FilmHausDbContext { get; set; }

        public ReviewService(FilmHausDbContext filmHausDbContext)
        {
            FilmHausDbContext = filmHausDbContext;
        }

        public void CreateReview(CreateReviewViewModel review)
        {
            FilmHausDbContext.Reviews.Add(new Review()
            {
                ReviewId = Guid.NewGuid()
            });
        }

        public void DeleteReviewByReviewId(Guid reviewId)
        {
            throw new NotImplementedException();
        }

        public List<ReviewViewModel> GetAllFlaggedReviews()
        {
            throw new NotImplementedException();
        }

        public List<ReviewViewModel> GetAllFlaggedReviewsForFilm(Guid reviewId)
        {
            throw new NotImplementedException();
        }

        public List<ReviewViewModel> GetAllFlaggedReviewsForShow(Guid reviewId)
        {
            throw new NotImplementedException();
        }

        public List<ReviewViewModel> GetAllFlaggedReviewsForUser(string userId)
        {
            throw new NotImplementedException();
        }

        public List<ReviewViewModel> GetAllReviews()
        {
            throw new NotImplementedException();
        }

        public List<ReviewViewModel> GetAllReviewsForFilm(Guid reviewId)
        {
            throw new NotImplementedException();
        }

        public List<ReviewViewModel> GetAllReviewsForShow(Guid reviewId)
        {
            throw new NotImplementedException();
        }

        public List<ReviewViewModel> GetAllReviewsForUser(string userId)
        {
            throw new NotImplementedException();
        }

        public List<ReviewViewModel> GetAllSharedReviews()
        {
            throw new NotImplementedException();
        }

        public ReviewViewModel GetReviewByReviewId(Guid reviewId)
        {
            throw new NotImplementedException();
        }

        public void ObsoleteReviewByReviewId(Guid reviewId)
        {
            throw new NotImplementedException();
        }

        public void UpdateReviewByReviewId(Guid reviewId, EditReviewViewModel review)
        {
            throw new NotImplementedException();
        }
    }
}