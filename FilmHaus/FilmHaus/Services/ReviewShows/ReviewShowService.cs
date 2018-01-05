using System;
using System.Collections.Generic;
using System.Linq;
using FilmHaus.Models;
using FilmHaus.Models.View;
using FilmHaus.Models.Connector;
using System.Data.Entity;
using static FilmHaus.Services.ReviewQueryExtensions;
using LinqKit;

namespace FilmHaus.Services.ReviewShows
{
    public class ReviewShowService : IReviewShowService
    {
        private FilmHausDbContext FilmHausDbContext { get; }

        public ReviewShowService(FilmHausDbContext filmHausDbContext)
        {
            FilmHausDbContext = filmHausDbContext;
        }

        public List<BaseReviewViewModel> GetAllSharedReviewsByShowId(Guid mediaId)
        {
            return FilmHausDbContext.ReviewShows.AsExpandable().Where(rf => rf.MediaId == mediaId && rf.Review.Shared && rf.Review.IsActive && rf.ObsoletedOn == null).Select(rf => rf.Review).Select(GetReviewViewModel()).ToList();
        }

        public List<BaseReviewViewModel> GetAllFlaggedReviewsByShowId(Guid mediaId)
        {
            return FilmHausDbContext.ReviewShows.AsExpandable().Where(rf => rf.MediaId == mediaId && rf.Review.IsActive && rf.Review.Flagged == true).Select(rf => rf.Review).Select(GetReviewViewModel()).ToList();
        }

        public List<BaseReviewViewModel> GetAllReviewsByShowId(Guid mediaId)
        {
            return FilmHausDbContext.ReviewShows.AsExpandable().Where(rf => rf.MediaId == mediaId).Select(rf => rf.Review).Select(GetReviewViewModel()).ToList();
        }

        public void CreateReviewShow(Guid reviewId, Guid mediaId)
        {
            FilmHausDbContext.ReviewShows.Add(new ReviewShow
            {
                ReviewShowId = Guid.NewGuid(),
                ReviewId = reviewId,
                MediaId = mediaId,
                CreatedOn = DateTime.Now
            });
            FilmHausDbContext.SaveChanges();
        }

        public void DeleteReviewShow(Guid reviewId, Guid mediaId)
        {
            try
            {
                var review = FilmHausDbContext.ReviewShows.Where(rs => rs.ReviewId == reviewId && rs.MediaId == mediaId && rs.ObsoletedOn == null).FirstOrDefault();

                if (review != null)
                {
                    FilmHausDbContext.ReviewShows.Remove(review);
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

        public void ObsoleteReviewShow(Guid reviewId, Guid mediaId)
        {
            try
            {
                var review = FilmHausDbContext.ReviewShows.Where(rs => rs.ReviewId == reviewId && rs.MediaId == mediaId && rs.ObsoletedOn == null).FirstOrDefault();

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

        public BaseReviewViewModel GetUserReviewByShowId(Guid mediaId, string userId)
        {
            return FilmHausDbContext.ReviewShows.AsExpandable().Where(rf => rf.MediaId == mediaId && rf.ObsoletedOn == null && rf.Review.IsActive && rf.Review.Id == userId).Select(rf => rf.Review).Select(GetReviewViewModel()).FirstOrDefault();
        }
    }
}