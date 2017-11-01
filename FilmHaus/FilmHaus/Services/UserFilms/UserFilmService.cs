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

        public void AddFilmToUserLibrary(Guid mediaId, string userId)
        {
            FilmHausDbContext.UserFilms.Add(new UserFilm
            {
                UserFilmId = Guid.NewGuid(),
                MediaId = mediaId,
                Id = userId,
                CreatedOn = DateTime.Now
            });
            FilmHausDbContext.SaveChanges();
        }

        public void RemoveFilmFromUserLibrary(Guid userFilmId)
        {
            try
            {
                var film = FilmHausDbContext.UserFilms.Find(userFilmId);

                if (film != null)
                {
                    FilmHausDbContext.UserFilms.Remove(film);
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

        public void ObsoleteFilmInUserLibrary(Guid userFilmId)
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
            catch (InvalidOperationException ex)
            {
                throw ex;
            }
        }

        public List<UserFilmViewModel> GetAllFilmsForUser(string userId)
        {
            return FilmHausDbContext.UserFilms.AsExpandable().Where(uf => uf.Id == userId && uf.ObsoletedOn == null).Select(GetUserFilmViewModel()).ToList();
        }
    }
}