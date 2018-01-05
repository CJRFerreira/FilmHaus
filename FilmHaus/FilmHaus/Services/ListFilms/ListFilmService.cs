using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using FilmHaus.Models;
using FilmHaus.Models.Base;
using FilmHaus.Models.View;
using FilmHaus.Models.Connector;
using static FilmHaus.Services.FilmQueryExtensions;
using static FilmHaus.Services.ListQueryExtensions;
using LinqKit;

namespace FilmHaus.Services.ListFilms
{
    /// <summary>
    /// Class implementation of the <see cref="IListFilmService"/> Interface
    /// </summary>
    public class ListFilmService : IListFilmService
    {
        /// <summary>
        /// Accessor to the <see cref="FilmHausDbContext"/>
        /// </summary>
        private FilmHausDbContext FilmHausDbContext { get; }

        /// <summary>
        /// Constructor for the <see cref="ListFilmService"/> class
        /// </summary>
        /// <param name="filmHausDbContext">Accessor for the Db, used for DI</param>
        public ListFilmService(FilmHausDbContext filmHausDbContext)
        {
            FilmHausDbContext = filmHausDbContext;
        }

        /// <summary>
        /// Given a <see cref="List"/>, return all <see cref="Film"/>s associated
        /// </summary>
        /// <param name="listId">Id of the <see cref="List"/> used to enact the search</param>
        /// <returns><see cref="List<<see cref="FilmViewModel"/>>"/> with all attached <see cref="Film"/>s</returns>
        public List<FilmViewModel> GetAllFilmsForList(Guid listId)
        {
            return FilmHausDbContext.ListFilms.AsExpandable().Where(l => l.ListId == listId).Select(l => l.Film).Select(GetGeneralFilmViewModel()).ToList();
        }

        /// <summary>
        /// Given a <see cref="Film"/>, return all <see cref="List"/>s associated
        /// </summary>
        /// <param name="mediaId">Id of the <see cref="Film"/> used to enact the search</param>
        /// <returns><see cref="List<<see cref="ListViewModel"/>>"/> with all attached <see cref="List"/>s</returns>
        public List<ListViewModel> GetAllListsWithFilm(Guid mediaId)
        {
            return FilmHausDbContext.ListFilms.AsExpandable().Where(lf => lf.MediaId == mediaId).Select(lf => lf.List).Select(GetListViewModel()).ToList();
        }

        /// <summary>
        /// Associates a <see cref="Film"/> with a <see cref="List"/>, returns bool indictating success
        /// </summary>
        /// <param name="listId"><see cref="List"/> to use for association removal</param>
        /// <param name="mediaId"><see cref="Film"/> to use for association removal</param>
        /// <returns>True on success, False otherwise</returns>
        public bool AddFilmToList(Guid listId, Guid mediaId)
        {
            try
            {
                var possibleRecord = FilmHausDbContext.ListFilms.Where(ufr => ufr.MediaId == mediaId && ufr.ListId == listId && ufr.ObsoletedOn == null).FirstOrDefault();

                if (possibleRecord == null)
                {
                    FilmHausDbContext.ListFilms.Add(new ListFilm
                    {
                        ListFilmId = Guid.NewGuid(),
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
        /// Remove the association for a <see cref="List"/> and <see cref="Film"/>
        /// </summary>
        /// <param name="listId"><see cref="List"/> to use for association removal</param>
        /// <param name="mediaId"><see cref="Film"/> to use for association removal</param>
        /// <returns>True on success, False otherwise</returns>
        public bool RemoveFilmInList(Guid listId, Guid mediaId)
        {
            try
            {
                var listFilm = FilmHausDbContext.ListFilms.Where(lf => (lf.ListId == listId && lf.MediaId == mediaId) && lf.ObsoletedOn == null).FirstOrDefault();

                if (listFilm != null)
                    throw new ArgumentNullException();

                FilmHausDbContext.ListFilms.Remove(listFilm);
                FilmHausDbContext.SaveChanges();
            }
            catch (InvalidOperationException ex)
            {
                throw ex;
            }

            return true;
        }

        /// <summary>
        /// Obsolete the association for a <see cref="List"/> and <see cref="Film"/>
        /// </summary>
        /// <param name="listId"><see cref="List"/> to use for association obsoletion</param>
        /// <param name="mediaId"><see cref="Film"/> to use for association obsoletion</param>
        /// <returns>True on success, False otherwise</returns>
        public bool ObsoleteFilmInList(Guid listId, Guid mediaId)
        {
            try
            {
                var result = FilmHausDbContext.ListFilms.Where(lf => (lf.ListId == listId && lf.MediaId == mediaId) && lf.ObsoletedOn == null).FirstOrDefault();

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