using System;
using FilmHaus.Models;
using FilmHaus.Models.Connector;
using System.Data.Entity;
using System.Linq;

namespace FilmHaus.Services.UserShowRatings
{
    public class UserShowRatingService : IUserShowRatingService
    {
        private FilmHausDbContext FilmHausDbContext { get; }

        public UserShowRatingService(FilmHausDbContext filmHausDbContext)
        {
            FilmHausDbContext = filmHausDbContext;
        }

        public void AddRatingToUserLibrary(string userId, Guid mediaId, int rating)
        {
            FilmHausDbContext.UserShowRatings.Add(new UserShowRating
            {
                UserShowRatingId = Guid.NewGuid(),
                Id = userId,
                MediaId = mediaId,
                CreatedOn = DateTime.Now
            });
            FilmHausDbContext.SaveChanges();
        }

        public void ChangeRatingInUserLibrary(Guid userShowId, int rating)
        {
            try
            {
                var oldRating = FilmHausDbContext.UserShowRatings.Find(userShowId);

                if (oldRating == null)
                    throw new ArgumentNullException();

                oldRating.ObsoletedOn = DateTime.Now;

                FilmHausDbContext.UserShowRatings.Add(new UserShowRating
                {
                    UserShowRatingId = Guid.NewGuid(),
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

        public void ObsoleteRatingInUserLibrary(Guid userShowId)
        {
            try
            {
                var result = FilmHausDbContext.UserShowRatings.Find(userShowId);

                if (result == null)
                    throw new ArgumentNullException();

                result.ObsoletedOn = DateTime.Now;

                FilmHausDbContext.Entry(result).State = EntityState.Modified;
                FilmHausDbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public double? GetAverageShowRating(Guid mediaId)
        {
            return FilmHausDbContext.Shows.Where(ufr => ufr.MediaId == mediaId).Select(ShowQueryExtensions.GetAverageShowRating()).FirstOrDefault();
        }
    }
}