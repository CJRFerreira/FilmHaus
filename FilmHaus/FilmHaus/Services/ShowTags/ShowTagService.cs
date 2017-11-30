using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FilmHaus.Models.View;
using FilmHaus.Models;
using FilmHaus.Models.Base;
using FilmHaus.Models.Connector;
using System.Data.Entity;

namespace FilmHaus.Services.ShowTags
{
    public class ShowTagService : IShowTagService
    {
        private FilmHausDbContext FilmHausDbContext { get; }

        public ShowTagService(FilmHausDbContext filmHausDbContext)
        {
            FilmHausDbContext = filmHausDbContext;
        }

        public List<GenreViewModel> GetAllTagsForShow(Guid mediaId)
        {
            throw new NotImplementedException();
        }

        public List<ListViewModel> GetAllShowsWithTag(Guid tagId)
        {
            throw new NotImplementedException();
        }

        public void AddTagToList(Guid genreId, Guid mediaId)
        {
            throw new NotImplementedException();
        }

        public void RemoveTagFromList(Guid showTagId)
        {
            throw new NotImplementedException();
        }

        public void RemoveTagFromList(Guid tagId, Guid mediaId)
        {
            throw new NotImplementedException();
        }
    }
}