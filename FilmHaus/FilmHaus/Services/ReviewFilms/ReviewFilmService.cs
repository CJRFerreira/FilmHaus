using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FilmHaus.Models.View;
using FilmHaus.Models;
using FilmHaus.Models.Base;
using FilmHaus.Models.Connector;
using System.Data.Entity;

namespace FilmHaus.Services.ReviewFilms
{
    public class ReviewFilmService : IReviewFilmService
    {
        private FilmHausDbContext FilmHausDbContext { get; set; }

        public ReviewFilmService(FilmHausDbContext filmHausDbContext)
        {
            FilmHausDbContext = filmHausDbContext;
        }

        public List<ReviewViewModel> GetAllSharedReviewsByFilmId(Guid mediaId)
        {
            throw new NotImplementedException();
        }

        public List<ReviewViewModel> GetAllFlaggedReviewsByFilmId(Guid mediaId)
        {
            throw new NotImplementedException();
        }

        public List<ReviewViewModel> GetAllReviewsByFilmId(Guid mediaId)
        {
            throw new NotImplementedException();
        }

        public void CreateReviewFilm(Guid reviewId, Guid mediaId)
        {
            FilmHausDbContext.ReviewFilms.Add(new ReviewFilm
            {
                ReviewFilmId = Guid.NewGuid(),
                ReviewId = reviewId,
                MediaId = mediaId,
                CreatedOn = DateTime.Now
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