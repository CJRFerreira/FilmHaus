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