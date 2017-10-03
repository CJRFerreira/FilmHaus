using FilmHaus.Models.View;
using System;
using System.Collections.Generic;

namespace FilmHaus.Services.Lists
{
    public interface IListService
    {
        ListViewModel GetListByListId(Guid listId);

        List<ListViewModel> GetAllLists();

        List<ListViewModel> GetAllSharedLists();

        List<ListViewModel> GetAllListsForUser(string userId);

        void CreateList(CreateListViewModel list);

        void DeleteListByListId(Guid listId);

        void UpdateListByListId(Guid listId, EditListViewModel list);
    }
}