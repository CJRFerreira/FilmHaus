using System;
using System.Collections.Generic;
using System.Linq;
using FilmHaus.Models.View;
using FilmHaus.Models;
using FilmHaus.Models.Connector;
using System.Data.Entity;
using static FilmHaus.Services.ShowQueryExtensions;
using static FilmHaus.Services.ListQueryExtensions;
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

        public List<ShowViewModel> GetAllShowsByListId(Guid listId)
        {
            return FilmHausDbContext.ListShows.AsExpandable().Where(l => l.ListId == listId).Select(l => l.Show).Select(GetGeneralShowViewModel()).ToList();
        }

        public List<ListViewModel> GetAllListsWithShow(Guid mediaId)
        {
            return FilmHausDbContext.ListShows.AsExpandable().Where(lf => lf.MediaId == mediaId).Select(lf => lf.List).Select(GetListViewModel()).ToList();
        }

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

        public bool RemoveShowInList(Guid listShowId)
        {
            try
            {
                var listShow = FilmHausDbContext.ListShows.Find(listShowId);

                if (listShow == null)
                    throw new ArgumentNullException();

                FilmHausDbContext.ListShows.Remove(listShow);
                FilmHausDbContext.SaveChanges();
                return true;
            }
            catch (InvalidOperationException ex)
            {
                throw ex;
            }
        }

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

        public bool ObsoleteShowInList(Guid listShowId)
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

            return true;
        }

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