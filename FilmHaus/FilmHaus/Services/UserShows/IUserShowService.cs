﻿using FilmHaus.Models.View;
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
namespace FilmHaus.Services.UserShows
{
    public interface IUserShowService
    {
        bool AddShowToUserLibrary(Guid mediaId, string userId);

        bool RemoveShowFromUserLibrary(Guid mediaId, string userId);

        bool ObsoleteShowInUserLibrary(Guid mediaId, string userId);

        bool IsShowInLibrary(Guid mediaId, string userId);

        List<ShowViewModel> GetAllShowsForUser(string userId);
    }
}