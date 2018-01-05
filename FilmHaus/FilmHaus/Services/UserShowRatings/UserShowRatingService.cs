using System;
using FilmHaus.Models;
using FilmHaus.Models.Connector;
using System.Data.Entity;
using System.Linq;
using FilmHaus.Services.UserShows;

namespace FilmHaus.Services.UserShowRatings
{
    public class UserShowRatingService : IUserShowRatingService
    {
        private FilmHausDbContext FilmHausDbContext { get; }

        private IUserShowService UserShowService { get; }

        public UserShowRatingService(FilmHausDbContext filmHausDbContext, IUserShowService userShowService)
        {
            FilmHausDbContext = filmHausDbContext;
            UserShowService = userShowService;
        }

        public bool AddRatingToUserLibrary(string userId, Guid mediaId, int rating)
        {
            try
            {
                if (!UserShowService.IsShowInLibrary(mediaId, userId))
                    UserShowService.AddShowToUserLibrary(mediaId, userId);

                var possibleRecord = FilmHausDbContext.UserShowRatings.Where(ufr => ufr.MediaId == mediaId && ufr.Id == userId && ufr.ObsoletedOn == null).FirstOrDefault();

                if (possibleRecord == null)
                {
                    FilmHausDbContext.UserShowRatings.Add(new UserShowRating
                    {
                        UserShowRatingId = Guid.NewGuid(),
                        Id = userId,
                        MediaId = mediaId,
                        CreatedOn = DateTime.Now,
                        ObsoletedOn = null,
                        Rating = rating
                    });
                    FilmHausDbContext.SaveChanges();
                }
                else
                {
                    return ChangeRatingInUserLibrary(userId, mediaId, rating);
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        public bool ChangeRatingInUserLibrary(Guid userShowId, int rating)
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
                    CreatedOn = DateTime.Now,
                    ObsoletedOn = null,
                    Rating = rating
                });

                FilmHausDbContext.Entry(oldRating).State = EntityState.Modified;
                FilmHausDbContext.SaveChanges();
            }
            catch
            {
                return false;
            }

            return true;
        }

        public bool ChangeRatingInUserLibrary(string userId, Guid mediaId, int rating)
        {
            try
            {
                var oldRating = FilmHausDbContext.UserShowRatings.Where(ufr => ufr.MediaId == mediaId && ufr.Id == userId && ufr.ObsoletedOn == null).FirstOrDefault();

                if (oldRating == null)
                    throw new ArgumentNullException();

                oldRating.ObsoletedOn = DateTime.Now;

                FilmHausDbContext.Entry(oldRating).State = EntityState.Modified;
                FilmHausDbContext.SaveChanges();

                FilmHausDbContext.UserShowRatings.Add(new UserShowRating
                {
                    UserShowRatingId = Guid.NewGuid(),
                    Id = oldRating.Id,
                    MediaId = oldRating.MediaId,
                    CreatedOn = DateTime.Now,
                    ObsoletedOn = null,
                    Rating = rating
                });
                FilmHausDbContext.SaveChanges();

            }
            catch
            {
                return false;
            }

            return true;
        }

        public bool ObsoleteRatingInUserLibrary(Guid userShowId)
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
                return false;
            }

            return true;
        }

        public bool ObsoleteRatinginUserLibrary(string userId, Guid mediaId)
        {
            try
            {
                var result = FilmHausDbContext.UserShowRatings.Where(ufr => ufr.MediaId == mediaId && ufr.Id == userId && ufr.ObsoletedOn == null).FirstOrDefault();

                if (result == null)
                    throw new ArgumentNullException();

                result.ObsoletedOn = DateTime.Now;

                FilmHausDbContext.Entry(result).State = EntityState.Modified;
                FilmHausDbContext.SaveChanges();
            }
            catch
            {
                return false;
            }

            return true;
        }

        public double? GetAverageShowRating(Guid mediaId)
        {
            return FilmHausDbContext.Shows.Where(ufr => ufr.MediaId == mediaId).Select(ShowQueryExtensions.GetAverageShowRating()).FirstOrDefault();
        }

        public bool DoesUserHaveRating(string userId, Guid mediaId)
        {
            return FilmHausDbContext.UserShowRatings.Where(ufr => ufr.Id == userId && ufr.MediaId == mediaId && ufr.ObsoletedOn == null).Any();
        }
    }
}