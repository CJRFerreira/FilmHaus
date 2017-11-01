using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using FilmHaus.Enums;
using FilmHaus.Models;
using FilmHaus.Models.View;
using FilmHaus.Models.Base;
using FilmHaus.Models.Connector;
using FilmHaus.Services.ReviewFilms;
using FilmHaus.Services.ReviewShows;
using LinqKit;

namespace FilmHaus.Services.Reviews
{
    public class ReviewService : IReviewService
    {
        private FilmHausDbContext FilmHausDbContext { get; set; }

        private IReviewFilmService ReviewFilmService { get; set; }

        private IReviewShowService ReviewShowService { get; set; }

        public ReviewService(FilmHausDbContext filmHausDbContext, IReviewFilmService reviewFilmService, IReviewShowService reviewShowService)
        {
            FilmHausDbContext = filmHausDbContext;
            ReviewShowService = reviewShowService;
            ReviewFilmService = reviewFilmService;
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
            FilmHausDbContext.SaveChanges();

            ReviewFilmService.CreateReviewFilm(newReview.ReviewId, review.MediaId);
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
            FilmHausDbContext.SaveChanges();

            ReviewShowService.CreateReviewShow(newReview.ReviewId, review.MediaId);
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

                    //if (review.ReviewType == ReviewType.Season)
                    //    foreach (var rs in FilmHausDbContext.ReviewSeasons.Where(rs => rs.ReviewId == review.ReviewId).Select(rs => rs).ToList())
                    //        FilmHausDbContext.ReviewShows.Remove(rs);

                    //if (review.ReviewType == ReviewType.Episode)
                    //    foreach (var re in FilmHausDbContext.ReviewEpisodes.Where(re => re.ReviewId == review.ReviewId).Select(re => re).ToList())
                    //        FilmHausDbContext.ReviewShows.Remove(re);

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
                .Select(r => r.Review)
                .Select(ReviewQueryExtensions.GetReviewViewModelWithFilm())
                .ToList();

            var supplement = FilmHausDbContext.ReviewShows.Where(r => r.Review.Flagged == true)
                .Select(r => r.Review)
                .Select(ReviewQueryExtensions.GetReviewViewModelWithShow())
                .ToList();

            result.AddRange(supplement);
            result.Sort();

            return result;
        }

        public List<ReviewViewModel> GetAllFlaggedReviewsByUserId(string userId)
        {
            var result = FilmHausDbContext.ReviewFilms.Where(r => r.Review.Flagged == true && r.Review.Id == userId)
                .Select(r => r.Review)
                .Select(ReviewQueryExtensions.GetReviewViewModelWithFilm())
                .ToList();

            var supplement = FilmHausDbContext.ReviewShows.Where(r => r.Review.Flagged == true && r.Review.Id == userId)
                .Select(r => r.Review)
                .Select(ReviewQueryExtensions.GetReviewViewModelWithShow())
                .ToList();

            result.AddRange(supplement);
            result.Sort();

            return result;
        }

        public List<ReviewViewModel> GetAllReviews()
        {
            var result = FilmHausDbContext.ReviewFilms
                .Select(r => r.Review)
                .Select(ReviewQueryExtensions.GetReviewViewModelWithFilm())
                .ToList();

            var supplement = FilmHausDbContext.ReviewShows
                .Select(r => r.Review)
                .Select(ReviewQueryExtensions.GetReviewViewModelWithShow())
                .ToList();

            result.AddRange(supplement);
            result.Sort();

            return result;
        }

        public List<ReviewViewModel> GetAllReviewsByUserId(string userId)
        {
            var result = FilmHausDbContext.ReviewFilms.Where(r => r.Review.Id == userId)
                .Select(r => r.Review)
                .Select(ReviewQueryExtensions.GetReviewViewModelWithFilm())
                .ToList();

            var supplement = FilmHausDbContext.ReviewShows.Where(r => r.Review.Id == userId)
                .Select(r => r.Review)
                .Select(ReviewQueryExtensions.GetReviewViewModelWithShow())
                .ToList();

            result.AddRange(supplement);
            result.Sort();

            return result;
        }

        public List<ReviewViewModel> GetAllSharedReviews()
        {
            var result = FilmHausDbContext.ReviewFilms.Where(r => r.Review.Shared == true)
                .Select(r => r.Review)
                .Select(ReviewQueryExtensions.GetReviewViewModelWithFilm())
                .ToList();

            var supplement = FilmHausDbContext.ReviewShows.Where(r => r.Review.Shared == true)
                .Select(r => r.Review)
                .Select(ReviewQueryExtensions.GetReviewViewModelWithShow())
                .ToList();

            result.AddRange(supplement);
            result.Sort();

            return result;
        }

        public ReviewViewModel GetReviewByReviewId(Guid reviewId)
        {
            try
            {
                var result = FilmHausDbContext.Reviews.Find(reviewId);

                if (result == null)
                    throw new ArgumentNullException();

                switch (result.ReviewType)
                {
                    case ReviewType.Film:
                        var reviewFilmQuery = ReviewQueryExtensions.GetReviewViewModelWithFilm();
                        return reviewFilmQuery.Invoke(result);

                    case ReviewType.Show:
                        var reviewShowQuery = ReviewQueryExtensions.GetReviewViewModelWithShow();
                        return reviewShowQuery.Invoke(result);

                    case ReviewType.Season:
                    //var reviewSeasonQuery = ReviewQueryExtensions.GetReviewViewModelWithSeason();
                    //return reviewSeasonQuery.Invoke(result);

                    case ReviewType.Episode:
                    //var reviewEpisodeQuery = ReviewQueryExtensions.GetReviewViewModelWithEpisode();
                    //return reviewEpisodeQuery.Invoke(result);

                    default:
                        return new ReviewViewModel(result);
                }
            }
            catch (InvalidOperationException ex)
            {
                throw ex;
            }
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
            catch (InvalidOperationException ex)
            {
                throw ex;
            }
        }
    }
}