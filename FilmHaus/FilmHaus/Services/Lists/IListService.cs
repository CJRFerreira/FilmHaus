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
        List GetListByListId(Guid id);

        List<List> GetAllLists();

        List<List> GetAllSharedLists();

        List<List> GetAllListsForUser(Guid id);

        void CreateList(CreateListViewModel film);

        void DeleteListByListId(Guid id);

        void UpdateListByListId(Guid id, EditListViewModel list);
    }
}