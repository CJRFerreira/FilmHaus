using FilmHaus.Models.Base;
using FilmHaus.Models.View;
using LinqKit;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace FilmHaus.Services
{
    internal static class ReviewQueryExtensions
    {
        public static Expression<Func<Review, Film>> GetFilmFromReview()
        {
            return r => r.ReviewFilm.Where(rf => rf.ReviewId == r.ReviewId).Select(rf => rf.Film).FirstOrDefault();
        }

        public static Expression<Func<Review, Show>> GetShowFromReview()
        {
            return r => r.ReviewShow.Where(rs => rs.ReviewId == r.ReviewId).Select(rs => rs.Show).FirstOrDefault();
        }

        public static Expression<Func<Review, ExpandedReviewViewModel>> GetReviewViewModelWithFilm()
        {
            var getFilm = GetFilmFromReview();
            var getFilmViewModel = FilmQueryExtensions.GetGeneralFilmViewModel();

            return r => new ExpandedReviewViewModel
            {
                ReviewId = r.ReviewId,
                Body = r.Body,
                Shared = r.Shared,
                Flagged = r.Flagged,
                CreatedOn = r.CreatedOn,
                Media = getFilmViewModel.Invoke(getFilm.Invoke(r))
            };
        }

        public static Expression<Func<Review, ExpandedReviewViewModel>> GetReviewViewModelWithShow()
        {
            var getShow = GetShowFromReview();
            var getShowViewModel = ShowQueryExtensions.GetGeneralShowViewModel();

            return r => new ExpandedReviewViewModel
            {
                ReviewId = r.ReviewId,
                Body = r.Body,
                Shared = r.Shared,
                Flagged = r.Flagged,
                CreatedOn = r.CreatedOn,
                Media = getShowViewModel.Invoke(getShow.Invoke(r))
            };
        }
    }
}