using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FilmHaus.Models.View;
using FilmHaus.Models;
using FilmHaus.Models.Connector;
using static FilmHaus.Services.TagQueryExtensions;
using static FilmHaus.Services.ShowQueryExtensions;

namespace FilmHaus.Services.ShowTags
{
    public class ShowTagService : IShowTagService
    {
        private FilmHausDbContext FilmHausDbContext { get; }

        public ShowTagService(FilmHausDbContext filmHausDbContext)
        {
            FilmHausDbContext = filmHausDbContext;
        }

        public List<TagViewModel> GetAllTagsForShow(Guid mediaId)
        {
            return FilmHausDbContext.ShowTags.Where(st => st.MediaId == mediaId).Select(st => st.Tag).Select(GetTagViewModel()).ToList();
        }

        public List<ShowViewModel> GetAllShowsWithTag(Guid tagId)
        {
            return FilmHausDbContext.ShowTags.Where(st => st.DetailId == tagId).Select(st => st.Show).Select(GetGeneralShowViewModel()).ToList();
        }

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

        public void RemoveTagFromShow(Guid showTagId)
        {
            try
            {
                var result = FilmHausDbContext.ShowTags.Find(showTagId);

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