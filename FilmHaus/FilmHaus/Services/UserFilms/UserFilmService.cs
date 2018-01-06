using FilmHaus.Models;
using FilmHaus.Models.Base;
using FilmHaus.Models.Connector;
using FilmHaus.Models.View;
using LinqKit;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using static FilmHaus.Services.FilmQueryExtensions;

/// <summary>
/// Name: Christian Ferreira
/// Date: September 6th - January 5th
///
/// Statement of Authorship:
/// I, Christian Ferreira (Student #: 000346210), certify that this material is my original work.
/// No other person's work has been used without due acknowledgement.
/// </summary>
namespace FilmHaus.Services.UserFilms
{
    /// <summary>
    /// Class implementation of the <see cref="IUserFilmService"/> Interface
    /// </summary>
    public class UserFilmService : IUserFilmService
    {
        /// <summary>
        /// Accessor to the <see cref="FilmHausDbContext"/>
        /// </summary>
        private FilmHausDbContext FilmHausDbContext { get; set; }

        /// <summary>
        /// Constructor for the <see cref="UserFilmService"/> class
        /// </summary>
        /// <param name="filmHausDbContext">Accessor for the Db, used for DI</param>
        public UserFilmService(FilmHausDbContext filmHausDbContext)
        {
            FilmHausDbContext = filmHausDbContext;
        }

        /// <summary>
        /// Associate a <see cref="User"/> with a <see cref="Film"/>
        /// </summary>
        /// <param name="mediaId"><see cref="Film"/> to use for association</param>
        /// <param name="userId"><see cref="User"/> to use for association</param>
        /// <returns>True on success, False otherwise</returns>
        public bool AddFilmToUserLibrary(Guid mediaId, string userId)
        {
            try
            {
                var possibleRecord = FilmHausDbContext.UserShows.Where(ufr => ufr.MediaId == mediaId && ufr.Id == userId && ufr.ObsoletedOn == null).FirstOrDefault();

                if (possibleRecord == null)
                {
                    FilmHausDbContext.UserFilms.Add(new UserFilm
                    {
                        UserFilmId = Guid.NewGuid(),
                        MediaId = mediaId,
                        Id = userId,
                        CreatedOn = DateTime.Now,
                        ObsoletedOn = null
                    });
                    FilmHausDbContext.SaveChanges();
                }
            }
            catch
            {
                throw;
            }
            return true;
        }

        /// <summary>
        /// Remove the association for a <see cref="User"/> and <see cref="Film"/>
        /// </summary>
        /// <param name="mediaId"><see cref="Film"/> to use for association removal</param>
        /// <param name="userId"><see cref="User"/> to use for association removal</param>
        /// <returns>True on success, False otherwise</returns>
        public bool RemoveFilmFromUserLibrary(Guid mediaId, string userId)
        {
            try
            {
                var userFilm = FilmHausDbContext.UserFilms.Where(uf => (uf.Id == userId && uf.MediaId == mediaId) && uf.ObsoletedOn == null).FirstOrDefault();

                if (userFilm != null)
                    throw new ArgumentNullException();

                FilmHausDbContext.UserFilms.Remove(userFilm);
                FilmHausDbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
            return true;
        }

        /// <summary>
        /// Obsolete the association for a <see cref="User"/> and <see cref="Film"/>
        /// </summary>
        /// <param name="mediaId"><see cref="Film"/> to use for association obsoletion</param>
        /// <param name="userId"><see cref="User"/> to use for association obsoletion</param>
        /// <returns>True on success, False otherwise</returns>
        public bool ObsoleteFilmInUserLibrary(Guid mediaId, string userId)
        {
            try
            {
                var result = FilmHausDbContext.UserFilms.Where(uf => (uf.Id == userId && uf.MediaId == mediaId) && uf.ObsoletedOn == null).FirstOrDefault();

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
            return true;
        }

        /// <summary>
        /// Get all <see cref="Film"/>s for a given <see cref="User"/>
        /// </summary>
        /// <param name="userId"><see cref="User"/> to enact the search for</param>
        /// <returns><see cref="List<<see cref="FilmViewModel"/>>"/> representing the <see cref="User"/>s library</returns>
        public List<FilmViewModel> GetAllFilmsForUser(string userId)
        {
            return FilmHausDbContext.UserFilms.AsExpandable().Where(uf => uf.Id == userId && uf.ObsoletedOn == null).Select(GetUserFilmViewModel()).ToList();
        }

        /// <summary>
        /// Checks if a <see cref="Film"/> exists in a <see cref="User"/>s library
        /// </summary>
        /// <param name="mediaId"><see cref="Film"/> to use for search</param>
        /// <param name="userId"><see cref="User"/> to use for search</param>
        /// <returns>True on success, false otherwise</returns>
        public bool IsFilmInLibrary(Guid mediaId, string userId)
        {
            return FilmHausDbContext.UserFilms.Where(uf => uf.Id == userId && uf.MediaId == mediaId && uf.ObsoletedOn == null).Any();
        }
    }
}