using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FilmHaus.Models;
using FilmHaus.Models.Base;
using FilmHaus.Models.View;
using FilmHaus.Models.Connector;
using static FilmHaus.Services.TagQueryExtensions;
using static FilmHaus.Services.ShowQueryExtensions;

/// <summary>
/// Name: Christian Ferreira
/// Date: September 6th - January 5th
///
/// Statement of Authorship:
/// I, Christian Ferreira (Student #: 000346210), certify that this material is my original work.
/// No other person's work has been used without due acknowledgement.
/// </summary>
namespace FilmHaus.Services.ShowTags
{
    /// <summary>
    /// Class implementation of the <see cref="IShowTagService"/> Interface
    /// </summary>
    public class ShowTagService : IShowTagService
    {
        /// <summary>
        /// Accessor to the <see cref="FilmHausDbContext"/>
        /// </summary>
        private FilmHausDbContext FilmHausDbContext { get; }

        /// <summary>
        /// Constructor for the <see cref="ShowTagService"/> class
        /// </summary>
        /// <param name="filmHausDbContext">Accessor for the Db, used for DI</param>
        public ShowTagService(FilmHausDbContext filmHausDbContext)
        {
            FilmHausDbContext = filmHausDbContext;
        }

        /// <summary>
        /// Gets all <see cref="Tag"/>s for a <see cref="Show"/>
        /// </summary>
        /// <param name="mediaId">Id of the <see cref="Show"/> used to enact the search</param>
        /// <returns><see cref="List<<see cref="TagViewModel"/>>"/> with all attached <see cref="Tag"/>s</returns>
        public List<TagViewModel> GetAllTagsForShow(Guid mediaId)
        {
            return FilmHausDbContext.ShowTags.Where(st => st.MediaId == mediaId).Select(st => st.Tag).Select(GetTagViewModel()).ToList();
        }

        /// <summary>
        /// Gets all <see cref="Show"/>s for a <see cref="Tag"/>
        /// </summary>
        /// <param name="tagId">Id of the <see cref="Tag"/> used to enact the search</param>
        /// <returns><see cref="List<<see cref="ShowViewModel"/>>"/> with all attached <see cref="Show"/>s</returns>
        public List<ShowViewModel> GetAllShowsWithTag(Guid tagId)
        {
            return FilmHausDbContext.ShowTags.Where(st => st.DetailId == tagId).Select(st => st.Show).Select(GetGeneralShowViewModel()).ToList();
        }

        /// <summary>
        /// Associate a <see cref="Tag"/> with a <see cref="Show"/>
        /// </summary>
        /// <param name="tagId"><see cref="Tag"/> to use for association</param>
        /// <param name="mediaId"><see cref="Show"/> to use for association</param>
        public void AddTagToShow(Guid genreId, Guid mediaId)
        {
            FilmHausDbContext.ShowTags.Add(new ShowTag
            {
                ShowTagId = Guid.NewGuid(),
                DetailId = genreId,
                MediaId = mediaId
            });
            FilmHausDbContext.SaveChanges();
        }

        /// <summary>
        /// Remove the association for a <see cref="Tag"/> and <see cref="Show"/>
        /// </summary>
        /// <param name="tagId"><see cref="Tag"/> to use for association removal</param>
        /// <param name="mediaId"><see cref="Show"/> to use for association removal</param>
        public void RemoveTagFromShow(Guid tagId, Guid mediaId)
        {
            try
            {
                var result = FilmHausDbContext.ShowTags.Where(st => st.MediaId == mediaId && st.DetailId == tagId).FirstOrDefault();

                if (result != null)
                {
                    FilmHausDbContext.ShowTags.Remove(result);
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