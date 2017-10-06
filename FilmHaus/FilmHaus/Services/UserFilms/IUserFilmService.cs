using System;

namespace FilmHaus.Services.UserFilms
{
    public interface IUserFilmService
    {
        void AddFilmToUserLibrary(Guid userFilmId);

        void RemoveFilmFromUserLibrary(Guid userFilmId);

        void ChangeRatingForUserFilm(Guid userFilmId, int? rating);
    }
}