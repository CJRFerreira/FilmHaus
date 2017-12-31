using FilmHaus.Models.View;
using System;
using System.Collections.Generic;

namespace FilmHaus.Services.FilmPersonTitles
{
    public interface IFilmPersonTitleService
    {
        List<PersonTitleViewModel> GetAllPersonsAndTitlesForFilm(Guid mediaId);

        List<FilmViewModel> GetAllFilmsForPerson(Guid personId);

        List<FilmViewModel> GetAllTitlesForPerson(Guid personId);

        List<FilmViewModel> GetAllPeopleForTitle(Guid personId);

        List<FilmViewModel> GetAllFilmsForPersonAsTitle(Guid personId, Guid titleId);

        void AddPersonAsTitleToFilm(Guid mediaId, Guid personId, Guid titleId);

        void RemovePersonAsTitleToFilm(Guid filmPersonTitleId);

        void RemovePersonAsTitleToFilm(Guid mediaId, Guid personId, Guid titleId);
    }
}