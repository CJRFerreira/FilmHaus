using FilmHaus.Models.Base;
using FilmHaus.Models.View;
using System;
using System.Collections.Generic;

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