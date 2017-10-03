using System;

namespace FilmHaus.Services.UserFilms
{
    public interface IUserFilmService
    {
        void AddFilmToUserLibrary(string userId, Guid filmID);

        void RemoveFilmFromUserLibrary(string userId, Guid filmID);

        void ChangeRatingForUserFilm(string userId, Guid filmID, int? rating);
    }
}