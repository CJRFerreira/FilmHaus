using FilmHaus.Models.View;
using System;
using System.Collections.Generic;

namespace FilmHaus.Services.ListFilms
{
    public interface IListFilmService
    {
        List<GeneralFilmViewModel> GetAllFilmsByListId(Guid listId);

        void AddFilmToList(Guid listId, Guid mediaId);

        void RemoveFilmInList(Guid listFilmId);

        void RemoveFilmInList(Guid listId, Guid mediaId);

        void ObsoleteFilmInList(Guid listFilmId);

        void ObsoleteFilmInList(Guid listId, Guid mediaId);
    }
}