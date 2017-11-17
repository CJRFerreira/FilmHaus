using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using FilmHaus.Models;
using FilmHaus.Models.View;
using FilmHaus.Models.Connector;
using static FilmHaus.Services.ReviewQueryExtensions;
using LinqKit;

namespace FilmHaus.Services.ReviewFilms
{
    public class ReviewFilmService : IReviewFilmService
    {
        private FilmHausDbContext FilmHausDbContext { get; }

        public ReviewFilmService(FilmHausDbContext filmHausDbContext)
        {
            FilmHausDbContext = filmHausDbContext;
        }

        public List<ExpandedReviewViewModel> GetAllSharedReviewsByFilmId(Guid mediaId)
        {
            return FilmHausDbContext.ReviewFilms.AsExpandable().Where(rf => rf.MediaId == mediaId && rf.ObsoletedOn == null).Select(rf => rf.Review).Select(GetReviewViewModelWithFilm()).ToList();
        }

        public List<ExpandedReviewViewModel> GetAllFlaggedReviewsByFilmId(Guid mediaId)
        {
            return FilmHausDbContext.ReviewFilms.AsExpandable().Where(rf => rf.MediaId == mediaId && rf.Review.Flagged == true).Select(rf => rf.Review).Select(GetReviewViewModelWithFilm()).ToList();
        }

        public List<ExpandedReviewViewModel> GetAllReviewsByFilmId(Guid mediaId)
        {
            return FilmHausDbContext.ReviewFilms.AsExpandable().Where(rf => rf.MediaId == mediaId).Select(rf => rf.Review).Select(GetReviewViewModelWithFilm()).ToList();
        }

        public void CreateReviewFilm(Guid reviewId, Guid mediaId)
        {
            FilmHausDbContext.ReviewFilms.Add(new ReviewFilm
            {
                ReviewFilmId = Guid.NewGuid(),
                ReviewId = reviewId,
                MediaId = mediaId,
                CreatedOn = DateTime.Now,
                ObsoletedOn = null
            });
            FilmHausDbContext.SaveChanges();
        }

        public void DeleteReviewFilm(Guid reviewFilmId)
        {
            try
            {
                var review = FilmHausDbContext.ReviewFilms.Find(reviewFilmId);

                if (review != null)
                {
                    FilmHausDbContext.ReviewFilms.Remove(review);
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

        public void ObsoleteReviewFilm(Guid reviewFilmId)
        {
            try
            {
                var result = FilmHausDbContext.ReviewFilms.Find(reviewFilmId);

                if (result == null)
                    throw new ArgumentNullException();

                result.ObsoletedOn = DateTime.Now;

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