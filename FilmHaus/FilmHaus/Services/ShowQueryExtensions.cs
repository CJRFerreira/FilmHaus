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
            return s => s.UserShowRatings.Select(usr => usr.Rating).Average();
        }

        public static Expression<Func<UserShow, int>> GetUserShowRating()
        {
            return s => s.Show.UserShowRatings.Where(usr => usr.Id == s.Id).Select(usr => usr.Rating).FirstOrDefault();
        }

        public static Expression<Func<UserShow, UserShowViewModel>> GetUserShowViewModel()
        {
            var userRating = GetUserShowRating();
            return s => new UserShowViewModel()
            {
                MediaId = s.MediaId,
                MediaName = s.Show.MediaName,
                PosterUri = s.Show.PosterUri,
                DateOfRelease = s.Show.DateOfRelease,
                Accolades = s.Show.Accolades,
                NumberOfSeasons = s.Show.NumberOfSeasons,
                Rating = (double)userRating.Invoke(s)
            };
        }

        public static Expression<Func<Show, GeneralShowViewModel>> GetGeneralShowViewModel()
        {
            var averageRating = GetAverageShowRating();
            return s => new GeneralShowViewModel()
            {
                MediaId = s.MediaId,
                MediaName = s.MediaName,
                PosterUri = s.PosterUri,
                DateOfRelease = s.DateOfRelease,
                Accolades = s.Accolades,
                NumberOfSeasons = s.NumberOfSeasons,
                Rating = averageRating.Invoke(s)
            };
        }
    }
}