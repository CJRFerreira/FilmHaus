using FilmHaus.Models.View;
using System;
using System.Collections.Generic;

namespace FilmHaus.Services.Films
{
    public interface IFilmService
    {
        FilmViewModel GetFilmByMediaId(string userId, Guid mediaId);

        List<FilmViewModel> GetAllFilms(string userId);

        List<FilmViewModel> GetFilmsBySearchTerm(string userId, string searchTerm);

        void CreateFilm(CreateFilmViewModel film);

        void DeleteFilmByMediaId(Guid mediaId);

        void UpdateFilmByMediaId(Guid mediaId, EditFilmViewModel film);
    }
}