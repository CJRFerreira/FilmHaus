using FilmHaus.Models.Base;
using FilmHaus.Models.Connector;
using FilmHaus.Models.View;
using LinqKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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
    internal static class ShowQueryExtensions
    {
        /// <summary>
        /// Given a <see cref="Show"/>, return a <see cref="double?"/> representative of the <see cref="Show"/> average rating
        /// </summary>
        /// <returns><see cref="double?"/> representing the rating</returns>
        public static Expression<Func<Show, double?>> GetAverageShowRating()
        {
            return f => f.UserShowRatings.Where(ufr => ufr.MediaId == f.MediaId).Select(ufr => (double?)ufr.Rating).Average();
        }

        /// <summary>
        /// Given a <see cref="UserShow"/>, return their rating for the <see cref="Show"/>
        /// </summary>
        /// <returns><see cref="int"/> representing the rating</returns>
        public static Expression<Func<UserShow, int>> GetUserShowRating()
        {
            return s => s.Show.UserShowRatings.Where(ufr => ufr.Id == s.Id && ufr.MediaId == s.MediaId && ufr.ObsoletedOn == null).Select(ufr => ufr.Rating).FirstOrDefault();
        }

        /// <summary>
        /// Given a <see cref="Show"/>, check to see if a <see cref="Show"/> has an average rating available
        /// </summary>
        /// <returns>True for a average rating, false otherwise</returns>
        public static Expression<Func<Show, bool>> HasAverageShowRating()
        {
            return s => s.UserShowRatings.Where(ufr => ufr.MediaId == s.MediaId).Select(ufr => ufr.Rating).Any();
        }

        /// <summary>
        /// Given a <see cref="UserShow"/>, check to see if a <see cref="Show"/> has a rating available
        /// </summary>
        /// <returns>True for a rating, false otherwise</returns>
        public static Expression<Func<UserShow, bool>> HasUserShowRating()
        {
            return s => s.Show.UserShowRatings.Where(ufr => ufr.Id == s.Id && ufr.MediaId == s.MediaId && ufr.ObsoletedOn == null).Select(ufr => ufr.Rating).Any();
        }

        /// <summary>
        /// Given a <see cref="UserShow"/>, check to see if a <see cref="Show"/> exists in a users library
        /// </summary>
        /// <returns>True if it exists, false otherwise</returns>
        public static Expression<Func<UserShow, bool>> IsInUserShows()
        {
            return s => s.Show.UserShows.Where(ufr => ufr.Id == s.Id && ufr.MediaId == s.MediaId && ufr.ObsoletedOn == null).Any();
        }

        /// <summary>
        /// Given a <see cref="Show"/>, return a view model using user data if available
        /// </summary>
        /// <returns><see cref="ShowViewModel"/> representing the under lying <see cref="Show"/></returns>
        public static Expression<Func<UserShow, ShowViewModel>> GetUserShowViewModel()
        {
            var hasUserRating = HasUserShowRating();
            var hasAverageRating = HasAverageShowRating();

            var inLibrary = IsInUserShows();

            var userRating = GetUserShowRating();
            var averageRating = GetAverageShowRating();

            return s => new ShowViewModel()
            {
                MediaId = s.MediaId,
                MediaName = s.Show.MediaName,
                PosterUri = s.Show.PosterUri,
                DateOfRelease = s.Show.DateOfRelease,
                Accolades = s.Show.Accolades,
                NumberOfSeasons = s.Show.NumberOfSeasons,
                Rating = hasUserRating.Invoke(s) ? userRating.Invoke(s) : hasAverageRating.Invoke(s.Show) ? averageRating.Invoke(s.Show) : null,
                UserHasRated = hasUserRating.Invoke(s),
                InCurrentUserLibrary = inLibrary.Invoke(s)
            };
        }

        /// <summary>
        /// Given a <see cref="Show"/>, return a view model with the default data
        /// </summary>
        /// <returns><see cref="ShowViewModel"/> representing the under lying <see cref="Show"/></returns>
        public static Expression<Func<Show, ShowViewModel>> GetGeneralShowViewModel()
        {
            var hasRating = HasAverageShowRating();
            var averageRating = GetAverageShowRating();

            return s => new ShowViewModel()
            {
                MediaId = s.MediaId,
                MediaName = s.MediaName,
                PosterUri = s.PosterUri,
                DateOfRelease = s.DateOfRelease,
                Accolades = s.Accolades,
                NumberOfSeasons = s.NumberOfSeasons,
                Rating = hasRating.Invoke(s) ? averageRating.Invoke(s) : null,
                UserHasRated = false
            };
        }
    }
}