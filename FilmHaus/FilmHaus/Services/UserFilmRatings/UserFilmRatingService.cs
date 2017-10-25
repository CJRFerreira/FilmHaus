using System;
using FilmHaus.Services;
using FilmHaus.Models;
using FilmHaus.Models.Connector;
using System.Data.Entity;
using System.Linq;

namespace FilmHaus.Services.UserFilmRatings
{
    public class UserFilmRatingService : IUserFilmRatingService
    {
        private FilmHausDbContext FilmHausDbContext { get; }

        public UserFilmRatingService(FilmHausDbContext filmHausDbContext)
        {
            FilmHausDbContext = filmHausDbContext;
        }

        public void AddRatingToUserLibrary(string userId, Guid mediaId, int rating)
        {
            FilmHausDbContext.UserFilmRatings.Add(new UserFilmRating
            {
                UserFilmRatingId = Guid.NewGuid(),
                Id = userId,
                MediaId = mediaId,
                CreatedOn = DateTime.Now
            });
            FilmHausDbContext.SaveChanges();
        }

        public void ChangeRatingInUserLibrary(Guid userFilmId, int rating)
        {
            try
            {
                var oldRating = FilmHausDbContext.UserFilmRatings.Find(userFilmId);

                if (oldRating == null)
                    throw new ArgumentNullException();

                oldRating.ObsoletedOn = DateTime.Now;

                FilmHausDbContext.UserFilmRatings.Add(new UserFilmRating
                {
                    UserFilmRatingId = Guid.NewGuid(),
                    Id = oldRating.Id,
                    MediaId = oldRating.MediaId,
                    CreatedOn = DateTime.Now
                });

                FilmHausDbContext.Entry(oldRating).State = EntityState.Modified;
                FilmHausDbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void ObsoleteRatingInUserLibrary(Guid userFilmId)
        {
            try
            {
                var result = FilmHausDbContext.UserFilmRatings.Find(userFilmId);

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

        public double? GetAverageFilmRating(Guid mediaId)
        {
            return FilmHausDbContext.Films.Where(ufr => ufr.MediaId == mediaId).Select(FilmQueryExtensions.GetAverageFilmRating()).FirstOrDefault();
        }
    }
}