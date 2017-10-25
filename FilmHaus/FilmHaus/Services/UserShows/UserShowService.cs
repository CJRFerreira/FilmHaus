using System;
using System.Collections.Generic;
using FilmHaus.Models;
using FilmHaus.Models.View;
using FilmHaus.Models.Connector;
using System.Data.Entity;
using System.Linq;
using static FilmHaus.Services.ShowQueryExtensions;

namespace FilmHaus.Services.UserShows
{
    public class UserShowService : IUserShowService
    {
        private FilmHausDbContext FilmHausDbContext { get; set; }

        public UserShowService(FilmHausDbContext filmHausDbContext)
        {
            FilmHausDbContext = filmHausDbContext;
        }

        public void AddShowToUserLibrary(Guid mediaId, string userId)
        {
            FilmHausDbContext.UserShows.Add(new UserShow
            {
                UserShowId = Guid.NewGuid(),
                MediaId = mediaId,
                Id = userId,
                CreatedOn = DateTime.Now
            });
            FilmHausDbContext.SaveChanges();
        }

        public void RemoveShowFromUserLibrary(Guid userShowId)
        {
            try
            {
                var show = FilmHausDbContext.UserShows.Find(userShowId);

                if (show != null)
                {
                    FilmHausDbContext.UserShows.Remove(show);
                    FilmHausDbContext.SaveChanges();
                }
                else
                    throw new ArgumentNullException();
            }
            catch (InvalidOperationException ex)
            {
                throw ex;
            }
        }

        public void ObsoleteShowInUserLibrary(Guid userShowId)
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
            catch (InvalidOperationException ex)
            {
                throw ex;
            }
        }

        public List<UserShowViewModel> GetAllShowsForUser(string userId)
        {
            return FilmHausDbContext.UserShows.Where(u => u.Id == userId).Select(GetUserShowViewModel()).ToList();
        }
    }
}