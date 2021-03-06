﻿using FilmHaus.Models;
using FilmHaus.Models.Base;
using FilmHaus.Models.View;
using FilmHaus.Services.UserFilms;
using FilmHaus.Services.UserFilmRatings;
using LinqKit;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using static FilmHaus.Services.FilmQueryExtensions;

/// <summary>
/// Name: Christian Ferreira
/// Date: September 6th - January 5th
///
/// Statement of Authorship:
/// I, Christian Ferreira (Student #: 000346210), certify that this material is my original work.
/// No other person's work has been used without due acknowledgement.
/// </summary>
namespace FilmHaus.Services.Films
{
    public class FilmService : IFilmService
    {
        private FilmHausDbContext FilmHausDbContext { get; }

        private IUserFilmService UserFilmService { get; }

        private IUserFilmRatingService UserFilmRatingService { get; }

        public FilmService(FilmHausDbContext filmHausDbContext, IUserFilmService userFilmService, IUserFilmRatingService userFilmRatingService)
        {
            FilmHausDbContext = filmHausDbContext;
            UserFilmService = userFilmService;
            UserFilmRatingService = userFilmRatingService;
        }

        public void CreateFilm(CreateFilmViewModel film)
        {
            FilmHausDbContext.Films.Add(new Film
            {
                MediaId = Guid.NewGuid(),
                MediaName = film.MediaName,
                DateOfRelease = film.DateOfRelease,
                Accolades = film.Accolades,
                PosterUri = film.PosterUri,
                Runtime = film.Runtime,
                CreatedOn = DateTime.Now
            });
            FilmHausDbContext.SaveChanges();
        }

        public void DeleteFilmByMediaId(Guid mediaId)
        {
            try
            {
                var film = FilmHausDbContext.Films.Find(mediaId);

                if (film != null)
                {
                    FilmHausDbContext.Films.Remove(film);
                    FilmHausDbContext.SaveChanges();
                }
                else
                    throw new ArgumentNullException();
            }
            catch (InvalidOperationException ex)
            {
                throw ex;
            }
        }

        public List<FilmViewModel> GetAllFilms(string userId)
        {
            var films = new List<FilmViewModel>();

            var userFilm = GetUserFilmViewModel();
            var generalFilm = GetGeneralFilmViewModel();

            foreach (var film in FilmHausDbContext.Films.ToList())
            {
                var result = new FilmViewModel();

                if (UserFilmRatingService.DoesUserHaveRating(userId, film.MediaId))
                {
                    result = userFilm.Invoke(film.UserFilms
                             .Where(uf => uf.Id == userId && uf.MediaId == film.MediaId)
                             .FirstOrDefault()
                             );
                }
                else
                {
                    result = generalFilm.Invoke(film);
                    result.InCurrentUserLibrary = UserFilmService.IsFilmInLibrary(film.MediaId, userId);
                }

                films.Add(result);
            }

            return films;
        }

        public FilmViewModel GetFilmByMediaId(string userId, Guid mediaId)
        {
            var film = FilmHausDbContext.Films.AsExpandable().Where(f => f.MediaId == mediaId).FirstOrDefault();

            var userFilm = GetUserFilmViewModel();
            var generalFilm = GetGeneralFilmViewModel();

            if (UserFilmRatingService.DoesUserHaveRating(userId, film.MediaId))
            {
                return userFilm.Invoke(film.UserFilms
                         .Where(uf => uf.Id == userId && uf.MediaId == film.MediaId)
                         .FirstOrDefault()
                         );
            }
            else
            {
                var result = generalFilm.Invoke(film);
                result.InCurrentUserLibrary = UserFilmService.IsFilmInLibrary(mediaId, userId);

                return result;
            }
        }

        public List<FilmViewModel> GetFilmsBySearchTerm(string userId, string searchTerm)
        {
            var films = new List<FilmViewModel>();

            var userFilm = GetUserFilmViewModel();
            var generalFilm = GetGeneralFilmViewModel();

            foreach (var film in FilmHausDbContext.Films.Where(f => f.MediaName.Contains(searchTerm)).ToList())
            {
                var result = new FilmViewModel();

                if (UserFilmRatingService.DoesUserHaveRating(userId, film.MediaId))
                {
                    result = userFilm.Invoke(film.UserFilms
                             .Where(uf => uf.Id == userId && uf.MediaId == film.MediaId)
                             .FirstOrDefault()
                             );
                }
                else
                {
                    result = generalFilm.Invoke(film);
                    result.InCurrentUserLibrary = UserFilmService.IsFilmInLibrary(film.MediaId, userId);
                }

                films.Add(result);
            }

            return films;
        }

        public void UpdateFilmByMediaId(Guid mediaId, EditFilmViewModel film)
        {
            try
            {
                var result = FilmHausDbContext.Films.Find(mediaId);

                if (result == null)
                    throw new ArgumentNullException();

                result.PosterUri = film.PosterUri;
                result.MediaName = film.MediaName;
                result.DateOfRelease = film.DateOfRelease;
                result.Accolades = film.Accolades;
                result.Runtime = film.Runtime;

                FilmHausDbContext.Entry(result).State = EntityState.Modified;
                FilmHausDbContext.SaveChanges();
            }
            catch (InvalidOperationException ex)
            {
                throw ex;
            }
        }
    }
}