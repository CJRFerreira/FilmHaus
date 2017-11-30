using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FilmHaus.Models.View;
using FilmHaus.Models;
using FilmHaus.Models.Base;
using FilmHaus.Models.Connector;
using System.Data.Entity;

namespace FilmHaus.Services.ListTags
{
    public class ListTagService : IListTagService
    {
        private FilmHausDbContext FilmHausDbContext { get; }

        public ListTagService(FilmHausDbContext filmHausDbContext)
        {
            FilmHausDbContext = filmHausDbContext;
        }

        public List<GenreViewModel> GetAllTagsForList(Guid listId)
        {
            throw new NotImplementedException();
        }

        public List<ListViewModel> GetAllListsWithTag(Guid tagId)
        {
            throw new NotImplementedException();
        }

        public void AddTagToList(Guid genreId, Guid listId)
        {
            throw new NotImplementedException();
        }

        public void RemoveTagFromList(Guid listTagId)
        {
            throw new NotImplementedException();
        }

        public void RemoveTagFromList(Guid tagId, Guid listId)
        {
            throw new NotImplementedException();
        }
    }
}