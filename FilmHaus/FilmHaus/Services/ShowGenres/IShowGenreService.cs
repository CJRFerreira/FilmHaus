using FilmHaus.Models.View;
using System;
using System.Collections.Generic;

namespace FilmHaus.Services.ShowGenres
{
    public interface IShowGenreService
    {
        List<GenreViewModel> GetAllGenresForShow(Guid mediaId);

        List<ShowViewModel> GetAllShowsForGenre(Guid genreId);

        void AddGenreToShow(Guid genreId, Guid mediaId);

        void RemoveGenreFromShow(Guid filmGenreId);

        void RemoveGenreFromShow(Guid genreId, Guid mediaId);
    }
}