using FilmHaus.Models.View;
using System;
using System.Collections.Generic;

namespace FilmHaus.Services.ShowTags
{
    public interface IShowTagService
    {
        List<GenreViewModel> GetAllTagsForShow(Guid mediaId);

        List<ListViewModel> GetAllShowsWithTag(Guid tagId);

        void AddTagToList(Guid genreId, Guid mediaId);

        void RemoveTagFromList(Guid showTagId);

        void RemoveTagFromList(Guid tagId, Guid mediaId);
    }
}