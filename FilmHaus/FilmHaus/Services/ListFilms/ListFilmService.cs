using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using FilmHaus.Models;
using FilmHaus.Models.View;
using FilmHaus.Models.Connector;
using static FilmHaus.Services.FilmQueryExtensions;
using static FilmHaus.Services.ListQueryExtensions;
using LinqKit;

namespace FilmHaus.Services.ListFilms
{
    public class ListFilmService : IListFilmService
    {
        private FilmHausDbContext FilmHausDbContext { get; }

        public ListFilmService(FilmHausDbContext filmHausDbContext)
        {
            FilmHausDbContext = filmHausDbContext;
        }

        public List<FilmViewModel> GetAllFilmsForList(Guid listId)
        {
            return FilmHausDbContext.ListFilms.AsExpandable().Where(l => l.ListId == listId).Select(l => l.Film).Select(GetGeneralFilmViewModel()).ToList();
        }

        public List<ListViewModel> GetAllListsWithFilm(Guid mediaId)
        {
            return FilmHausDbContext.ListFilms.AsExpandable().Where(lf => lf.MediaId == mediaId).Select(lf => lf.List).Select(GetListViewModel()).ToList();
        }

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

        public bool RemoveFilmInList(Guid listFilmId)
        {
            try
            {
                var listFilm = FilmHausDbContext.ListFilms.Find(listFilmId);

                if (listFilm == null)
                    throw new ArgumentNullException();

                FilmHausDbContext.ListFilms.Remove(listFilm);
                FilmHausDbContext.SaveChanges();
                return true;
            }
            catch (InvalidOperationException ex)
            {
                throw ex;
            }
        }

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

        public bool ObsoleteFilmInList(Guid listFilmId)
        {
            try
            {
                var result = FilmHausDbContext.ListFilms.Find(listFilmId);

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