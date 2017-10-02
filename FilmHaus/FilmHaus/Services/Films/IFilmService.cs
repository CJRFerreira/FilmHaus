using FilmHaus.Models.View;
using System;
using System.Collections.Generic;

namespace FilmHaus.Services.Films
{
    public interface IFilmService
    {
        FilmViewModel GetFilmByMediaId(Guid mediaId);

        List<FilmViewModel> GetAllFilms();

        List<FilmViewModel> GetAllFilmsForUser(string userId);

        List<FilmViewModel> GetFilmsBySearchTerm(string searchTerm);

        List<FilmViewModel> GetFilmsByListId(Guid mediaId);

        int GetAverageFilmRating(Guid mediaId);

        void CreateFilm(CreateFilmViewModel film);

        void DeleteFilmByMediaId(Guid mediaId);

        void UpdateFilmByMediaId(Guid mediaId, EditFilmViewModel film);
    }
}