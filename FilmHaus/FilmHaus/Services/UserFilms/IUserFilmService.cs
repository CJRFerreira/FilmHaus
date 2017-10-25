using FilmHaus.Models.View;
using System;
using System.Collections.Generic;

namespace FilmHaus.Services.UserFilms
{
    public interface IUserFilmService
    {
        void AddFilmToUserLibrary(Guid mediaId, string userId);

        void RemoveFilmFromUserLibrary(Guid userFilmId);

        List<UserFilmViewModel> GetAllFilmsForUser(string userId);
    }
}