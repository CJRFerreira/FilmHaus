using System;

/// <summary>
/// Name: Christian Ferreira
/// Date: September 6th - January 5th
///
/// Statement of Authorship:
/// I, Christian Ferreira (Student #: 000346210), certify that this material is my original work.
/// No other person's work has been used without due acknowledgement.
/// </summary>
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