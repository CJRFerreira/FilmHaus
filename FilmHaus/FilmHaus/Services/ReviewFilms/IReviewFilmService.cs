using FilmHaus.Models.View;
using System;
using System.Collections.Generic;

namespace FilmHaus.Services.ReviewFilms
{
    public interface IReviewFilmService
    {
        List<BaseReviewViewModel> GetAllSharedReviewsByFilmId(Guid mediaId);

        List<BaseReviewViewModel> GetAllFlaggedReviewsByFilmId(Guid mediaId);

        List<BaseReviewViewModel> GetAllReviewsByFilmId(Guid mediaId);

        void CreateReviewFilm(Guid reviewId, Guid mediaId);

        void DeleteReviewFilm(Guid reviewFilmId);

        void DeleteReviewFilm(Guid reviewId, Guid mediaId);

        void ObsoleteReviewFilm(Guid reviewFilmId);

        void ObsoleteReviewFilm(Guid reviewId, Guid mediaId);
    }
}