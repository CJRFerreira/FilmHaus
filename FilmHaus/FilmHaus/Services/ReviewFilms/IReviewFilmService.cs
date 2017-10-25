using FilmHaus.Models.View;
using System;
using System.Collections.Generic;

namespace FilmHaus.Services.ReviewFilms
{
    public interface IReviewFilmService
    {
        List<ReviewViewModel> GetAllSharedReviewsByFilmId(Guid mediaId);

        List<ReviewViewModel> GetAllFlaggedReviewsByFilmId(Guid mediaId);

        List<ReviewViewModel> GetAllReviewsByFilmId(Guid mediaId);

        void CreateReviewFilm(Guid reviewId, Guid mediaId);

        void DeleteReviewFilm(Guid reviewFilmId);

        void ObsoleteReviewFilm(Guid reviewFilmId);
    }
}