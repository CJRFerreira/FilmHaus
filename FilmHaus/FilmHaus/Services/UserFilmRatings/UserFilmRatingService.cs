using System;
using FilmHaus.Models;

namespace FilmHaus.Services.UserFilms
{
    public class UserFilmService : IUserFilmService
    {
        private FilmHausDbContext FilmHausDbContext { get; set; }

        public UserFilmService(FilmHausDbContext filmHausDbContext)
        {
            FilmHausDbContext = filmHausDbContext;
        }

        public void AddFilmToUserLibrary(Guid userFilmId)
        {
            throw new NotImplementedException();
        }

        public void RemoveFilmFromUserLibrary(Guid userFilmId)
        {
            throw new NotImplementedException();
        }

        public void ChangeRatingForUserFilm(Guid userFilmId, int? rating)
        {
            throw new NotImplementedException();
        }
    }
}