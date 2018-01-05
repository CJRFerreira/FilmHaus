using FilmHaus.Models.View;
using System;
using System.Collections.Generic;

namespace FilmHaus.Services.UserFilms
{
    public interface IUserFilmService
    {
        bool AddFilmToUserLibrary(Guid mediaId, string userId);

        bool RemoveFilmFromUserLibrary(Guid mediaId, string userId);

        bool ObsoleteFilmInUserLibrary(Guid mediaId, string userId);

        bool IsFilmInLibrary(Guid mediaId, string userId);

        List<FilmViewModel> GetAllFilmsForUser(string userId);
    }
}