using FilmHaus.Models.View;
using System;
using System.Collections.Generic;

namespace FilmHaus.Services.UserShows
{
    public interface IUserShowService
    {
        void AddShowToUserLibrary(Guid mediaId, string userId);

        void RemoveShowFromUserLibrary(Guid userShowId);

        void ObsoleteShowInUserLibrary(Guid userShowId);

        List<UserShowViewModel> GetAllShowsForUser(string userId);
    }
}