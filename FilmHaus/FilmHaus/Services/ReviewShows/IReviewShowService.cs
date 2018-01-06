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
namespace FilmHaus.Services.ReviewShows
{
    public interface IReviewShowService
    {
        List<BaseReviewViewModel> GetAllSharedReviewsByShowId(Guid mediaId);

        List<BaseReviewViewModel> GetAllFlaggedReviewsByShowId(Guid mediaId);

        List<BaseReviewViewModel> GetAllReviewsByShowId(Guid mediaId);

        BaseReviewViewModel GetUserReviewByShowId(Guid mediaId, string userId);

        void CreateReviewShow(Guid reviewId, Guid mediaId);

        void DeleteReviewShow(Guid reviewId, Guid mediaId);

        void ObsoleteReviewShow(Guid reviewId, Guid mediaId);
    }
}