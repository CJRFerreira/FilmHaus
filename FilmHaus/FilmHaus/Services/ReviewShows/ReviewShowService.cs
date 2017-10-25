using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FilmHaus.Models.View;
using FilmHaus.Models;
using FilmHaus.Models.Base;
using FilmHaus.Models.Connector;
using System.Data.Entity;

namespace FilmHaus.Services.ReviewShows
{
    public class ReviewShowService : IReviewShowService
    {
        private FilmHausDbContext FilmHausDbContext { get; set; }

        public ReviewShowService(FilmHausDbContext filmHausDbContext)
        {
            FilmHausDbContext = filmHausDbContext;
        }

        public List<ReviewViewModel> GetAllSharedReviewsByShowId(Guid mediaId)
        {
            throw new NotImplementedException();
        }

        public List<ReviewViewModel> GetAllFlaggedReviewsByShowId(Guid mediaId)
        {
            throw new NotImplementedException();
        }

        public List<ReviewViewModel> GetAllReviewsByShowId(Guid mediaId)
        {
            throw new NotImplementedException();
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

        public void DeleteReviewShow(Guid reviewShowId)
        {
            try
            {
                var review = FilmHausDbContext.ReviewShows.Find(reviewShowId);

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

        public void ObsoleteReviewShow(Guid reviewShowId)
        {
            try
            {
                var result = FilmHausDbContext.ReviewShows.Find(reviewShowId);

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