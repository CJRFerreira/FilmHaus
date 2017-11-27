using FilmHaus.Models.View;
using System;
using System.Collections.Generic;

namespace FilmHaus.Services.FilmGenres
{
    public interface IFilmGenreService
    {
        List<GenreViewModel> GetAllGenresForFilm(Guid mediaId);

        List<GeneralFilmViewModel> GetAllFilmsForGenre(Guid genreId);

        void AddGenreToFilm(Guid genreId, Guid mediaId);

        void RemoveGenreFromFilm(Guid filmGenreId);

        void RemoveGenreFromFilm(Guid genreId, Guid mediaId);
    }
}