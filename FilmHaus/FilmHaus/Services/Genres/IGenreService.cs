using FilmHaus.Models.Base;
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
namespace FilmHaus.Services.Genres
{
    public interface IGenreService
    {
        void Create(CreateGenreViewModel genre);

        GenreViewModel Retrieve(Guid genreId);

        void Update(Guid genreId, EditGenreViewModel genre);

        void Delete(Guid genreId);
    }
}