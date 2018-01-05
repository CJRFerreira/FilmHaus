﻿using FilmHaus.Models.Base;
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
            return f => f.UserFilmRatings.Where(ufr => ufr.MediaId == f.MediaId).Select(ufr => (double?)ufr.Rating).Average();
        }

        public static Expression<Func<UserFilm, int>> GetUserFilmRating()
        {
            return f => f.Film.UserFilmRatings.Where(ufr => ufr.Id == f.Id && ufr.MediaId == f.MediaId && ufr.ObsoletedOn == null).Select(ufr => ufr.Rating).FirstOrDefault();
        }

        public static Expression<Func<Film, bool>> HasAverageFilmRating()
        {
            return f => f.UserFilmRatings.Where(ufr => ufr.MediaId == f.MediaId).Select(ufr => ufr.Rating).Any();
        }

        public static Expression<Func<UserFilm, bool>> HasUserFilmRating()
        {
            return f => f.Film.UserFilmRatings.Where(ufr => ufr.Id == f.Id && ufr.MediaId == f.MediaId && ufr.ObsoletedOn == null).Select(ufr => ufr.Rating).Any();
        }

        public static Expression<Func<UserFilm, bool>> IsInUserFilms()
        {
            return f => f.Film.UserFilms.Where(ufr => ufr.Id == f.Id && ufr.MediaId == f.MediaId && ufr.ObsoletedOn == null).Any();
        }

        public static Expression<Func<UserFilm, FilmViewModel>> GetUserFilmViewModel()
        {
            var hasUserRating = HasUserFilmRating();
            var hasAverageRating = HasAverageFilmRating();

            var inLibrary = IsInUserFilms();

            var userRating = GetUserFilmRating();
            var averageRating = GetAverageFilmRating();

            return f => new FilmViewModel()
            {
                MediaId = f.MediaId,
                MediaName = f.Film.MediaName,
                PosterUri = f.Film.PosterUri,
                DateOfRelease = f.Film.DateOfRelease,
                Accolades = f.Film.Accolades,
                Runtime = f.Film.Runtime,
                Rating = hasUserRating.Invoke(f) ? userRating.Invoke(f) : hasAverageRating.Invoke(f.Film) ? averageRating.Invoke(f.Film) : null,
                UserHasRated = hasUserRating.Invoke(f),
                InCurrentUserLibrary = inLibrary.Invoke(f)
            };
        }

        public static Expression<Func<Film, FilmViewModel>> GetGeneralFilmViewModel()
        {
            var hasRating = HasAverageFilmRating();
            var averageRating = GetAverageFilmRating();

            return f => new FilmViewModel()
            {
                MediaId = f.MediaId,
                MediaName = f.MediaName,
                PosterUri = f.PosterUri,
                DateOfRelease = f.DateOfRelease,
                Accolades = f.Accolades,
                Runtime = f.Runtime,
                Rating = hasRating.Invoke(f) ? averageRating.Invoke(f) : null,
                UserHasRated = false
            };
        }
    }
}