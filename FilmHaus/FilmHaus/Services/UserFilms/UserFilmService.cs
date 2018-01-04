using FilmHaus.Models;
using FilmHaus.Models.Connector;
using FilmHaus.Models.View;
using LinqKit;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using static FilmHaus.Services.FilmQueryExtensions;

namespace FilmHaus.Services.UserFilms
{
    public class UserFilmService : IUserFilmService
    {
        private FilmHausDbContext FilmHausDbContext { get; set; }

        public UserFilmService(FilmHausDbContext filmHausDbContext)
        {
            FilmHausDbContext = filmHausDbContext;
        }

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

        public bool RemoveFilmFromUserLibrary(Guid userFilmId)
        {
            try
            {
                var userFilm = FilmHausDbContext.UserFilms.Find(userFilmId);

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

        public bool ObsoleteFilmInUserLibrary(Guid userFilmId)
        {
            try
            {
                var result = FilmHausDbContext.UserFilms.Find(userFilmId);

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

        public List<FilmViewModel> GetAllFilmsForUser(string userId)
        {
            return FilmHausDbContext.UserFilms.AsExpandable().Where(uf => uf.Id == userId && uf.ObsoletedOn == null).Select(GetUserFilmViewModel()).ToList();
        }

        public bool IsFilmInLibrary(Guid mediaId, string userId)
        {
            return FilmHausDbContext.UserFilms.Where(uf => uf.Id == userId && uf.MediaId == mediaId && uf.ObsoletedOn == null).Any();
        }
    }
}