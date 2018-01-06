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