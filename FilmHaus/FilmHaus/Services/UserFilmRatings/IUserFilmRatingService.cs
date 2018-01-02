using System;

namespace FilmHaus.Services.UserFilmRatings
{
    public interface IUserFilmRatingService
    {
        bool AddRatingToUserLibrary(string userId, Guid mediaId, int rating);

        bool ChangeRatingInUserLibrary(Guid userFilmId, int rating);

        bool ChangeRatingInUserLibrary(string userId, Guid mediaId, int rating);

        bool ObsoleteRatingInUserLibrary(Guid userFilmId);

        bool ObsoleteRatinginUserLibrary(string userId, Guid mediaId);

        double? GetAverageFilmRating(Guid mediaId);
    }
}