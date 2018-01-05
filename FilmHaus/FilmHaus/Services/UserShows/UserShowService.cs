using System;
using System.Collections.Generic;
using FilmHaus.Models;
using FilmHaus.Models.Base;
using FilmHaus.Models.View;
using FilmHaus.Models.Connector;
using System.Data.Entity;
using System.Linq;
using static FilmHaus.Services.ShowQueryExtensions;
using LinqKit;

namespace FilmHaus.Services.UserShows
{
    /// <summary>
    /// Class implementation of the <see cref="IUserShowService"/> Interface
    /// </summary>
    public class UserShowService : IUserShowService
    {
        /// <summary>
        /// Accessor to the <see cref="FilmHausDbContext"/>
        /// </summary>
        private FilmHausDbContext FilmHausDbContext { get; set; }

        /// <summary>
        /// Constructor for the <see cref="UserShowService"/> class
        /// </summary>
        /// <param name="filmHausDbContext">Accessor for the Db, used for DI</param>
        public UserShowService(FilmHausDbContext filmHausDbContext)
        {
            FilmHausDbContext = filmHausDbContext;
        }

        /// <summary>
        /// Associate a <see cref="User"/> with a <see cref="Show"/>
        /// </summary>
        /// <param name="mediaId"><see cref="Show"/> to use for association</param>
        /// <param name="userId"><see cref="User"/> to use for association</param>
        /// <returns>True on success, False otherwise</returns>
        public bool AddShowToUserLibrary(Guid mediaId, string userId)
        {
            try
            {
                var possibleRecord = FilmHausDbContext.UserShows.Where(ufr => ufr.MediaId == mediaId && ufr.Id == userId && ufr.ObsoletedOn == null).FirstOrDefault();

                if (possibleRecord == null)
                {
                    FilmHausDbContext.UserShows.Add(new UserShow
                    {
                        UserShowId = Guid.NewGuid(),
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
        /// Remove the association for a <see cref="User"/> and <see cref="Show"/>
        /// </summary>
        /// <param name="mediaId"><see cref="Show"/> to use for association removal</param>
        /// <param name="userId"><see cref="User"/> to use for association removal</param>
        /// <returns>True on success, False otherwise</returns>
        public bool RemoveShowFromUserLibrary(Guid mediaId, string userId)
        {
            try
            {
                var userShow = FilmHausDbContext.UserShows.Where(uf => (uf.Id == userId && uf.MediaId == mediaId) && uf.ObsoletedOn == null).FirstOrDefault();

                if (userShow != null)
                    throw new ArgumentNullException();

                FilmHausDbContext.UserShows.Remove(userShow);
                FilmHausDbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
            return true;
        }

        /// <summary>
        /// Obsolete the association for a <see cref="User"/> and <see cref="Show"/>
        /// </summary>
        /// <param name="mediaId"><see cref="Show"/> to use for association obsoletion</param>
        /// <param name="userId"><see cref="User"/> to use for association obsoletion</param>
        /// <returns>True on success, False otherwise</returns>
        public bool ObsoleteShowInUserLibrary(Guid mediaId, string userId)
        {
            try
            {
                var result = FilmHausDbContext.UserShows.Where(uf => (uf.Id == userId && uf.MediaId == mediaId) && uf.ObsoletedOn == null).FirstOrDefault();

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
        /// Get all <see cref="Show"/>s for a given <see cref="User"/>
        /// </summary>
        /// <param name="userId"><see cref="User"/> to enact the search for</param>
        /// <returns><see cref="List<<see cref="ShowViewModel"/>>"/> representing the <see cref="User"/>s library</returns>
        public List<ShowViewModel> GetAllShowsForUser(string userId)
        {
            return FilmHausDbContext.UserShows.AsExpandable().Where(us => us.Id == userId && us.ObsoletedOn == null).Select(GetUserShowViewModel()).ToList();
        }

        /// <summary>
        /// Checks if a <see cref="Show"/> exists in a <see cref="User"/>s library
        /// </summary>
        /// <param name="mediaId"><see cref="Show"/> to use for search</param>
        /// <param name="userId"><see cref="User"/> to use for search</param>
        /// <returns>True on success, false otherwise</returns>
        public bool IsShowInLibrary(Guid mediaId, string userId)
        {
            return FilmHausDbContext.UserShows.Where(uf => uf.Id == userId && uf.MediaId == mediaId && uf.ObsoletedOn == null).Any();
        }
    }
}