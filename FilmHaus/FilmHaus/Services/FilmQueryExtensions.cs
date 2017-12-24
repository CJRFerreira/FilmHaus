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
    internal static class FilmQueryExtensions
    {
        public static Expression<Func<Film, double?>> GetAverageFilmRating()
        {
            return f => f.UserFilmRatings.Select(ufr => ufr.Rating).Average();
        }

        public static Expression<Func<UserFilm, int>> GetUserFilmRating()
        {
            return f => f.Film.UserFilmRatings.Where(ufr => ufr.Id == f.Id).Select(ufr => ufr.Rating).FirstOrDefault();
        }

        public static Expression<Func<UserFilm, UserFilmViewModel>> GetUserFilmViewModel()
        {
            var userRating = GetUserFilmRating();
            return f => new UserFilmViewModel()
            {
                MediaId = f.MediaId,
                MediaName = f.Film.MediaName,
                PosterUri = f.Film.PosterUri,
                DateOfRelease = f.Film.DateOfRelease,
                Accolades = f.Film.Accolades,
                Runtime = f.Film.Runtime,
                Rating = userRating.Invoke(f)
            };
        }

        public static Expression<Func<Film, GeneralFilmViewModel>> GetGeneralFilmViewModel()
        {
            var averageRating = GetAverageFilmRating();
            return f => new GeneralFilmViewModel()
            {
                MediaId = f.MediaId,
                MediaName = f.MediaName,
                PosterUri = f.PosterUri,
                DateOfRelease = f.DateOfRelease,
                Accolades = f.Accolades,
                Runtime = f.Runtime,
                Rating = averageRating.Invoke(f)
            };
        }
    }
}