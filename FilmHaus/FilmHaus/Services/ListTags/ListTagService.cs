using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FilmHaus.Models;
using FilmHaus.Models.Base;
using FilmHaus.Models.View;
using FilmHaus.Models.Connector;
using static FilmHaus.Services.TagQueryExtensions;
using static FilmHaus.Services.ListQueryExtensions;

/// <summary>
/// Name: Christian Ferreira
/// Date: September 6th - January 5th
///
/// Statement of Authorship:
/// I, Christian Ferreira (Student #: 000346210), certify that this material is my original work.
/// No other person's work has been used without due acknowledgement.
/// </summary>
namespace FilmHaus.Services.ListTags
{
    /// <summary>
    /// Class implementation of the <see cref="IListTagService"/> Interface
    /// </summary>
    public class ListTagService : IListTagService
    {
        /// <summary>
        /// Accessor to the <see cref="FilmHausDbContext"/>
        /// </summary>
        private FilmHausDbContext FilmHausDbContext { get; }

        /// <summary>
        /// Constructor for the <see cref="ListTagService"/> class
        /// </summary>
        /// <param name="filmHausDbContext">Accessor for the Db, used for DI</param>
        public ListTagService(FilmHausDbContext filmHausDbContext)
        {
            FilmHausDbContext = filmHausDbContext;
        }

        /// <summary>
        /// Gets all <see cref="Tag"/>s for a <see cref="List"/>
        /// </summary>
        /// <param name="listId">Id of the <see cref="List"/> used to enact the search</param>
        /// <returns><see cref="List<<see cref="TagViewModel"/>>"/> with all attached <see cref="Tag"/>s</returns>
        public List<TagViewModel> GetAllTagsForList(Guid listId)
        {
            return FilmHausDbContext.ListTags.Where(st => st.ListId == listId).Select(st => st.Tag).Select(GetTagViewModel()).ToList();
        }

        /// <summary>
        /// Gets all <see cref="List"/>s for a <see cref="Tag"/>
        /// </summary>
        /// <param name="tagId">Id of the <see cref="Tag"/> used to enact the search</param>
        /// <returns><see cref="List<<see cref="ListViewModel"/>>"/> with all attached <see cref="List"/>s</returns>
        public List<ListViewModel> GetAllListsWithTag(Guid tagId)
        {
            return FilmHausDbContext.ListTags.Where(st => st.DetailId == tagId).Select(st => st.List).Select(GetListViewModel()).ToList();
        }

        /// <summary>
        /// Associate a <see cref="Tag"/> with a <see cref="List"/>
        /// </summary>
        /// <param name="tagId"><see cref="Tag"/> to use for association</param>
        /// <param name="listId"><see cref="List"/> to use for association</param>
        public void AddTagToList(Guid tagId, Guid listId)
        {
            FilmHausDbContext.ListTags.Add(new ListTag
            {
                ListTagId = Guid.NewGuid(),
                DetailId = tagId,
                ListId = listId
            });
            FilmHausDbContext.SaveChanges();
        }

        /// <summary>
        /// Remove the association for a <see cref="Tag"/> and <see cref="List"/>
        /// </summary>
        /// <param name="tagId"><see cref="Tag"/> to use for association removal</param>
        /// <param name="listId"><see cref="List"/> to use for association removal</param>
        public void RemoveTagFromList(Guid tagId, Guid listId)
        {
            try
            {
                var result = FilmHausDbContext.ListTags.Where(st => st.ListId == listId && st.DetailId == tagId).FirstOrDefault();

                if (result != null)
                {
                    FilmHausDbContext.ListTags.Remove(result);
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