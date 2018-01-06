using FilmHaus.Models.Base;
using FilmHaus.Models.View;
using LinqKit;
using System;
using System.Linq;
using System.Linq.Expressions;
using static FilmHaus.Services.UserQueryExtensions;

/// <summary>
/// Name: Christian Ferreira
/// Date: September 6th - January 5th
///
/// Statement of Authorship:
/// I, Christian Ferreira (Student #: 000346210), certify that this material is my original work.
/// No other person's work has been used without due acknowledgement.
/// </summary>
namespace FilmHaus.Services
{
    internal static class ReviewQueryExtensions
    {
        /// <summary>
        /// Given a <see cref="Review"/>, retrieve the <see cref="Film"/>
        /// </summary>
        /// <returns><see cref="Film"/> the <see cref="Review"/> is for</returns>
        public static Expression<Func<Review, Film>> GetFilmFromReview()
        {
            return r => r.ReviewFilm.Where(rf => rf.ReviewId == r.ReviewId).Select(rf => rf.Film).FirstOrDefault();
        }

        /// <summary>
        /// Given a <see cref="Review"/>, retrieve the <see cref="Show"/>
        /// </summary>
        /// <returns><see cref="Show"/> the <see cref="Review"/> is for</returns>
        public static Expression<Func<Review, Show>> GetShowFromReview()
        {
            return r => r.ReviewShow.Where(rs => rs.ReviewId == r.ReviewId).Select(rs => rs.Show).FirstOrDefault();
        }

        /// <summary>
        /// Given a <see cref="Review"/>, return a view model with the <see cref="Film"/> attached
        /// </summary>
        /// <returns><see cref="ExpandedReviewViewModel"/> representing the under lying <see cref="Review"/></returns>
        public static Expression<Func<Review, ExpandedReviewViewModel>> GetReviewViewModelWithFilm()
        {
            var getFilm = GetFilmFromReview();
            var user = GetUserViewModel();
            var getFilmViewModel = FilmQueryExtensions.GetGeneralFilmViewModel();

            return r => new ExpandedReviewViewModel
            {
                ReviewId = r.ReviewId,
                Id = r.Id,
                User = user.Invoke(r.User),
                Body = r.Body,
                Shared = r.Shared,
                Flagged = r.Flagged,
                CreatedOn = r.CreatedOn,
                ReviewType = r.ReviewType,
                Media = getFilmViewModel.Invoke(getFilm.Invoke(r))
            };
        }

        /// <summary>
        /// Given a <see cref="Review"/>, return a view model with the <see cref="Show"/> attached
        /// </summary>
        /// <returns><see cref="ExpandedReviewViewModel"/> representing the under lying <see cref="Review"/></returns>
        public static Expression<Func<Review, ExpandedReviewViewModel>> GetReviewViewModelWithShow()
        {
            var getShow = GetShowFromReview();
            var user = GetUserViewModel();
            var getShowViewModel = ShowQueryExtensions.GetGeneralShowViewModel();

            return r => new ExpandedReviewViewModel
            {
                ReviewId = r.ReviewId,
                Id = r.Id,
                User = user.Invoke(r.User),
                Body = r.Body,
                Shared = r.Shared,
                Flagged = r.Flagged,
                CreatedOn = r.CreatedOn,
                ReviewType = r.ReviewType,
                Media = getShowViewModel.Invoke(getShow.Invoke(r))
            };
        }

        /// <summary>
        /// Given a <see cref="Review"/>, return a view model
        /// </summary>
        /// <returns><see cref="BaseReviewViewModel"/> representing the under lying <see cref="Review"/></returns>
        public static Expression<Func<Review, BaseReviewViewModel>> GetReviewViewModel()
        {
            var user = GetUserViewModel();

            return r => new BaseReviewViewModel
            {
                ReviewId = r.ReviewId,
                Id = r.Id,
                User = user.Invoke(r.User),
                Body = r.Body,
                Shared = r.Shared,
                Flagged = r.Flagged,
                CreatedOn = r.CreatedOn,
                ReviewType = r.ReviewType
            };
        }
    }
}