using FilmHaus.Models.View;
using System;
using System.Collections.Generic;

namespace FilmHaus.Services.FilmTags
{
    public interface IFilmTagService
    {
        List<TagViewModel> GetAllTagsForFilm(Guid mediaId);

        List<FilmViewModel> GetAllFilmsWithTag(Guid tagId);

        void AddTagToFilm(Guid tagId, Guid mediaId);

        void RemoveTagFromFilm(Guid tagId, Guid mediaId);
    }
}