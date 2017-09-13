using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FilmHaus.Models.Base;
using FilmHaus.Models.View;
using FilmHaus.Models;

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
                FilmId = Guid.NewGuid(),
                FilmName = film.FilmName,
                DateOfRelease = film.DateOfRelease,
                Accolades = film.Accolades,
                PosterUri = film.PosterUri,
                Runtime = film.Runtime
            });
            FilmHausDbContext.SaveChanges();
        }

        public void DeleteFilmByFilmId(string id)
        {
            throw new NotImplementedException();
        }

        public List<FilmViewModel> GetAllFilms()
        {
            return FilmHausDbContext.Films.Select(x => new FilmViewModel(x)).ToList();
        }

        public List<FilmViewModel> GetAllFilmsForUser(string id)
        {
            return FilmHausDbContext.UserFilms.Where(u => u.Id == id).Select(x => new FilmViewModel(x.Film)
            {
                Rating = x.Rating
            })
            .ToList();
        }

        public FilmViewModel GetFilmByFilmId(string id)
        {
            return FilmHausDbContext.Films.Where(f => f.FilmId.ToString() == id).Select(f => new FilmViewModel(f)).FirstOrDefault();
        }

        public List<FilmViewModel> GetFilmsByListId(string id)
        {
            return FilmHausDbContext.ListFilms.Where(l => l.ListId.ToString() == id).Select(f => new FilmViewModel(f.Film)).ToList();
        }

        public List<FilmViewModel> GetFilmsBySearchTerm(string searchTerm)
        {
            return FilmHausDbContext.Films.Where(f => f.FilmName.Contains(searchTerm)).Select(f => new FilmViewModel(f)).ToList();
        }

        public void UpdateFilmByFilmId(string id, EditFilmViewModel film)
        {
            throw new NotImplementedException();
        }

        public int GetAverageFilmRating(string id)
        {
            int filmRating = 0;
            var allRatings = FilmHausDbContext.UserFilms.Where(f => f.FilmId.ToString() == id && f.Rating != null).Select(r => r.Rating).ToList();

            foreach (var rating in allRatings)
            {
                filmRating += (int)rating;
            }

            return (filmRating / allRatings.Count);
        }
    }
}