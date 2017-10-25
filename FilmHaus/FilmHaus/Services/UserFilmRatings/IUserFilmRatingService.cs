using System;

namespace FilmHaus.Services.UserFilmRatings
{
    public interface IUserFilmRatingService
    {
        void AddRatingToUserLibrary(string userId, Guid mediaId, int rating);

        void ChangeRatingInUserLibrary(Guid userFilmId, int rating);

        void ObsoleteRatingInUserLibrary(Guid userFilmId);

        double? GetAverageFilmRating(Guid mediaId);
    }
}