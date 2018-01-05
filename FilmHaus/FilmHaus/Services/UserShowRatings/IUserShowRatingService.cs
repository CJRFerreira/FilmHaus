using System;

namespace FilmHaus.Services.UserShowRatings
{
    public interface IUserShowRatingService
    {
        bool AddRatingToUserLibrary(string userId, Guid mediaId, int rating);

        bool ChangeRatingInUserLibrary(string userId, Guid mediaId, int rating);

        bool ObsoleteRatinginUserLibrary(string userId, Guid mediaId);

        bool DoesUserHaveRating(string userId, Guid mediaId);

        double? GetAverageShowRating(Guid mediaId);
    }
}