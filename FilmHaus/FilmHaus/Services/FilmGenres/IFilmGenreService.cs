﻿using FilmHaus.Models.View;
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
namespace FilmHaus.Services.FilmGenres
{
    public interface IFilmGenreService
    {
        List<GenreViewModel> GetAllGenresForFilm(Guid mediaId);

        List<FilmViewModel> GetAllFilmsForGenre(Guid genreId);

        void AddGenreToFilm(Guid genreId, Guid mediaId);

        void RemoveGenreFromFilm(Guid genreId, Guid mediaId);
    }
}