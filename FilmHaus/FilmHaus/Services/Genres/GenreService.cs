using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using FilmHaus.Enums;
using FilmHaus.Models;
using FilmHaus.Models.View;
using FilmHaus.Models.Base;
using FilmHaus.Models.Connector;
using FilmHaus.Services.ReviewFilms;
using FilmHaus.Services.ReviewShows;
using LinqKit;
using static FilmHaus.Services.ReviewQueryExtensions;
using FilmHaus.Exceptions;
using FilmHaus.Services.ShowGenres;
using FilmHaus.Services.FilmGenres;

namespace FilmHaus.Services.Genres
{
    public class GenreService : IGenreService
    {
        private FilmHausDbContext FilmHausDbContext { get; set; }

        private IFilmGenreService FilmGenreService { get; set; }

        private IShowGenreService ShowGenreService { get; set; }

        public GenreService(FilmHausDbContext filmHausDbContext, IFilmGenreService filmGenreService, IShowGenreService showGenreService)
        {
            FilmHausDbContext = filmHausDbContext;
            ShowGenreService = showGenreService;
            FilmGenreService = filmGenreService;
        }
    }
}