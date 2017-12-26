using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using LinqKit;
using FilmHaus.Enums;
using FilmHaus.Models;
using FilmHaus.Models.View;
using FilmHaus.Models.Base;
using FilmHaus.Services.ReviewFilms;
using FilmHaus.Services.ReviewShows;
using FilmHaus.Exceptions;
using static FilmHaus.Services.ReviewQueryExtensions;

namespace FilmHaus.Services.Reviews
{
    public class ReviewService : IReviewService
    {
        private FilmHausDbContext FilmHausDbContext { get; set; }

        private IReviewFilmService ReviewFilmService { get; }

        private IReviewShowService ReviewShowService { get; }

        public ReviewService(FilmHausDbContext filmHausDbContext, IReviewFilmService reviewFilmService, IReviewShowService reviewShowService)
        {
            FilmHausDbContext = filmHausDbContext;
            ReviewShowService = reviewShowService;
            ReviewFilmService = reviewFilmService;
        }

        public Review CreateReview(CreateReviewViewModel review, string userId)
        {
            return new Review()
            {
                ReviewId = Guid.NewGuid(),
                Id = userId,
                Body = review.Body,
                Shared = review.Shared,
                CreatedOn = DateTime.Now,
                Flagged = false,
                ReviewType = review.ReviewType
            };
        }

        public void CreateReviewForFilm(CreateReviewViewModel review, string userId)
        {
            var newReview = CreateReview(review, userId);

            FilmHausDbContext.Reviews.Add(newReview);
            FilmHausDbContext.SaveChanges();

            ReviewFilmService.CreateReviewFilm(newReview.ReviewId, review.MediaId);
        }

        public void CreateReviewForShow(CreateReviewViewModel review, string userId)
        {
            var newReview = CreateReview(review, userId);

            FilmHausDbContext.Reviews.Add(newReview);
            FilmHausDbContext.SaveChanges();

            ReviewShowService.CreateReviewShow(newReview.ReviewId, review.MediaId);
        }

        public void DeleteReviewByReviewId(Guid reviewId)
        {
            try
            {
                var review = FilmHausDbContext.Reviews.Find(reviewId);
                if (review == null)
                    throw new KeyNotFoundException($"No entity found for key: {reviewId}");

                switch (review.ReviewType)
                {
                    case ReviewType.Film:
                        foreach (var rf in FilmHausDbContext.ReviewFilms.Where(rf => rf.ReviewId == review.ReviewId).Select(rf => rf).ToList())
                            FilmHausDbContext.ReviewFilms.Remove(rf);
                        break;

                    case ReviewType.Show:
                        foreach (var rs in FilmHausDbContext.ReviewShows.Where(rs => rs.ReviewId == review.ReviewId).Select(rs => rs).ToList())
                            FilmHausDbContext.ReviewShows.Remove(rs);
                        break;

                    case ReviewType.Season:
                        //foreach (var rs in FilmHausDbContext.ReviewSeasons.Where(rs => rs.ReviewId == review.ReviewId).Select(rs => rs).ToList())
                        //    FilmHausDbContext.ReviewShows.Remove(rs);
                        break;

                    case ReviewType.Episode:
                        //foreach (var re in FilmHausDbContext.ReviewEpisodes.Where(re => re.ReviewId == review.ReviewId).Select(re => re).ToList())
                        //    FilmHausDbContext.ReviewShows.Remove(re);
                        break;

                    default:
                        throw new InvalidReviewTypeException($"Invalid Review Type! Given: {review.ReviewType}");
                }

                FilmHausDbContext.SaveChanges();

                FilmHausDbContext.Reviews.Remove(review);
                FilmHausDbContext.SaveChanges();
            }
            catch (InvalidOperationException ex)
            {
                throw ex;
            }
        }

        public ReviewLibraryViewModel GetAllFlaggedReviews()
        {
            var films = FilmHausDbContext.ReviewFilms.Where(r => r.Review.Flagged == true)
                .Select(r => r.Review)
                .Select(GetReviewViewModelWithFilm())
                .ToList();

            var shows = FilmHausDbContext.ReviewShows.Where(r => r.Review.Flagged == true)
                .Select(r => r.Review)
                .Select(GetReviewViewModelWithShow())
                .ToList();

            return new ReviewLibraryViewModel(films, shows);
        }

