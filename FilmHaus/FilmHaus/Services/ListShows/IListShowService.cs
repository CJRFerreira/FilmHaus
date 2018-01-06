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
namespace FilmHaus.Services.ListShows
{
    public interface IListShowService
    {
        List<ShowViewModel> GetAllShowsByListId(Guid listId);

        List<ListViewModel> GetAllListsWithShow(Guid mediaId);

        bool AddShowToList(Guid listId, Guid mediaId);

        bool RemoveShowInList(Guid listId, Guid mediaId);

        bool ObsoleteShowInList(Guid listId, Guid mediaId);
    }
}