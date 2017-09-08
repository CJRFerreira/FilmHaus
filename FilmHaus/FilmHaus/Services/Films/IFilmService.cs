using FilmHaus.Models.Base;
using FilmHaus.Models.View;
using System.Collections.Generic;

namespace FilmHaus.Services.Films
{
    internal interface IFilmService
    {
        Film GetFilmByFilmId(string id);

        List<Film> GetAllFilms();

        List<Film> GetAllFilmsForUser(string id);

        List<Film> GetFilmsBySearchTerm(string searchTerm);

        List<Film> GetFilmsByListId(string id);

        void CreateFilm(CreateFilmViewModel film);

        void DeleteFilmByFilmId(string id);

        void UpdateFilmByFilmId(string id, EditFilmViewModel film);
    }
}