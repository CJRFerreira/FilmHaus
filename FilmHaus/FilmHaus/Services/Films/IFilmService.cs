using FilmHaus.Models.Base;
using FilmHaus.Models.View;
using System.Collections.Generic;

namespace FilmHaus.Services.Films
{
    internal interface IFilmService
    {
        FilmViewModel GetFilmByFilmId(string id);

        List<FilmViewModel> GetAllFilms();

        List<FilmViewModel> GetAllFilmsForUser(string id);

        List<FilmViewModel> GetFilmsBySearchTerm(string searchTerm);

        List<FilmViewModel> GetFilmsByListId(string id);

        int GetAverageFilmRating(string id);

        void CreateFilm(CreateFilmViewModel film);

        void DeleteFilmByFilmId(string id);

        void UpdateFilmByFilmId(string id, EditFilmViewModel film);
    }
}