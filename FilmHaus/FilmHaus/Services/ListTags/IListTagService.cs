using FilmHaus.Models.View;
using System;
using System.Collections.Generic;

namespace FilmHaus.Services.ListTags
{
    public interface IListTagService
    {
        List<TagViewModel> GetAllTagsForList(Guid listId);

        List<ListViewModel> GetAllListsWithTag(Guid tagId);

        void AddTagToList(Guid tagId, Guid listId);

        void RemoveTagFromList(Guid tagId, Guid listId);
    }
}