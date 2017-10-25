using System;

namespace FilmHaus.Services.UserShowRatings
{
    public interface IUserShowRatingService
    {
        void AddRatingToUserLibrary(string userId, Guid mediaId, int rating);

        void ChangeRatingInUserLibrary(Guid userShowId, int rating);

        void ObsoleteRatingInUserLibrary(Guid userShowId);

        double? GetAverageShowRating(Guid mediaId);
    }
}