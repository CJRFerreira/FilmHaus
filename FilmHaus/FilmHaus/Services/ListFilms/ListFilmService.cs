using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using FilmHaus.Models;
using FilmHaus.Models.View;
using FilmHaus.Models.Connector;
using static FilmHaus.Services.ReviewQueryExtensions;

namespace FilmHaus.Services.ListFilms
{
    public class ListFilmService : IListFilmService
    {
        private FilmHausDbContext FilmHausDbContext { get; set; }

        public ListFilmService(FilmHausDbContext filmHausDbContext)
        {
            FilmHausDbContext = filmHausDbContext;
        }

        public List<GeneralFilmViewModel> GetAllFilmsByListId(Guid listId)
        {
            throw new NotImplementedException();
        }

        public void CreateListFilm(Guid listId, Guid mediaId)
        {
            throw new NotImplementedException();
        }

        public void DeleteListFilm(Guid listFilmId)
        {
            throw new NotImplementedException();
        }

        public void DeleteListFilm(Guid listId, Guid mediaId)
        {
            throw new NotImplementedException();
        }

        public void ObsoleteListFilm(Guid listFilmId)
        {
            throw new NotImplementedException();
        }

        public void ObsoleteListFilm(Guid listId, Guid mediaId)
        {
            throw new NotImplementedException();
        }
    }
}