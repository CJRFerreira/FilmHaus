using System;
using System.Collections.Generic;
using System.Linq;
using FilmHaus.Models;
using FilmHaus.Models.Base;
using FilmHaus.Models.View;
using FilmHaus.Models.Connector;
using System.Data.Entity;
using static FilmHaus.Services.ShowQueryExtensions;
using static FilmHaus.Services.ListQueryExtensions;
using LinqKit;

/// <summary>
/// Name: Christian Ferreira
/// Date: September 6th - January 5th
///
/// Statement of Authorship:
/// I, Christian Ferreira (Student #: 000346210), certify that this material is my original work.
/// No other person's work has been used without due acknowledgement.
/// </summary>
namespace FilmHaus.Services.ListShows
{
    /// <summary>
    /// Class implementation of the <see cref="IListShowService"/> Interface
    /// </summary>
    public class ListShowService : IListShowService
    {
        /// <summary>
        /// Accessor to the <see cref="FilmHausDbContext"/>
        /// </summary>
        private FilmHausDbContext FilmHausDbContext { get; set; }

        /// <summary>
        /// Constructor for the <see cref="ListShowService"/> class
        /// </summary>
        /// <param name="filmHausDbContext">Accessor for the Db, used for DI</param>
        public ListShowService(FilmHausDbContext filmHausDbContext)
        {
            FilmHausDbContext = filmHausDbContext;
        }

        /// <summary>
        /// Given a <see cref="List"/>, return all <see cref="Show"/>s associated
        /// </summary>
        /// <param name="listId">Id of the <see cref="List"/> used to enact the search</param>
        /// <returns><see cref="List<<see cref="ShowViewModel"/>>"/> with all attached <see cref="Show"/>s</returns>
        public List<ShowViewModel> GetAllShowsByListId(Guid listId)
        {
            return FilmHausDbContext.ListShows.AsExpandable().Where(l => l.ListId == listId).Select(l => l.Show).Select(GetGeneralShowViewModel()).ToList();
        }

        /// <summary>
        /// Given a <see cref="Show"/>, return all <see cref="List"/>s associated
        /// </summary>
        /// <param name="mediaId">Id of the <see cref="Show"/> used to enact the search</param>
        /// <returns><see cref="List<<see cref="ListViewModel"/>>"/> with all attached <see cref="List"/>s</returns>
        public List<ListViewModel> GetAllListsWithShow(Guid mediaId)
        {
            return FilmHausDbContext.ListShows.AsExpandable().Where(lf => lf.MediaId == mediaId).Select(lf => lf.List).Select(GetListViewModel()).ToList();
        }

        /// <summary>
        /// Associates a <see cref="Show"/> with a <see cref="List"/>, returns bool indictating success
        /// </summary>
        /// <param name="listId"><see cref="List"/> to use for association removal</param>
        /// <param name="mediaId"><see cref="Show"/> to use for association removal</param>
        /// <returns>True on success, False otherwise</returns>
        public bool AddShowToList(Guid listId, Guid mediaId)
        {
            try
            {
                var possibleRecord = FilmHausDbContext.ListShows.Where(ufr => ufr.MediaId == mediaId && ufr.ListId == listId && ufr.ObsoletedOn == null).FirstOrDefault();

                if (possibleRecord == null)
                {
                    FilmHausDbContext.ListShows.Add(new ListShow
                    {
                        ListShowId = Guid.NewGuid(),
                        MediaId = mediaId,
                        ListId = listId,
                        CreatedOn = DateTime.Now,
                        ObsoletedOn = null
                    });
                    FilmHausDbContext.SaveChanges();
                    return true;
                }
            }
            catch
            {
                throw;
            }

            return false;
        }

        /// <summary>
        /// Remove the association for a <see cref="List"/> and <see cref="Show"/>
        /// </summary>
        /// <param name="listId"><see cref="List"/> to use for association removal</param>
        /// <param name="mediaId"><see cref="Show"/> to use for association removal</param>
        /// <returns>True on success, False otherwise</returns>
        public bool RemoveShowInList(Guid listId, Guid mediaId)
        {
            try
            {
                var listShow = FilmHausDbContext.ListShows.Where(lf => (lf.ListId == listId && lf.MediaId == mediaId) && lf.ObsoletedOn == null).FirstOrDefault();

                if (listShow != null)
                    throw new ArgumentNullException();

                FilmHausDbContext.ListShows.Remove(listShow);
                FilmHausDbContext.SaveChanges();
            }
            catch (InvalidOperationException ex)
            {
                throw ex;
            }

            return true;
        }

        /// <summary>
        /// Obsolete the association for a <see cref="List"/> and <see cref="Show"/>
        /// </summary>
        /// <param name="listId"><see cref="List"/> to use for association obsoletion</param>
        /// <param name="mediaId"><see cref="Show"/> to use for association obsoletion</param>
        /// <returns>True on success, False otherwise</returns>
        public bool ObsoleteShowInList(Guid listId, Guid mediaId)
        {
            try
            {
                var result = FilmHausDbContext.ListShows.Where(lf => (lf.ListId == listId && lf.MediaId == mediaId) && lf.ObsoletedOn == null).FirstOrDefault();

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

            return true;
        }
    }
}