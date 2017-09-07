using FilmHaus.Models.Base;
using System.Collections.Generic;

namespace FilmHaus.Services.Films
{
    internal interface IFilmService
    {
        Film GetFilmByFilmId(string id);

        ICollection<Film> GetAllFilms();

        ICollection<Film> GetAllFilmsForUser(string id);

        ICollection<Film> GetFilmsBySearchTerm(string searchTerm);

        void CreateFilm(Film film);

        void DeleteFilmByFilmId(string id);

        void UpdateFilmByFilmId(string id);
    }
}