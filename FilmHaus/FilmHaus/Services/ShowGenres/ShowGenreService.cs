using FilmHaus.Models;
using FilmHaus.Models.Connector;
using FilmHaus.Models.View;
using LinqKit;
using System;
using System.Collections.Generic;
using System.Linq;
using static FilmHaus.Services.ShowQueryExtensions;
using static FilmHaus.Services.GenreQueryExtensions;

namespace FilmHaus.Services.ShowGenres
{
    public class ShowGenreService : IShowGenreService
    {
        private FilmHausDbContext FilmHausDbContext { get; }

        public ShowGenreService(FilmHausDbContext filmHausDbContext)
        {
            FilmHausDbContext = filmHausDbContext;
        }

        public List<GenreViewModel> GetAllGenresForShow(Guid mediaId)
        {
            return FilmHausDbContext.ShowGenres.AsExpandable().Where(fg => fg.MediaId == mediaId).Select(fg => fg.Genre).Select(GetGenreViewModel()).ToList();
        }

        public List<GeneralShowViewModel> GetAllShowsForGenre(Guid genreId)
        {
            return FilmHausDbContext.ShowGenres.AsExpandable().Where(fg => fg.DetailId == genreId).Select(g => g.Show).Select(GetGeneralShowViewModel()).ToList();
        }

        public void AddGenreToShow(Guid genreId, Guid mediaId)
        {
            FilmHausDbContext.ShowGenres.Add(new ShowGenre
            {
                ShowGenreId = Guid.NewGuid(),
                MediaId = mediaId,
                DetailId = genreId
            });
            FilmHausDbContext.SaveChanges();
        }

        public void RemoveGenreFromShow(Guid showGenreId)
        {
            try
            {
                var showGenre = FilmHausDbContext.ShowGenres.Find(showGenreId);

                if (showGenre == null)
                    throw new KeyNotFoundException();

                FilmHausDbContext.ShowGenres.Remove(showGenre);
                FilmHausDbContext.SaveChanges();
            }
            catch (InvalidOperationException ex)
            {
                throw ex;
            }
        }

        public void RemoveGenreFromShow(Guid genreId, Guid mediaId)
        {
            try
            {
                var showGenre = FilmHausDbContext.ShowGenres.Where(fg => fg.DetailId == genreId && fg.MediaId == mediaId).FirstOrDefault();

                if (showGenre != null)
                    throw new KeyNotFoundException();

                FilmHausDbContext.ShowGenres.Remove(showGenre);
                FilmHausDbContext.SaveChanges();
            }
            catch (InvalidOperationException ex)
            {
                throw ex;
            }
        }
    }
}