        public ReviewLibraryViewModel GetAllFlaggedReviewsByUserId(string userId)
        {
            var films = FilmHausDbContext.ReviewFilms.Where(r => r.Review.Flagged == true && r.Review.Id == userId)
                .Select(r => r.Review)
                .Select(GetReviewViewModelWithFilm())
                .ToList();

            var shows = FilmHausDbContext.ReviewShows.Where(r => r.Review.Flagged == true && r.Review.Id == userId)
                .Select(r => r.Review)
                .Select(GetReviewViewModelWithShow())
                .ToList();

            return new ReviewLibraryViewModel(films, shows);
        }

        public ReviewLibraryViewModel GetAllReviews()
        {
            var films = FilmHausDbContext.ReviewFilms
                .Select(r => r.Review)
                .Select(GetReviewViewModelWithFilm())
                .ToList();

            var shows = FilmHausDbContext.ReviewShows
                .Select(r => r.Review)
                .Select(GetReviewViewModelWithShow())
                .ToList();

            return new ReviewLibraryViewModel(films, shows);
        }

        public ReviewLibraryViewModel GetAllReviewsByUserId(string userId)
        {
            var films = FilmHausDbContext.ReviewFilms.Where(r => r.Review.Id == userId)
                .Select(r => r.Review)
                .Select(GetReviewViewModelWithFilm())
                .ToList();

            var shows = FilmHausDbContext.ReviewShows.Where(r => r.Review.Id == userId)
                .Select(r => r.Review)
                .Select(GetReviewViewModelWithShow())
                .ToList();

            return new ReviewLibraryViewModel(films, shows);
        }

        public ReviewLibraryViewModel GetAllSharedReviews()
        {
            var films = FilmHausDbContext.ReviewFilms.Where(r => r.Review.Shared == true)
                .Select(r => r.Review)
                .Select(GetReviewViewModelWithFilm())
                .ToList();

            var shows = FilmHausDbContext.ReviewShows.Where(r => r.Review.Shared == true)
                .Select(r => r.Review)
                .Select(GetReviewViewModelWithShow())
                .ToList();

            return new ReviewLibraryViewModel(films, shows);
        }

        public BaseReviewViewModel GetReviewByReviewId(Guid reviewId)
        {
            try
            {
                var result = FilmHausDbContext.Reviews.Find(reviewId);

                if (result == null)
                    throw new ArgumentNullException();

                return new BaseReviewViewModel(result);
            }
            catch (InvalidOperationException ex)
            {
                throw ex;
            }
        }

        public ExpandedReviewViewModel GetReviewWithMediaByReviewId(Guid reviewId)
        {
            try
            {
                var result = FilmHausDbContext.Reviews.Find(reviewId);

                if (result == null)
                    throw new ArgumentNullException();

                switch (result.ReviewType)
                {
                    case ReviewType.Film:
                        var reviewFilmQuery = GetReviewViewModelWithFilm();
                        return reviewFilmQuery.Invoke(result);

                    case ReviewType.Show:
                        var reviewShowQuery = GetReviewViewModelWithShow();
                        return reviewShowQuery.Invoke(result);

                    case ReviewType.Season:
                    //var reviewSeasonQuery = GetReviewViewModelWithSeason();
                    //return reviewSeasonQuery.Invoke(result);

                    case ReviewType.Episode:
                    //var reviewEpisodeQuery = GetReviewViewModelWithEpisode();
                    //return reviewEpisodeQuery.Invoke(result);

                    default:
                        return new ExpandedReviewViewModel(result);
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

        public void BanReviewByReviewId(Guid reviewId, ReportReason reportReason)
        {
            try
            {
                var result = FilmHausDbContext.Reviews.Find(reviewId);

                if (result == null)
                    throw new ArgumentNullException();

                result.ReportReason = reportReason;

                FilmHausDbContext.Entry(result).State = EntityState.Modified;
                FilmHausDbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void FlagReviewByReviewId(Guid reviewId)
        {
            try
            {
                var result = FilmHausDbContext.Reviews.Find(reviewId);

                if (result == null)
                    throw new ArgumentNullException();

                result.Flagged = true;

                FilmHausDbContext.Entry(result).State = EntityState.Modified;
                FilmHausDbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void UnflagReviewByReviewId(Guid reviewId)
        {
            try
            {
                var result = FilmHausDbContext.Reviews.Find(reviewId);

                if (result == null)
                    throw new ArgumentNullException();

                result.Flagged = false;

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