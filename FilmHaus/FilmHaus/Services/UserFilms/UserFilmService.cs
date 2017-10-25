using FilmHaus.Models;
using FilmHaus.Models.View;
using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
        }

        public void RemoveFilmFromUserLibrary(Guid userFilmId)
        {
            throw new NotImplementedException();
        }

        public List<UserFilmViewModel> GetAllFilmsForUser(string userId)
        {
            return FilmHausDbContext.UserFilms.Where(u => u.Id == userId).Select(GetUserFilmViewModel()).ToList();
        }
    }
}