using FilmHaus.Models.View;
using System;
using System.Collections.Generic;

namespace FilmHaus.Services.Films
{
    public interface IFilmService
    {
        FilmViewModel GetFilmByFilmId(Guid id, string userId);

        List<FilmViewModel> GetAllFilms();

        List<FilmViewModel> GetAllFilmsForUser(string id);

        List<FilmViewModel> GetFilmsBySearchTerm(string searchTerm);

        List<FilmViewModel> GetFilmsByListId(Guid id);

        int GetAverageFilmRating(Guid id);

        void CreateFilm(CreateFilmViewModel film);

        void DeleteFilmByFilmId(Guid id);

        void UpdateFilmByFilmId(Guid id, EditFilmViewModel film);
    }
}