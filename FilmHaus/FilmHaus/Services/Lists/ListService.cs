using System;
using System.Collections.Generic;
using FilmHaus.Models;
using FilmHaus.Models.View;
using FilmHaus.Services.ListShows;
using FilmHaus.Services.ListFilms;

namespace FilmHaus.Services.Lists
{
    public class ListService : IListService
    {
        private FilmHausDbContext FilmHausDbContext { get; set; }

        private IListFilmService ListFilmService { get; set; }

        private IListShowService ListShowService { get; set; }

        public ListService(FilmHausDbContext filmHausDbContext, IListFilmService listFilmService, IListShowService listShowService)
        {
            FilmHausDbContext = filmHausDbContext;
            ListShowService = listShowService;
            ListFilmService = listFilmService;
        }

        public void CreateList(CreateListViewModel list, string userId)
        {
            throw new NotImplementedException();
        }

        public void DeleteListByListId(Guid listId)
        {
            throw new NotImplementedException();
        }

        public void UpdateListByListId(Guid listId, EditListViewModel list)
        {
            throw new NotImplementedException();
        }

        public ListViewModel GetListByListId(Guid listId)
        {
            throw new NotImplementedException();
        }

        public ListViewModel GetListWithMediaByListId(Guid listId)
        {
            throw new NotImplementedException();
        }

        public List<ListViewModel> GetAllSharedLists()
        {
            throw new NotImplementedException();
        }

        public List<ListViewModel> GetAllLists()
        {
            throw new NotImplementedException();
        }

        public List<ListViewModel> GetAllListsByUserId(string userId)
        {
            throw new NotImplementedException();
        }
    }
}