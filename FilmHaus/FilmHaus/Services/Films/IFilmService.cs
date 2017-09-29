using FilmHaus.Models.View;
using System;
using System.Collections.Generic;

namespace FilmHaus.Services.Films
{
    public interface IFilmService
    {
        FilmViewModel GetFilmByFilmId(Guid filmId);

        List<FilmViewModel> GetAllFilms();

        List<FilmViewModel> GetAllFilmsForUser(string userId);

        List<FilmViewModel> GetFilmsBySearchTerm(string searchTerm);

        List<FilmViewModel> GetFilmsByListId(Guid filmId);

        int GetAverageFilmRating(Guid filmId);

        void CreateFilm(CreateFilmViewModel film);

        void DeleteFilmByFilmId(Guid filmId);

        void UpdateFilmByFilmId(Guid filmId, EditFilmViewModel film);
    }
}