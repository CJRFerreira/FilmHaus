using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FilmHaus.Models;
using FilmHaus.Models.Base;
using FilmHaus.Models.View;
using FilmHaus.Models.Connector;
using static FilmHaus.Services.TagQueryExtensions;
using static FilmHaus.Services.FilmQueryExtensions;

/// <summary>
/// Name: Christian Ferreira
/// Date: September 6th - January 5th
///
/// Statement of Authorship:
/// I, Christian Ferreira (Student #: 000346210), certify that this material is my original work.
/// No other person's work has been used without due acknowledgement.
/// </summary>
namespace FilmHaus.Services.FilmTags
{
    /// <summary>
    /// Class implementation of the <see cref="IFilmTagService"/> Interface
    /// </summary>
    public class FilmTagService : IFilmTagService
    {
        /// <summary>
        /// Accessor to the <see cref="FilmHausDbContext"/>
        /// </summary>
        private FilmHausDbContext FilmHausDbContext { get; }

        /// <summary>
        /// Constructor for the <see cref="FilmTagService"/> class
        /// </summary>
        /// <param name="filmHausDbContext">Accessor for the Db, used for DI</param>
        public FilmTagService(FilmHausDbContext filmHausDbContext)
        {
            FilmHausDbContext = filmHausDbContext;
        }

        /// <summary>
        /// Gets all <see cref="Tag"/>s for a <see cref="Film"/>
        /// </summary>
        /// <param name="mediaId">Id of the <see cref="Film"/> used to enact the search</param>
        /// <returns><see cref="List<<see cref="TagViewModel"/>>"/> with all attached <see cref="Tag"/>s</returns>
        public List<TagViewModel> GetAllTagsForFilm(Guid mediaId)
        {
            return FilmHausDbContext.ShowTags.Where(st => st.MediaId == mediaId).Select(st => st.Tag).Select(GetTagViewModel()).ToList();
        }

        /// <summary>
        /// Gets all <see cref="Film"/>s for a <see cref="Tag"/>
        /// </summary>
        /// <param name="tagId">Id of the <see cref="Tag"/> used to enact the search</param>
        /// <returns><see cref="List<<see cref="FilmViewModel"/>>"/> with all attached <see cref="Film"/>s</returns>
        public List<FilmViewModel> GetAllFilmsWithTag(Guid tagId)
        {
            return FilmHausDbContext.FilmTags.Where(st => st.DetailId == tagId).Select(st => st.Film).Select(GetGeneralFilmViewModel()).ToList();
        }

        /// <summary>
        /// Associate a <see cref="Tag"/> with a <see cref="Film"/>
        /// </summary>
        /// <param name="tagId"><see cref="Tag"/> to use for association</param>
        /// <param name="mediaId"><see cref="Film"/> to use for association</param>
        public void AddTagToFilm(Guid tagId, Guid mediaId)
        {
            FilmHausDbContext.FilmTags.Add(new FilmTag
            {
                FilmTagId = Guid.NewGuid(),
                DetailId = tagId,
                MediaId = mediaId
            });
            FilmHausDbContext.SaveChanges();
        }

        /// <summary>
        /// Remove the association for a <see cref="Tag"/> and <see cref="Film"/>
        /// </summary>
        /// <param name="tagId"><see cref="Tag"/> to use for association removal</param>
        /// <param name="mediaId"><see cref="Film"/> to use for association removal</param>
        public void RemoveTagFromFilm(Guid tagId, Guid mediaId)
        {
            try
            {
                var result = FilmHausDbContext.FilmTags.Where(st => st.MediaId == mediaId && st.DetailId == tagId).FirstOrDefault();

                if (result != null)
                {
                    FilmHausDbContext.FilmTags.Remove(result);
                    FilmHausDbContext.SaveChanges();
                }
                else
                    throw new ArgumentNullException();
            }
            catch
            {
                throw;
            }
        }
    }
}