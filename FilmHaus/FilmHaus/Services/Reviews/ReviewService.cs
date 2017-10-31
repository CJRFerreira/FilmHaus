using System;
using System.Collections.Generic;
using System.Linq;
using FilmHaus.Enums;
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
                ReviewType = ReviewType.Film
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
                ReviewType = ReviewType.Show
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
                    if (review.ReviewType == ReviewType.Film)
                        foreach (var rf in FilmHausDbContext.ReviewFilms.Where(rf => rf.ReviewId == review.ReviewId).Select(rf => rf).ToList())
                            FilmHausDbContext.ReviewFilms.Remove(rf);

                    if (review.ReviewType == ReviewType.Show)
                        foreach (var rs in FilmHausDbContext.ReviewShows.Where(rs => rs.ReviewId == review.ReviewId).Select(rs => rs).ToList())
                            FilmHausDbContext.ReviewShows.Remove(rs);

                    if (review.ReviewType == ReviewType.Season)
                        foreach (var rs in FilmHausDbContext.ReviewShows.Where(rs => rs.ReviewId == review.ReviewId).Select(rs => rs).ToList())
                            FilmHausDbContext.ReviewShows.Remove(rs);

                    if (review.ReviewType == ReviewType.Episode)
                        foreach (var re in FilmHausDbContext.ReviewShows.Where(re => re.ReviewId == review.ReviewId).Select(re => re).ToList())
                            FilmHausDbContext.ReviewShows.Remove(re);

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
                    Media = new GeneralFilmViewModel(r.Film)
                })
                .ToList();

            var supplement = FilmHausDbContext.ReviewShows.Where(r => r.Review.Flagged == true)
                .Select(r => new ReviewViewModel(r.Review)
                {
                    Media = new GeneralShowViewModel(r.Show)
                })
                .ToList();

            result.AddRange(supplement);
            result.Sort();

            return result;
        }

        public List<ReviewViewModel> GetAllFlaggedReviewsByUserId(string userId)
        {
            throw new NotImplementedException();
        }

        public List<ReviewViewModel> GetAllReviews()
        {
            throw new NotImplementedException();
        }

        public List<ReviewViewModel> GetAllReviewsByUserId(string userId)
        {
            var result = FilmHausDbContext.ReviewFilms.Where(r => r.Review.Id == userId)
                .Select(r => new ReviewViewModel(r.Review)
                {
                    Media = new GeneralFilmViewModel(r.Film)
                })
                .ToList();

            var supplement = FilmHausDbContext.ReviewShows.Where(r => r.Review.Id == userId)
                .Select(r => new ReviewViewModel(r.Review)
                {
                    Media = new GeneralShowViewModel(r.Show)
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
                    Media = new GeneralFilmViewModel(r.Film)
                })
                .ToList();

            var supplement = FilmHausDbContext.ReviewShows.Where(r => r.Review.Shared == true)
                .Select(r => new ReviewViewModel(r.Review)
                {
                    Media = new GeneralShowViewModel(r.Show)
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
    }
}