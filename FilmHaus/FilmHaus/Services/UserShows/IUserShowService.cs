using System;

namespace FilmHaus.Services.UserShows
{
    public interface IUserShowService
    {
        void AddShowToUserLibrary(Guid mediaId, string userId);

        void RemoveShowFromUserLibrary(Guid userShowId);
    }
}