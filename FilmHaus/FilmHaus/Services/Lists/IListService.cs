using FilmHaus.Models.Base;
using FilmHaus.Models.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmHaus.Services.Lists
{
    public interface IListService
    {
        List GetListByListId(string id);

        List<List> GetAllLists();

        List<List> GetAllSharedLists();

        List<List> GetAllListsForUser(string id);

        void CreateList(CreateListViewModel film);

        void DeleteListByListId(string id);

        void UpdateListByListId(string id, EditListViewModel list);
    }
}