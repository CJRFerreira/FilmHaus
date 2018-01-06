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
namespace FilmHaus.Services.ListFilms
{
    public interface IListFilmService
    {
        List<FilmViewModel> GetAllFilmsForList(Guid listId);

        List<ListViewModel> GetAllListsWithFilm(Guid mediaId);

        bool AddFilmToList(Guid listId, Guid mediaId);

        bool RemoveFilmInList(Guid listId, Guid mediaId);

        bool ObsoleteFilmInList(Guid listId, Guid mediaId);
    }
}