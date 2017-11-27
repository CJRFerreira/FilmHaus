using FilmHaus.Models;
using FilmHaus.Models.Connector;
using FilmHaus.Models.View;
using LinqKit;
using System;
using System.Collections.Generic;
using System.Linq;
using static FilmHaus.Services.FilmQueryExtensions;

namespace FilmHaus.Services.FilmGenres
{
    public class FilmGenreService : IFilmGenreService
    {
        private FilmHausDbContext FilmHausDbContext { get; set; }

        public FilmGenreService(FilmHausDbContext filmHausDbContext)
        {
            FilmHausDbContext = filmHausDbContext;
        }

        public List<GenreViewModel> GetAllGenresForFilm(Guid mediaId)
        {
            return FilmHausDbContext.FilmGenres.AsExpandable().Where(fg => fg.MediaId == mediaId).Select(fg => fg.Genre).Select(GetGenreViewModel()).ToList();
        }

        public List<GeneralFilmViewModel> GetAllFilmsForGenre(Guid genreId)
        {
            return FilmHausDbContext.FilmGenres.AsExpandable().Where(fg => fg.DetailId == genreId).Select(g => g.Film).Select(GetGeneralFilmViewModel()).ToList();
        }

        public void AddGenreToFilm(Guid genreId, Guid mediaId)
        {
            FilmHausDbContext.FilmGenres.Add(new FilmGenre
            {
                FilmGenreId = Guid.NewGuid(),
                MediaId = mediaId,
                DetailId = genreId
            });
            FilmHausDbContext.SaveChanges();
        }

        public void RemoveGenreFromFilm(Guid filmGenreId)
        {
            try
            {
                var filmGenre = FilmHausDbContext.FilmGenres.Find(filmGenreId);

                if (filmGenre == null)
                    throw new KeyNotFoundException();

                FilmHausDbContext.FilmGenres.Remove(filmGenre);
                FilmHausDbContext.SaveChanges();
            }
            catch (InvalidOperationException ex)
            {
                throw ex;
            }
        }

        public void RemoveGenreFromFilm(Guid genreId, Guid mediaId)
        {
            try
            {
                var filmGenre = FilmHausDbContext.FilmGenres.Where(fg => fg.DetailId == genreId && fg.MediaId == mediaId).FirstOrDefault();

                if (filmGenre != null)
                    throw new KeyNotFoundException();

                FilmHausDbContext.FilmGenres.Remove(filmGenre);
                FilmHausDbContext.SaveChanges();
            }
            catch (InvalidOperationException ex)
            {
                throw ex;
            }
        }
    }
}