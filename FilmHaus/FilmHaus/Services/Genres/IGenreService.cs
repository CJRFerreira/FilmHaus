using FilmHaus.Models.Base;
using FilmHaus.Models.View;
using System;
using System.Collections.Generic;

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