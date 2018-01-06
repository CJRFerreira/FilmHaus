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
namespace FilmHaus.Services.Shows
{
    public interface IShowService
    {
        ShowViewModel GetShowByMediaId(string userId, Guid mediaId);

        List<ShowViewModel> GetAllShows(string userId);

        List<ShowViewModel> GetShowsBySearchTerm(string userId, string searchTerm);

        void CreateShow(CreateShowViewModel show);

        void DeleteShowByMediaId(Guid mediaId);

        void UpdateShowByMediaId(Guid mediaId, EditShowViewModel show);
    }
}