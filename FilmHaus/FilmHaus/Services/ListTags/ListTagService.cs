using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FilmHaus.Models.View;
using FilmHaus.Models;
using FilmHaus.Models.Base;
using FilmHaus.Models.Connector;
using static FilmHaus.Services.TagQueryExtensions;
using static FilmHaus.Services.ListQueryExtensions;

namespace FilmHaus.Services.ListTags
{
    public class ListTagService : IListTagService
    {
        private FilmHausDbContext FilmHausDbContext { get; }

        public ListTagService(FilmHausDbContext filmHausDbContext)
        {
            FilmHausDbContext = filmHausDbContext;
        }

        public List<TagViewModel> GetAllTagsForList(Guid listId)
        {
            return FilmHausDbContext.ListTags.Where(st => st.ListId == listId).Select(st => st.Tag).Select(GetTagViewModel()).ToList();
        }

        public List<ListViewModel> GetAllListsWithTag(Guid tagId)
        {
            return FilmHausDbContext.ListTags.Where(st => st.DetailId == tagId).Select(st => st.List).Select(GetListViewModel()).ToList();
        }

        public void AddTagToList(Guid genreId, Guid listId)
        {
            FilmHausDbContext.ListTags.Add(new ListTag
            {
                ListTagId = Guid.NewGuid(),
                DetailId = genreId,
                ListId = listId
            });
            FilmHausDbContext.SaveChanges();
        }

        public void RemoveTagFromList(Guid listTagId)
        {
            try
            {
                var result = FilmHausDbContext.ListTags.Find(listTagId);

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