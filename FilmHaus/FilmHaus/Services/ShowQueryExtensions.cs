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

namespace FilmHaus.Services
{
    internal static class ShowQueryExtensions
    {
        public static Expression<Func<Show, double?>> GetAverageShowRating()
        {
            return f => f.UserShowRatings.Where(ufr => ufr.MediaId == f.MediaId).Select(ufr => (double?)ufr.Rating).Average();
        }

        public static Expression<Func<UserShow, int>> GetUserShowRating()
        {
            return f => f.Show.UserShowRatings.Where(ufr => ufr.Id == f.Id && ufr.MediaId == f.MediaId && ufr.ObsoletedOn == null).Select(ufr => ufr.Rating).FirstOrDefault();
        }

        public static Expression<Func<Show, bool>> HasAverageShowRating()
        {
            return f => f.UserShowRatings.Where(ufr => ufr.MediaId == f.MediaId).Select(ufr => ufr.Rating).Any();
        }

        public static Expression<Func<UserShow, bool>> HasUserShowRating()
        {
            return f => f.Show.UserShowRatings.Where(ufr => ufr.Id == f.Id && ufr.MediaId == f.MediaId && ufr.ObsoletedOn == null).Select(ufr => ufr.Rating).Any();
        }

        public static Expression<Func<UserShow, bool>> IsInUserShows()
        {
            return f => f.Show.UserShows.Where(ufr => ufr.Id == f.Id && ufr.MediaId == f.MediaId && ufr.ObsoletedOn == null).Any();
        }

        public static Expression<Func<UserShow, ShowViewModel>> GetUserShowViewModel()
        {
            var hasRating = HasUserShowRating();
            var inLibrary = IsInUserShows();
            var userRating = GetUserShowRating();

            return s => new ShowViewModel()
            {
                MediaId = s.MediaId,
                MediaName = s.Show.MediaName,
                PosterUri = s.Show.PosterUri,
                DateOfRelease = s.Show.DateOfRelease,
                Accolades = s.Show.Accolades,
                NumberOfSeasons = s.Show.NumberOfSeasons,
                Rating = userRating.Invoke(s),
                UserHasRated = hasRating.Invoke(s),
                InCurrentUserLibrary = inLibrary.Invoke(s)
            };
        }

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
                Rating = hasRating.Invoke(s) ? averageRating.Invoke(s) : null
            };
        }
    }
}