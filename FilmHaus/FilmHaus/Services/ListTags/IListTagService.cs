using FilmHaus.Models.View;
using System;
using System.Collections.Generic;

namespace FilmHaus.Services.ListTags
{
    public interface IListTagService
    {
        List<TagViewModel> GetAllTagsForList(Guid listId);

        List<ListViewModel> GetAllListsWithTag(Guid tagId);

        void AddTagToList(Guid genreId, Guid listId);

        void RemoveTagFromList(Guid listTagId);

        void RemoveTagFromList(Guid tagId, Guid listId);
    }
}