using FilmHaus.Models.View;
using System;
using System.Collections.Generic;

namespace FilmHaus.Services.Films
{
    public interface IFilmService
    {
        FilmViewModel GetFilmByMediaId(Guid mediaId);

        List<FilmViewModel> GetAllFilms();

        List<FilmViewModel> GetFilmsBySearchTerm(string searchTerm);

        void CreateFilm(CreateFilmViewModel film);

        void DeleteFilmByMediaId(Guid mediaId);

        void UpdateFilmByMediaId(Guid mediaId, EditFilmViewModel film);
    }
}