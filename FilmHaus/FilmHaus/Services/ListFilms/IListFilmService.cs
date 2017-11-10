using FilmHaus.Models.View;
using System;
using System.Collections.Generic;

namespace FilmHaus.Services.ListFilms
{
    public interface IListFilmService
    {
        List<GeneralFilmViewModel> GetAllFilmsByListId(Guid listId);

        void CreateListFilm(Guid listId, Guid mediaId);

        void DeleteListFilm(Guid listFilmId);

        void DeleteListFilm(Guid listId, Guid mediaId);

        void ObsoleteListFilm(Guid listFilmId);

        void ObsoleteListFilm(Guid listId, Guid mediaId);
    }
}