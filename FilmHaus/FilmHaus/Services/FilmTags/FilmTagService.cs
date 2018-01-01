using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FilmHaus.Models.View;
using FilmHaus.Models;
using FilmHaus.Models.Base;
using FilmHaus.Models.Connector;
using static FilmHaus.Services.TagQueryExtensions;
using static FilmHaus.Services.FilmQueryExtensions;

namespace FilmHaus.Services.FilmTags
{
    public class FilmTagService : IFilmTagService
    {
        private FilmHausDbContext FilmHausDbContext { get; }

        public FilmTagService(FilmHausDbContext filmHausDbContext)
        {
            FilmHausDbContext = filmHausDbContext;
        }

        public List<TagViewModel> GetAllTagsForFilm(Guid mediaId)
        {
            return FilmHausDbContext.ShowTags.Where(st => st.MediaId == mediaId).Select(st => st.Tag).Select(GetTagViewModel()).ToList();
        }

        public List<FilmViewModel> GetAllFilmsWithTag(Guid tagId)
        {
            return FilmHausDbContext.FilmTags.Where(st => st.DetailId == tagId).Select(st => st.Film).Select(GetGeneralFilmViewModel()).ToList();
        }

        public void AddTagToFilm(Guid genreId, Guid mediaId)
        {
            FilmHausDbContext.FilmTags.Add(new FilmTag
            {
                FilmTagId = Guid.NewGuid(),
                DetailId = genreId,
                MediaId = mediaId
            });
            FilmHausDbContext.SaveChanges();
        }

        public void RemoveTagFromFilm(Guid filmTagId)
        {
            try
            {
                var result = FilmHausDbContext.FilmTags.Find(filmTagId);

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