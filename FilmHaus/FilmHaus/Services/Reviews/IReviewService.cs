using FilmHaus.Enums;
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
namespace FilmHaus.Services.Reviews
{
    public interface IReviewService
    {
        void CreateReviewForFilm(CreateReviewViewModel review, string userId);

        void CreateReviewForShow(CreateReviewViewModel review, string userId);

        void ObsoleteReviewForFilm(Guid reviewId, Guid mediaId);

        void ObsoleteReviewForShow(Guid reviewId, Guid mediaId);

        void DeleteReviewByReviewId(Guid reviewId);

        void UpdateReviewByReviewId(Guid reviewId, EditReviewViewModel review);

        void BanReviewByReviewId(Guid reviewId, ReportReason reportReason);

        void FlagReviewByReviewId(Guid reviewId);

        void UnflagReviewByReviewId(Guid reviewId);

        BaseReviewViewModel GetReviewByReviewId(Guid reviewId);

        ExpandedReviewViewModel GetReviewWithMediaByReviewId(Guid reviewId);

        ReviewLibraryViewModel GetAllSharedReviews();

        ReviewLibraryViewModel GetAllReviewsByUserId(string userId);

        ReviewLibraryViewModel GetAllReviews();

        ReviewLibraryViewModel GetAllFlaggedReviewsByUserId(string userId);

        ReviewLibraryViewModel GetAllFlaggedReviews();
    }
}