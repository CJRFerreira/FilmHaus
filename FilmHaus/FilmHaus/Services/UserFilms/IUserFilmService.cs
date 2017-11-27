using FilmHaus.Models.View;
using System;
using System.Collections.Generic;

namespace FilmHaus.Services.UserFilms
{
    public interface IUserFilmService
    {
        void AddFilmToUserLibrary(Guid mediaId, string userId);

        void RemoveFilmFromUserLibrary(Guid userFilmId);

        void RemoveFilmFromUserLibrary(Guid mediaId, string userId);

        void ObsoleteFilmInUserLibrary(Guid userFilmId);

        void ObsoleteFilmInUserLibrary(Guid mediaId, string userId);

        List<UserFilmViewModel> GetAllFilmsForUser(string userId);
    }
}