using FilmHaus.Models.View;
using System;
using System.Collections.Generic;

namespace FilmHaus.Services.UserShows
{
    public interface IUserShowService
    {
        bool AddShowToUserLibrary(Guid mediaId, string userId);

        bool RemoveShowFromUserLibrary(Guid userShowId);

        bool ObsoleteShowInUserLibrary(Guid userShowId);

        bool ObsoleteShowInUserLibrary(Guid mediaId, string userId);

        bool IsShowInLibrary(Guid mediaId, string userId);

        List<ShowViewModel> GetAllShowsForUser(string userId);
    }
}