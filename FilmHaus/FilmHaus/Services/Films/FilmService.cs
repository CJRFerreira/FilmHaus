using FilmHaus.Models;
using FilmHaus.Models.Base;
using FilmHaus.Models.View;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace FilmHaus.Services.Films
{
    public class FilmService : IFilmService
    {
        private FilmHausDbContext FilmHausDbContext { get; set; }

        public FilmService(FilmHausDbContext filmHausDbContext)
        {
            FilmHausDbContext = filmHausDbContext;
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
            var film = FilmHausDbContext.Films.Find(mediaId);

            if (film != null)
            {
                FilmHausDbContext.Films.Remove(film);
                FilmHausDbContext.SaveChanges();
            }
            else
                throw new ArgumentNullException();
        }

        public void ObsoleteFilmByMediaId(Guid mediaId)
        {
            try
            {
                var result = FilmHausDbContext.Films.Find(mediaId);

                if (result == null)
                    throw new ArgumentNullException();

                result.ObsoletedOn = DateTime.Now;

                FilmHausDbContext.Entry(result).State = EntityState.Modified;
                FilmHausDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<FilmViewModel> GetAllFilms()
        {
            return FilmHausDbContext.Films.Select(x => new FilmViewModel(x)
            {
                Rating = GetAverageFilmRating(x.MediaId)
            })
            .ToList();
        }

        public List<FilmViewModel> GetAllFilmsForUser(string userId)
        {
            return FilmHausDbContext.UserFilms.Where(u => u.Id == userId).Select(x => new FilmViewModel(x.Film)
            {
                Rating = GetAverageFilmRating(x.MediaId)
            })
            .ToList();
        }

        public FilmViewModel GetFilmByMediaId(Guid mediaId)
        {
            return FilmHausDbContext.Films.Where(f => f.MediaId == mediaId).Select(f => new FilmViewModel(f)
            {
                Rating = GetAverageFilmRating(f.MediaId)
            })
            .FirstOrDefault();
        }

        public List<FilmViewModel> GetFilmsByListId(Guid mediaId)
        {
            return FilmHausDbContext.ListFilms.Where(l => l.ListId == mediaId).Select(f => new FilmViewModel(f.Film)
            {
                Rating = GetAverageFilmRating(f.MediaId)
            })
            .ToList();
        }

        public List<FilmViewModel> GetFilmsBySearchTerm(string searchTerm)
        {
            return FilmHausDbContext.Films.Where(f => f.MediaName.Contains(searchTerm)).Select(f => new FilmViewModel(f)
            {
                Rating = GetAverageFilmRating(f.MediaId)
            })
            .ToList();
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
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int GetAverageFilmRating(Guid mediaId)
        {
            return 0;
        }

        public List<FilmViewModel> GetAllActiveFilms()
        {
            return FilmHausDbContext.Films.Where(x => x.ObsoletedOn != null).Select(x => new FilmViewModel(x)
            {
                Rating = GetAverageFilmRating(x.MediaId)
            })
            .ToList();
        }
    }
}