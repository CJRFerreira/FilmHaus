using FilmHaus.Models.View;
using System;
using System.Collections.Generic;

/// <summary>
/// Name: Christian Ferreira
/// Date: September 6th - January 5th
///
/// Statement of Authorship:
/// I, Christian Ferreira (Student #: 000346210), certify that this material is my original work.
/// No other person's work has been used without due acknowledgement.
/// </summary>
namespace FilmHaus.Services.ShowGenres
{
    public interface IShowGenreService
    {
        List<GenreViewModel> GetAllGenresForShow(Guid mediaId);

        List<ShowViewModel> GetAllShowsForGenre(Guid genreId);

        void AddGenreToShow(Guid genreId, Guid mediaId);

        void RemoveGenreFromShow(Guid genreId, Guid mediaId);
    }
}