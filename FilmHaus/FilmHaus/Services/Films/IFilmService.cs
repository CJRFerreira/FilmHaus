using FilmHaus.Models.View;
using System;
using System.Collections.Generic;

namespace FilmHaus.Services.Films
{
    public interface IFilmService
    {
        GeneralFilmViewModel GetFilmByMediaId(Guid mediaId);

        List<GeneralFilmViewModel> GetAllFilms();

        List<GeneralFilmViewModel> GetFilmsBySearchTerm(string searchTerm);

        void CreateFilm(CreateFilmViewModel film);

        void DeleteFilmByMediaId(Guid mediaId);

        void UpdateFilmByMediaId(Guid mediaId, EditFilmViewModel film);
    }
}