using FilmHaus.Models.View;
using System;
using System.Collections.Generic;

namespace FilmHaus.Services.ListFilms
{
    public interface IListFilmService
    {
        List<FilmViewModel> GetAllFilmsForList(Guid listId);

        List<ListViewModel> GetAllListsWithFilm(Guid mediaId);

        bool AddFilmToList(Guid listId, Guid mediaId);

        bool RemoveFilmInList(Guid listFilmId);

        bool RemoveFilmInList(Guid listId, Guid mediaId);

        bool ObsoleteFilmInList(Guid listFilmId);

        bool ObsoleteFilmInList(Guid listId, Guid mediaId);
    }
}