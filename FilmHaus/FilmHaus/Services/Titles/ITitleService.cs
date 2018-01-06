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
namespace FilmHaus.Services.Titles
{
    public interface ITitleService
    {
        void Create(CreateTitleViewModel tag);

        TitleViewModel Retrieve(Guid tagId);

        void Update(Guid tagId, EditTitleViewModel tag);

        void Delete(Guid tagId);
    }
}