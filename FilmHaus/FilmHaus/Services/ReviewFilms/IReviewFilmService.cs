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
namespace FilmHaus.Services.ReviewFilms
{
    public interface IReviewFilmService
    {
        List<BaseReviewViewModel> GetAllSharedReviewsByFilmId(Guid mediaId);

        List<BaseReviewViewModel> GetAllFlaggedReviewsByFilmId(Guid mediaId);

        List<BaseReviewViewModel> GetAllReviewsByFilmId(Guid mediaId);

        BaseReviewViewModel GetUserReviewByFilmId(Guid mediaId, string userId);

        void CreateReviewFilm(Guid reviewId, Guid mediaId);

        void DeleteReviewFilm(Guid reviewId, Guid mediaId);

        void ObsoleteReviewFilm(Guid reviewId, Guid mediaId);
    }
}