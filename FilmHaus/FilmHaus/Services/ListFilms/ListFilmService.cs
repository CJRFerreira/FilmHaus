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
        private FilmHausDbContext FilmHausDbContext { get; set; }

        public ListFilmService(FilmHausDbContext filmHausDbContext)
        {
            FilmHausDbContext = filmHausDbContext;
        }

        public List<GeneralFilmViewModel> GetAllFilmsForList(Guid listId)
        {
            return FilmHausDbContext.ListFilms.AsExpandable().Where(l => l.ListId == listId).Select(l => l.Film).Select(GetGeneralFilmViewModel()).ToList();
        }

        public List<ListViewModel> GetAllListsWithFilm(Guid mediaId)
        {
            return FilmHausDbContext.ListFilms.AsExpandable().Where(lf => lf.MediaId == mediaId).Select(lf => lf.List).Select(GetListViewModel()).ToList();
        }

        public void AddFilmToList(Guid listId, Guid mediaId)
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
        }

        public void RemoveFilmInList(Guid listFilmId)
        {
            try
            {
                var listFilm = FilmHausDbContext.ListFilms.Find(listFilmId);

                if (listFilm == null)
                    throw new KeyNotFoundException();

                FilmHausDbContext.ListFilms.Remove(listFilm);
                FilmHausDbContext.SaveChanges();
            }
            catch (InvalidOperationException ex)
            {
                throw ex;
            }
        }

        public void RemoveFilmInList(Guid listId, Guid mediaId)
        {
            try
            {
                var listFilm = FilmHausDbContext.ListFilms.Where(lf => (lf.ListId == listId && lf.MediaId == mediaId) && lf.ObsoletedOn == null).FirstOrDefault();

                if (listFilm != null)
                    throw new KeyNotFoundException();

                FilmHausDbContext.ListFilms.Remove(listFilm);
                FilmHausDbContext.SaveChanges();
            }
            catch (InvalidOperationException ex)
            {
                throw ex;
            }
        }

        public void ObsoleteFilmInList(Guid listFilmId)
        {
            try
            {
                var result = FilmHausDbContext.ListFilms.Find(listFilmId);

                if (result == null)
                    throw new KeyNotFoundException();

                result.ObsoletedOn = DateTime.Now;

                FilmHausDbContext.Entry(result).State = EntityState.Modified;
                FilmHausDbContext.SaveChanges();
            }
            catch (InvalidOperationException ex)
            {
                throw ex;
            }
        }

        public void ObsoleteFilmInList(Guid listId, Guid mediaId)
        {
            try
            {
                var result = FilmHausDbContext.ListFilms.Where(lf => (lf.ListId == listId && lf.MediaId == mediaId) && lf.ObsoletedOn == null).FirstOrDefault();

                if (result == null)
                    throw new KeyNotFoundException();

                result.ObsoletedOn = DateTime.Now;

                FilmHausDbContext.Entry(result).State = EntityState.Modified;
                FilmHausDbContext.SaveChanges();
            }
            catch (InvalidOperationException ex)
            {
                throw ex;
            }
        }
    }
}