using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FilmHaus.Models.View;
using FilmHaus.Models;
using FilmHaus.Models.Base;
using FilmHaus.Models.Connector;
using System.Data.Entity;

namespace FilmHaus.Services.Reviews
{
    public class ReviewService : IReviewService
    {
        private FilmHausDbContext FilmHausDbContext { get; set; }

        public ReviewService(FilmHausDbContext filmHausDbContext)
        {
            FilmHausDbContext = filmHausDbContext;
        }

        public void CreateReviewForFilm(CreateReviewViewModel review, string userId)
        {
            var newReview = new Review()
            {
                ReviewId = Guid.NewGuid(),
                Id = userId,
                Body = review.Body,
                Shared = review.Shared,
                CreatedOn = DateTime.Now,
                Flagged = false,
            };

            FilmHausDbContext.Reviews.Add(newReview);

            var newReviewFilm = new ReviewFilm()
            {
                ReviewFilmId = Guid.NewGuid(),
                ReviewId = newReview.ReviewId,
                MediaId = review.MediaId,
                CreatedOn = newReview.CreatedOn,
                ObsoletedOn = null
            };

            FilmHausDbContext.ReviewFilms.Add(newReviewFilm);

            FilmHausDbContext.SaveChanges();
        }

        public void CreateReviewForShow(CreateReviewViewModel review, string userId)
        {
            var newReview = new Review()
            {
                ReviewId = Guid.NewGuid(),
                Id = userId,
                Body = review.Body,
                Shared = review.Shared,
                CreatedOn = DateTime.Now,
                Flagged = false,
            };

            FilmHausDbContext.Reviews.Add(newReview);

            var newReviewShow = new ReviewShow()
            {
                ReviewShowId = Guid.NewGuid(),
                ReviewId = newReview.ReviewId,
                MediaId = review.MediaId,
                CreatedOn = newReview.CreatedOn,
                ObsoletedOn = null
            };

            FilmHausDbContext.ReviewShows.Add(newReviewShow);

            FilmHausDbContext.SaveChanges();
        }

        public void DeleteReviewByReviewId(Guid reviewId)
        {
            try
            {
                var review = FilmHausDbContext.Reviews.Find(reviewId);

                if (review != null)
                {
                    foreach (var rf in FilmHausDbContext.ReviewFilms.Where(rf => rf.ReviewId == review.ReviewId).Select(rf => rf).ToList())
                        FilmHausDbContext.ReviewFilms.Remove(rf);
                    FilmHausDbContext.SaveChanges();

                    foreach (var rs in FilmHausDbContext.ReviewShows.Where(rs => rs.ReviewId == review.ReviewId).Select(rs => rs).ToList())
                        FilmHausDbContext.ReviewShows.Remove(rs);
                    FilmHausDbContext.SaveChanges();

                    FilmHausDbContext.Reviews.Remove(review);
                    FilmHausDbContext.SaveChanges();
                }
                else
                    throw new ArgumentNullException();
            }
            catch (InvalidOperationException ex)
            {
                throw ex;
            }
        }

        public List<ReviewViewModel> GetAllFlaggedReviews()
        {
            var result = FilmHausDbContext.ReviewFilms.Where(r => r.Review.Flagged == true)
                .Select(r => new ReviewViewModel(r.Review)
                {
                    Media = new FilmViewModel(r.Film)
                })
                .ToList();

            var supplement = FilmHausDbContext.ReviewShows.Where(r => r.Review.Flagged == true)
                .Select(r => new ReviewViewModel(r.Review)
                {
                    Media = new ShowViewModel(r.Show)
                })
                .ToList();

            result.AddRange(supplement);
            result.Sort();

            return result;
        }

        public List<ReviewViewModel> GetAllFlaggedReviewsByFilmId(Guid mediaId)
        {
            return FilmHausDbContext.ReviewFilms.Where(r => r.Film.MediaId == mediaId && r.Review.Flagged)
                .Select(r => new ReviewViewModel(r.Review)
                {
                    Media = new FilmViewModel(r.Film)
                })
                .ToList();
        }

        public List<ReviewViewModel> GetAllFlaggedReviewsByShowId(Guid mediaId)
        {
            return FilmHausDbContext.ReviewShows.Where(r => r.Show.MediaId == mediaId && r.Review.Shared)
                .Select(r => new ReviewViewModel(r.Review)
                {
                    Media = new ShowViewModel(r.Show)
                })
                .ToList();
        }

        public List<ReviewViewModel> GetAllFlaggedReviewsByUserId(string userId)
        {
            throw new NotImplementedException();
        }

        public List<ReviewViewModel> GetAllReviews()
        {
            throw new NotImplementedException();
        }

        public List<ReviewViewModel> GetAllReviewsByFilmId(Guid mediaId)
        {
            return FilmHausDbContext.ReviewFilms.Where(r => r.Film.MediaId == mediaId)
                .Select(r => new ReviewViewModel(r.Review)
                {
                    Media = new FilmViewModel(r.Film)
                })
                .ToList();
        }

        public List<ReviewViewModel> GetAllReviewsByShowId(Guid mediaId)
        {
            return FilmHausDbContext.ReviewShows.Where(r => r.Show.MediaId == mediaId)
                .Select(r => new ReviewViewModel(r.Review)
                {
                    Media = new ShowViewModel(r.Show)
                })
                .ToList();
        }

        public List<ReviewViewModel> GetAllReviewsByUserId(string userId)
        {
            var result = FilmHausDbContext.ReviewFilms.Where(r => r.Review.Id == userId)
                .Select(r => new ReviewViewModel(r.Review)
                {
                    Media = new FilmViewModel(r.Film)
                })
                .ToList();

            var supplement = FilmHausDbContext.ReviewShows.Where(r => r.Review.Id == userId)
                .Select(r => new ReviewViewModel(r.Review)
                {
                    Media = new ShowViewModel(r.Show)
                })
                .ToList();

            result.AddRange(supplement);
            result.Sort();

            return result;
        }

        public List<ReviewViewModel> GetAllSharedReviews()
        {
            var result = FilmHausDbContext.ReviewFilms.Where(r => r.Review.Shared == true)
                .Select(r => new ReviewViewModel(r.Review)
                {
                    Media = new FilmViewModel(r.Film)
                })
                .ToList();

            var supplement = FilmHausDbContext.ReviewShows.Where(r => r.Review.Shared == true)
                .Select(r => new ReviewViewModel(r.Review)
                {
                    Media = new ShowViewModel(r.Show)
                })
                .ToList();

            result.AddRange(supplement);
            result.Sort();

            return result;
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
            try
            {
                var result = FilmHausDbContext.Reviews.Find(reviewId);

                if (result == null)
                    throw new ArgumentNullException();

                result.Body = review.Body;
                result.Shared = review.Shared;

                FilmHausDbContext.Entry(result).State = EntityState.Modified;
                FilmHausDbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public List<ReviewViewModel> GetAllSharedReviewsByFilmId(Guid mediaId)
        {
            return FilmHausDbContext.ReviewFilms.Where(r => r.Film.MediaId == mediaId && r.Review.Shared)
                .Select(r => new ReviewViewModel(r.Review)
                {
                    Media = new FilmViewModel(r.Film)
                })
                .ToList();
        }

        public List<ReviewViewModel> GetAllSharedReviewsByShowId(Guid mediaId)
        {
            return FilmHausDbContext.ReviewShows.Where(r => r.Show.MediaId == mediaId && r.Review.Shared)
                .Select(r => new ReviewViewModel(r.Review)
                {
                    Media = new ShowViewModel(r.Show)
                })
                .ToList();
        }
    }
}