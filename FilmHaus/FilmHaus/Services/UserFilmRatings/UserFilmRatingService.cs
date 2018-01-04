using System;
using FilmHaus.Services;
using FilmHaus.Models;
using FilmHaus.Models.Connector;
using System.Data.Entity;
using System.Linq;
using FilmHaus.Services.UserFilms;

namespace FilmHaus.Services.UserFilmRatings
{
    public class UserFilmRatingService : IUserFilmRatingService
    {
        private FilmHausDbContext FilmHausDbContext { get; }

        private IUserFilmService UserFilmService { get; }

        public UserFilmRatingService(FilmHausDbContext filmHausDbContext, IUserFilmService userFilmService)
        {
            FilmHausDbContext = filmHausDbContext;
            UserFilmService = userFilmService;
        }

        public bool AddRatingToUserLibrary(string userId, Guid mediaId, int rating)
        {
            try
            {
                if (!UserFilmService.IsFilmInLibrary(mediaId, userId))
                    UserFilmService.AddFilmToUserLibrary(mediaId, userId);

                var possibleRecord = FilmHausDbContext.UserFilmRatings.Where(ufr => ufr.MediaId == mediaId && ufr.Id == userId && ufr.ObsoletedOn == null).FirstOrDefault();

                if (possibleRecord == null)
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

        public bool ChangeRatingInUserLibrary(Guid userFilmId, int rating)
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
                return false;
            }

            return true;
        }

        public bool ChangeRatingInUserLibrary(string userId, Guid mediaId, int rating)
        {
            try
            {
                var oldRating = FilmHausDbContext.UserFilmRatings.Where(ufr => ufr.MediaId == mediaId && ufr.Id == userId && ufr.ObsoletedOn == null).FirstOrDefault();

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
                return false;
            }

            return true;
        }

        public bool ObsoleteRatingInUserLibrary(Guid userFilmId)
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
                var result = FilmHausDbContext.UserFilmRatings.Where(ufr => ufr.MediaId == mediaId && ufr.Id == userId && ufr.ObsoletedOn == null).FirstOrDefault();

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

        public double? GetAverageFilmRating(Guid mediaId)
        {
            return FilmHausDbContext.Films.Where(ufr => ufr.MediaId == mediaId).Select(FilmQueryExtensions.GetAverageFilmRating()).FirstOrDefault();
        }

        public bool DoesUserHaveRating(string userId, Guid mediaId)
        {
            return FilmHausDbContext.UserFilmRatings.Where(ufr => ufr.Id == userId && ufr.MediaId == mediaId && ufr.ObsoletedOn != null).Any();
        }
    }
}