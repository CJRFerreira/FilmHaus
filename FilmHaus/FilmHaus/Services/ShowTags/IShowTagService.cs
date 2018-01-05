using FilmHaus.Models.View;
using System;
using System.Collections.Generic;

namespace FilmHaus.Services.ShowTags
{
    public interface IShowTagService
    {
        List<TagViewModel> GetAllTagsForShow(Guid mediaId);

        List<ShowViewModel> GetAllShowsWithTag(Guid tagId);

        void AddTagToShow(Guid tagId, Guid mediaId);

        void RemoveTagFromShow(Guid tagId, Guid mediaId);
    }
}