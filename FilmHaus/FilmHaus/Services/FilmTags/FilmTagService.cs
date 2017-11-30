using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FilmHaus.Models.View;
using FilmHaus.Models;
using FilmHaus.Models.Base;
using FilmHaus.Models.Connector;
using System.Data.Entity;

namespace FilmHaus.Services.FilmTags
{
    public class FilmTagService : IFilmTagService
    {
        private FilmHausDbContext FilmHausDbContext { get; }

        public FilmTagService(FilmHausDbContext filmHausDbContext)
        {
            FilmHausDbContext = filmHausDbContext;
        }

        public List<GenreViewModel> GetAllTagsForFilm(Guid mediaId)
        {
            throw new NotImplementedException();
        }

        public List<GeneralFilmViewModel> GetAllFilmsWithTag(Guid tagId)
        {
            throw new NotImplementedException();
        }

        public void AddTagToFilm(Guid genreId, Guid mediaId)
        {
            throw new NotImplementedException();
        }

        public void RemoveTagFromFilm(Guid filmTagId)
        {
            throw new NotImplementedException();
        }

        public void RemoveTagFromFilmm(Guid tagId, Guid mediaId)
        {
            throw new NotImplementedException();
        }
    }
}