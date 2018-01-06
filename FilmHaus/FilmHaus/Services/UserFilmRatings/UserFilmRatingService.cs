using System;
using FilmHaus.Services;
using FilmHaus.Models;
using FilmHaus.Models.Base;
using FilmHaus.Models.Connector;
using System.Data.Entity;
using System.Linq;
using FilmHaus.Services.UserFilms;

/// <summary>
/// Name: Christian Ferreira
/// Date: September 6th - January 5th
///
/// Statement of Authorship:
/// I, Christian Ferreira (Student #: 000346210), certify that this material is my original work.
/// No other person's work has been used without due acknowledgement.
/// </summary>
namespace FilmHaus.Services.UserFilmRatings
{
    /// <summary>
    /// Class implementation of the <see cref="IUserFilmRatingService"/> Interface
    /// </summary>
    public class UserFilmRatingService : IUserFilmRatingService
    {
        /// <summary>
        /// Accessor to the <see cref="FilmHausDbContext"/>
        /// </summary>
        private FilmHausDbContext FilmHausDbContext { get; }

        /// <summary>
        /// Accessor to the <see cref="IUserFilmService"/>
        /// </summary>
        private IUserFilmService UserFilmService { get; }

        /// <summary>
        /// Constructor for the <see cref="UserFilmRatingService"/> class
        /// </summary>
        /// <param name="filmHausDbContext">Accessor for the Db, used for DI</param>
        /// <param name="userFilmService">Accessor for the <see cref="UserFilmService"/></param>
        public UserFilmRatingService(FilmHausDbContext filmHausDbContext, IUserFilmService userFilmService)
        {
            FilmHausDbContext = filmHausDbContext;
            UserFilmService = userFilmService;
        }

        /// <summary>
        /// Adds a <see cref="int"/> rating by a <see cref="User"/> to a <see cref="Film"/>
        /// </summary>
        /// <param name="userId"><see cref="User"/> who made the rating</param>
        /// <param name="mediaId"><see cref="Film"/> the rating was for</param>
        /// <param name="rating"><see cref="int"/> representing the rating</param>
        /// <returns>True on success, False otherwise</returns>
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

        /// <summary>
        /// Changes a <see cref="int"/> rating by a <see cref="User"/> to a <see cref="Film"/>
        /// </summary>
        /// <param name="userId"><see cref="User"/> who made the rating</param>
        /// <param name="mediaId"><see cref="Film"/> the rating was for</param>
        /// <param name="rating"><see cref="int"/> representing the rating</param>
        /// <returns>True on success, False otherwise</returns>
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

        /// <summary>
        /// Obsoletes the <see cref="User"/>s current rating of a <see cref="Film"/>
        /// </summary>
        /// <param name="userId"><see cref="User"/> who made the rating</param>
        /// <param name="mediaId"><see cref="Film"/> the rating was made for</param>
        /// <returns>True on success, False otherwise</returns>
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

        /// <summary>
        /// Retrieves the average rating for a given <see cref="Film"/>
        /// </summary>
        /// <param name="mediaId"><see cref="Film"/> to act for</param>
        /// <returns><see cref="double?"/> representing the rating</returns>
        public double? GetAverageFilmRating(Guid mediaId)
        {
            return FilmHausDbContext.Films.Where(ufr => ufr.MediaId == mediaId).Select(FilmQueryExtensions.GetAverageFilmRating()).FirstOrDefault();
        }

        /// <summary>
        /// Checks if a <see cref="Film"/> exists in a <see cref="User"/>s library
        /// </summary>
        /// <param name="userId"><see cref="User"/> to search for</param>
        /// <param name="mediaId"><see cref="Film"/> to search for</param>
        /// <returns>True on rating existence, False otherwise</returns>
        public bool DoesUserHaveRating(string userId, Guid mediaId)
        {
            return FilmHausDbContext.UserFilmRatings.Where(ufr => ufr.Id == userId && ufr.MediaId == mediaId && ufr.ObsoletedOn == null).Any();
        }
    }
}