using FilmHaus.Models.View;
using System;
using System.Collections.Generic;

/// <summary>
/// Name: Christian Ferreira
/// Date: September 6th - January 5th
///
/// Statement of Authorship:
/// I, Christian Ferreira (Student #: 000346210), certify that this material is my original work.
/// No other person's work has been used without due acknowledgement.
/// </summary>
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