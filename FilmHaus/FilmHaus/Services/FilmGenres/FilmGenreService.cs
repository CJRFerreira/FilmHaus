using FilmHaus.Models;
using FilmHaus.Models.Base;
using FilmHaus.Models.Connector;
using FilmHaus.Models.View;
using LinqKit;
using System;
using System.Collections.Generic;
using System.Linq;
using static FilmHaus.Services.FilmQueryExtensions;
using static FilmHaus.Services.GenreQueryExtensions;

namespace FilmHaus.Services.FilmGenres
{
    /// <summary>
    /// Class implementation of the <see cref="IFilmGenreService"/> Interface
    /// </summary>
    public class FilmGenreService : IFilmGenreService
    {
        /// <summary>
        /// Accessor to the <see cref="FilmHausDbContext"/>
        /// </summary>
        private FilmHausDbContext FilmHausDbContext { get; }

        /// <summary>
        /// Constructor for the <see cref="FilmGenreService"/> class
        /// </summary>
        /// <param name="filmHausDbContext">Accessor for the Db, used for DI</param>
        public FilmGenreService(FilmHausDbContext filmHausDbContext)
        {
            FilmHausDbContext = filmHausDbContext;
        }

        /// <summary>
        /// Gets all <see cref="Genre"/>s for a <see cref="Film"/>
        /// </summary>
        /// <param name="mediaId">Id of the <see cref="Film"/> used to enact the search</param>
        /// <returns><see cref="List<<see cref="GenreViewModel"/>>"/> with all attached <see cref="Genre"/>s</returns>
        public List<GenreViewModel> GetAllGenresForFilm(Guid mediaId)
        {
            return FilmHausDbContext.FilmGenres.AsExpandable().Where(fg => fg.MediaId == mediaId).Select(fg => fg.Genre).Select(GetGenreViewModel()).ToList();
        }

        /// <summary>
        /// Gets all <see cref="Film"/>s for a <see cref="Genre"/>
        /// </summary>
        /// <param name="genreId">Id of the <see cref="Genre"/> used to enact the search</param>
        /// <returns><see cref="List<<see cref="FilmViewModel"/>>"/> with all attached <see cref="Film"/>s</returns>
        public List<FilmViewModel> GetAllFilmsForGenre(Guid genreId)
        {
            return FilmHausDbContext.FilmGenres.AsExpandable().Where(fg => fg.DetailId == genreId).Select(g => g.Film).Select(GetGeneralFilmViewModel()).ToList();
        }

        /// <summary>
        /// Associate a <see cref="Genre"/> with a <see cref="Film"/>
        /// </summary>
        /// <param name="genreId"><see cref="Genre"/> to use for association</param>
        /// <param name="mediaId"><see cref="Film"/> to use for association</param>
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

        /// <summary>
        /// Remove the association for a <see cref="Genre"/> and <see cref="Film"/>
        /// </summary>
        /// <param name="genreId"><see cref="Genre"/> to use for association removal</param>
        /// <param name="mediaId"><see cref="Film"/> to use for association removal</param>
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