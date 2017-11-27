using System;
using System.Collections.Generic;
using System.Linq;
using FilmHaus.Models.View;
using FilmHaus.Models;
using FilmHaus.Models.Connector;
using System.Data.Entity;
using static FilmHaus.Services.ShowQueryExtensions;
using LinqKit;

namespace FilmHaus.Services.ListShows
{
    public class ListShowService : IListShowService
    {
        private FilmHausDbContext FilmHausDbContext { get; set; }

        public ListShowService(FilmHausDbContext filmHausDbContext)
        {
            FilmHausDbContext = filmHausDbContext;
        }

        public List<GeneralShowViewModel> GetAllShowsByListId(Guid listId)
        {
            return FilmHausDbContext.ListShows.AsExpandable().Where(l => l.ListId == listId).Select(l => l.Show).Select(GetGeneralShowViewModel()).ToList();
        }

        public void AddShowToList(Guid listId, Guid mediaId)
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
        }

        public void RemoveShowInList(Guid listShowId)
        {
            try
            {
                var listShow = FilmHausDbContext.ListShows.Find(listShowId);

                if (listShow == null)
                    throw new ArgumentNullException();

                FilmHausDbContext.ListShows.Remove(listShow);
                FilmHausDbContext.SaveChanges();
            }
            catch (InvalidOperationException ex)
            {
                throw ex;
            }
        }

        public void RemoveShowInList(Guid listId, Guid mediaId)
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
        }

        public void ObsoleteShowInList(Guid listShowId)
        {
            try
            {
                var result = FilmHausDbContext.ListShows.Find(listShowId);

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
        }

        public void ObsoleteShowInList(Guid listId, Guid mediaId)
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
        }
    }
}