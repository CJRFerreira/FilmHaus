using FilmHaus.Models.View;
using System;
using System.Collections.Generic;

namespace FilmHaus.Services.Films
{
    public interface IFilmService
    {
        FilmViewModel GetFilmByMediaId(Guid MediaId);

        List<FilmViewModel> GetAllFilms();

        List<FilmViewModel> GetAllFilmsForUser(string userId);

        List<FilmViewModel> GetFilmsBySearchTerm(string searchTerm);

        List<FilmViewModel> GetFilmsByListId(Guid MediaId);

        int GetAverageFilmRating(Guid MediaId);

        void CreateFilm(CreateFilmViewModel film);

        void DeleteFilmByMediaId(Guid MediaId);

        void UpdateFilmByMediaId(Guid MediaId, EditFilmViewModel film);
    }
}