﻿using System;
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

        public void DeleteFilmByFilmId(Guid id)
        {
            var film = FilmHausDbContext.Films.Find(id);

            if (film != null)
            {
                FilmHausDbContext.Films.Remove(film);
                FilmHausDbContext.SaveChanges();
            }
            else
                throw new NullReferenceException();
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

        public FilmViewModel GetFilmByFilmId(Guid filmId, string userId)
        {
            var result = FilmHausDbContext.UserFilms.Find(userId, filmId);

            if (result != null)
                return FilmHausDbContext.Films.Where(f => f.FilmId == filmId).Select(f => new FilmViewModel(f)
                {
                    Rating = result.Rating
                })
                .FirstOrDefault();

            return FilmHausDbContext.Films.Where(f => f.FilmId == filmId).Select(f => new FilmViewModel(f)
            {
                Rating = GetAverageFilmRating(filmId)
            })
            .FirstOrDefault();
        }

        public List<FilmViewModel> GetFilmsByListId(Guid id)
        {
            return FilmHausDbContext.ListFilms.Where(l => l.ListId == id).Select(f => new FilmViewModel(f.Film)).ToList();
        }

        public List<FilmViewModel> GetFilmsBySearchTerm(string searchTerm)
        {
            return FilmHausDbContext.Films.Where(f => f.FilmName.Contains(searchTerm)).Select(f => new FilmViewModel(f)).ToList();
        }

        public void UpdateFilmByFilmId(Guid id, EditFilmViewModel film)
        {
            var result = FilmHausDbContext.Films.Find(id);
            if (result != null)
            {
                FilmHausDbContext.Entry(result).CurrentValues.SetValues(film);
                FilmHausDbContext.SaveChanges();
            }
            else
                throw new NullReferenceException();
        }

        public int GetAverageFilmRating(Guid filmId)
        {
            int filmRating = 0;
            var allRatings = FilmHausDbContext.UserFilms.Where(f => f.FilmId == filmId && f.Rating != null).Select(r => r.Rating).ToList();

            foreach (var rating in allRatings)
                if (rating != null)
                    filmRating += (int)rating;

            return (filmRating / allRatings.Count);
        }
    }
}