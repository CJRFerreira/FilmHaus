using FilmHaus.Models;
using FilmHaus.Models.Base;
using FilmHaus.Models.Connector;
using FilmHaus.Models.View;
using LinqKit;
using System;
using System.Collections.Generic;
using System.Linq;
using static FilmHaus.Services.ShowQueryExtensions;
using static FilmHaus.Services.GenreQueryExtensions;

/// <summary>
/// Name: Christian Ferreira
/// Date: September 6th - January 5th
///
/// Statement of Authorship:
/// I, Christian Ferreira (Student #: 000346210), certify that this material is my original work.
/// No other person's work has been used without due acknowledgement.
/// </summary>
namespace FilmHaus.Services.ShowGenres
{
    /// <summary>
    /// Class implementation of the <see cref="IShowGenreService"/> Interface
    /// </summary>
    public class ShowGenreService : IShowGenreService
    {
        /// <summary>
        /// Accessor to the <see cref="FilmHausDbContext"/>
        /// </summary>
        private FilmHausDbContext FilmHausDbContext { get; }

        /// <summary>
        /// Constructor for the <see cref="ShowGenreService"/> class
        /// </summary>
        /// <param name="filmHausDbContext">Accessor for the Db, used for DI</param>
        public ShowGenreService(FilmHausDbContext filmHausDbContext)
        {
            FilmHausDbContext = filmHausDbContext;
        }

        /// <summary>
        /// Gets all <see cref="Genre"/>s for a <see cref="Show"/>
        /// </summary>
        /// <param name="mediaId">Id of the <see cref="Show"/> used to enact the search</param>
        /// <returns><see cref="List<<see cref="GenreViewModel"/>>"/> with all attached <see cref="Genre"/>s</returns>
        public List<GenreViewModel> GetAllGenresForShow(Guid mediaId)
        {
            return FilmHausDbContext.ShowGenres.AsExpandable().Where(fg => fg.MediaId == mediaId).Select(fg => fg.Genre).Select(GetGenreViewModel()).ToList();
        }

        /// <summary>
        /// Gets all <see cref="Show"/>s for a <see cref="Genre"/>
        /// </summary>
        /// <param name="genreId">Id of the <see cref="Genre"/> used to enact the search</param>
        /// <returns><see cref="List<<see cref="ShowViewModel"/>>"/> with all attached <see cref="Show"/>s</returns>
        public List<ShowViewModel> GetAllShowsForGenre(Guid genreId)
        {
            return FilmHausDbContext.ShowGenres.AsExpandable().Where(fg => fg.DetailId == genreId).Select(g => g.Show).Select(GetGeneralShowViewModel()).ToList();
        }

        /// <summary>
        /// Associate a <see cref="Genre"/> with a <see cref="Show"/>
        /// </summary>
        /// <param name="genreId"><see cref="Genre"/> to use for association</param>
        /// <param name="mediaId"><see cref="Show"/> to use for association</param>
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

        /// <summary>
        /// Remove the association for a <see cref="Genre"/> and <see cref="Show"/>
        /// </summary>
        /// <param name="genreId"><see cref="Genre"/> to use for association removal</param>
        /// <param name="mediaId"><see cref="Show"/> to use for association removal</param>
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