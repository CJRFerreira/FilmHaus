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