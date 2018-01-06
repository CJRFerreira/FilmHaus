using FilmHaus.Models.Base;
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
namespace FilmHaus.Services.Lists
{
    public interface IListService
    {
        void CreateList(CreateListViewModel list);

        void DeleteListByListId(Guid listId);

        void UpdateListByListId(Guid listId, EditListViewModel list);

        ListViewModel GetListByListId(Guid listId);

        ListLibraryViewModel GetListWithMediaByListId(Guid listId);

        List<ListViewModel> GetAllSharedLists();

        List<ListViewModel> GetAllLists();

        List<ListViewModel> GetAllListsByUserId(string userId);
    }
}