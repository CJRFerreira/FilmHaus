using FilmHaus.Models.View;
using System;
using System.Collections.Generic;

namespace FilmHaus.Services.ShowPersonTitles
{
    public interface IShowPersonTitleService
    {
        List<PersonTitleViewModel> GetAllPersonsAndTitlesForShow(Guid mediaId);

        List<ShowViewModel> GetAllShowsForPerson(Guid personId);

        List<TitleViewModel> GetAllTitlesForPerson(Guid personId);

        List<PersonViewModel> GetAllPeopleForTitle(Guid titleId);

        List<ShowViewModel> GetAllShowsForPersonAsTitle(Guid personId, Guid titleId);

        void AddPersonAsTitleToShow(Guid mediaId, Guid personId, Guid titleId);

        void RemovePersonAsTitleFromShow(Guid mediaId, Guid personId, Guid titleId);
    }
}