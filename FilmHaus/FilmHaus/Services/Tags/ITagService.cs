using FilmHaus.Models.Base;
using FilmHaus.Models.View;
using System;

/// <summary>
/// Name: Christian Ferreira
/// Date: September 6th - January 5th
///
/// Statement of Authorship:
/// I, Christian Ferreira (Student #: 000346210), certify that this material is my original work.
/// No other person's work has been used without due acknowledgement.
/// </summary>
namespace FilmHaus.Services.Tags
{
    public interface ITagService
    {
        void Create(CreateTagViewModel tag);

        TagViewModel Retrieve(Guid tagId);

        void Update(Guid tagId, EditTagViewModel tag);

        void Delete(Guid tagId);
    }
}