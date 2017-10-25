using FilmHaus.Models.View;
using System;
using System.Collections.Generic;

namespace FilmHaus.Services.Films
{
    public interface IFilmService
    {
        GeneralFilmViewModel GetFilmByMediaId(Guid mediaId);

        List<GeneralFilmViewModel> GetAllFilms();

        List<GeneralFilmViewModel> GetAllActiveFilms();

        List<GeneralFilmViewModel> GetFilmsBySearchTerm(string searchTerm);

        List<GeneralFilmViewModel> GetFilmsByListId(Guid mediaId);

        void CreateFilm(CreateFilmViewModel film);

        void DeleteFilmByMediaId(Guid mediaId);

        void ObsoleteFilmByMediaId(Guid mediaId);

        void UpdateFilmByMediaId(Guid mediaId, EditFilmViewModel film);
    }
}