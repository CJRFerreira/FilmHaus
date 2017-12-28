using FilmHaus.Models;
using FilmHaus.Models.Base;
using FilmHaus.Models.View;
using FilmHaus.Services.UserFilmRatings;
using LinqKit;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using static FilmHaus.Services.FilmQueryExtensions;

namespace FilmHaus.Services.Films
{
    public class FilmService : IFilmService
    {
        protected FilmHausDbContext FilmHausDbContext { get; set; }

        protected IUserFilmRatingService UserFilmRatingService { get; set; }

        public FilmService(FilmHausDbContext filmHausDbContext, IUserFilmRatingService userFilmRatingService)
        {
            FilmHausDbContext = filmHausDbContext;
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

        public List<FilmViewModel> GetAllFilms()
        {
            return FilmHausDbContext.Films.AsExpandable().Select(GetGeneralFilmViewModel()).ToList();
        }

        public FilmViewModel GetFilmByMediaId(Guid mediaId)
        {
            return FilmHausDbContext.Films.AsExpandable().Where(f => f.MediaId == mediaId).Select(GetGeneralFilmViewModel()).FirstOrDefault();
        }

        public List<FilmViewModel> GetFilmsBySearchTerm(string searchTerm)
        {
            return FilmHausDbContext.Films.AsExpandable().Where(f => f.MediaName.Contains(searchTerm)).Select(GetGeneralFilmViewModel()).ToList();
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