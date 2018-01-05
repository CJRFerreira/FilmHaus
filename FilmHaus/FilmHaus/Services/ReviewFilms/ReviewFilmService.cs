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

        public List<BaseReviewViewModel> GetAllSharedReviewsByFilmId(Guid mediaId)
        {
            return FilmHausDbContext.ReviewFilms.AsExpandable().Where(rf => rf.MediaId == mediaId && rf.Review.Shared && rf.Review.IsActive && rf.ObsoletedOn == null).Select(rf => rf.Review).Select(GetReviewViewModel()).ToList();
        }

        public List<BaseReviewViewModel> GetAllFlaggedReviewsByFilmId(Guid mediaId)
        {
            return FilmHausDbContext.ReviewFilms.AsExpandable().Where(rf => rf.MediaId == mediaId && rf.Review.IsActive && rf.Review.Flagged == true).Select(rf => rf.Review).Select(GetReviewViewModel()).ToList();
        }

        public List<BaseReviewViewModel> GetAllReviewsByFilmId(Guid mediaId)
        {
            return FilmHausDbContext.ReviewFilms.AsExpandable().Where(rf => rf.MediaId == mediaId).Select(rf => rf.Review).Select(GetReviewViewModel()).ToList();
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

        public void DeleteReviewFilm(Guid reviewId, Guid mediaId)
        {
            try
            {
                var review = FilmHausDbContext.ReviewFilms.Where(rs => rs.ReviewId == reviewId && rs.MediaId == mediaId && rs.ObsoletedOn == null).FirstOrDefault();

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

        public void ObsoleteReviewFilm(Guid reviewId, Guid mediaId)
        {
            try
            {
                var review = FilmHausDbContext.ReviewFilms.Where(rs => rs.ReviewId == reviewId && rs.MediaId == mediaId && rs.ObsoletedOn == null).FirstOrDefault();

                if (review == null)
                    throw new ArgumentNullException();

                review.ObsoletedOn = DateTime.Now;

                FilmHausDbContext.Entry(review).State = EntityState.Modified;
                FilmHausDbContext.SaveChanges();
            }
            catch (InvalidOperationException ex)
            {
                throw ex;
            }
        }

        public BaseReviewViewModel GetUserReviewByFilmId(Guid mediaId, string userId)
        {
            return FilmHausDbContext.ReviewFilms.AsExpandable().Where(rf => rf.MediaId == mediaId && rf.ObsoletedOn == null && rf.Review.IsActive && rf.Review.Id == userId).Select(rf => rf.Review).Select(GetReviewViewModel()).FirstOrDefault();
        }
    }
}