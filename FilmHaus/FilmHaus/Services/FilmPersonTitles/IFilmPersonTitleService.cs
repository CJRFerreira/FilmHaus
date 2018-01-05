using FilmHaus.Models.View;
using System;
using System.Collections.Generic;

namespace FilmHaus.Services.FilmPersonTitles
{
    public interface IFilmPersonTitleService
    {
        List<PersonTitleViewModel> GetAllPersonsAndTitlesForFilm(Guid mediaId);

        List<FilmViewModel> GetAllFilmsForPerson(Guid personId);

        List<TitleViewModel> GetAllTitlesForPerson(Guid personId);

        List<PersonViewModel> GetAllPeopleForTitle(Guid titleId);

        List<FilmViewModel> GetAllFilmsForPersonAsTitle(Guid personId, Guid titleId);

        void AddPersonAsTitleToFilm(Guid mediaId, Guid personId, Guid titleId);

        void RemovePersonAsTitleFromFilm(Guid mediaId, Guid personId, Guid titleId);
    }
}