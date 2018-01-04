using System;
using System.Collections.Generic;
using FilmHaus.Models;
using FilmHaus.Models.View;
using FilmHaus.Models.Connector;
using System.Data.Entity;
using System.Linq;
using static FilmHaus.Services.ShowQueryExtensions;
using LinqKit;

namespace FilmHaus.Services.UserShows
{
    public class UserShowService : IUserShowService
    {
        private FilmHausDbContext FilmHausDbContext { get; set; }

        public UserShowService(FilmHausDbContext filmHausDbContext)
        {
            FilmHausDbContext = filmHausDbContext;
        }

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

        public bool RemoveShowFromUserLibrary(Guid userShowId)
        {
            try
            {
                var userShow = FilmHausDbContext.UserShows.Find(userShowId);

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

        public bool ObsoleteShowInUserLibrary(Guid userShowId)
        {
            try
            {
                var result = FilmHausDbContext.UserShows.Find(userShowId);

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

        public List<ShowViewModel> GetAllShowsForUser(string userId)
        {
            return FilmHausDbContext.UserShows.AsExpandable().Where(us => us.Id == userId && us.ObsoletedOn == null).Select(GetUserShowViewModel()).ToList();
        }

        public bool IsShowInLibrary(Guid mediaId, string userId)
        {
            return FilmHausDbContext.UserShows.Where(uf => uf.Id == userId && uf.MediaId == mediaId && uf.ObsoletedOn == null).Any();
        }
    }
}