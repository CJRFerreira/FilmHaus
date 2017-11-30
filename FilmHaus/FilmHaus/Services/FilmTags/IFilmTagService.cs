using FilmHaus.Models.View;
using System;
using System.Collections.Generic;

namespace FilmHaus.Services.FilmTags
{
    public interface IFilmTagService
    {
        List<GenreViewModel> GetAllTagsForFilm(Guid mediaId);

        List<GeneralFilmViewModel> GetAllFilmsWithTag(Guid tagId);

        void AddTagToFilm(Guid genreId, Guid mediaId);

        void RemoveTagFromFilm(Guid filmTagId);

        void RemoveTagFromFilmm(Guid tagId, Guid mediaId);
    }
}