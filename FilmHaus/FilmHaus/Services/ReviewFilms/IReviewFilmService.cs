using FilmHaus.Models.View;
using System;
using System.Collections.Generic;

namespace FilmHaus.Services.ReviewFilms
{
    public interface IReviewFilmService
    {
        List<ExpandedReviewViewModel> GetAllSharedReviewsByFilmId(Guid mediaId);

        List<ExpandedReviewViewModel> GetAllFlaggedReviewsByFilmId(Guid mediaId);

        List<ExpandedReviewViewModel> GetAllReviewsByFilmId(Guid mediaId);

        void CreateReviewFilm(Guid reviewId, Guid mediaId);

        void DeleteReviewFilm(Guid reviewFilmId);

        void ObsoleteReviewFilm(Guid reviewFilmId);
    }
}