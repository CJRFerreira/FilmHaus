using System;
using FilmHaus.Models;
using FilmHaus.Models.View;
using FilmHaus.Services.FilmTags;
using FilmHaus.Services.ShowTags;
using FilmHaus.Models.Base;
using System.Data.Entity;

namespace FilmHaus.Services.Tags
{
    public class TagService : ITagService
    {
        private FilmHausDbContext FilmHausDbContext { get; set; }

        public TagService(FilmHausDbContext filmHausDbContext)
        {
            FilmHausDbContext = filmHausDbContext;
        }

        public void Create(CreateTagViewModel tag)
        {
            FilmHausDbContext.Tags.Add(new Tag
            {
                DetailId = Guid.NewGuid(),
                Name = tag.Name,
                CreatedOn = DateTime.Now
            });
            FilmHausDbContext.SaveChanges();
        }

        public TagViewModel Retrieve(Guid tagId)
        {
            var result = FilmHausDbContext.Tags.Find(tagId);

            if (result == null)
                throw new ArgumentNullException();

            return new TagViewModel(result);
        }

        public void Update(Guid tagId, EditTagViewModel tag)
        {
            try
            {
                var result = FilmHausDbContext.Tags.Find(tagId);

                if (result == null)
                    throw new ArgumentNullException();

                result.Name = tag.Name;

                FilmHausDbContext.Entry(result).State = EntityState.Modified;
                FilmHausDbContext.SaveChanges();
            }
            catch (InvalidOperationException ex)
            {
                throw ex;
            }
        }

        public void Delete(Guid tagId)
        {
            try
            {
                var result = FilmHausDbContext.Tags.Find(tagId);

                if (result != null)
                {
                    FilmHausDbContext.Tags.Remove(result);
                    FilmHausDbContext.SaveChanges();
                }
                else
                    throw new ArgumentNullException();
            }
            catch (InvalidOperationException ex)
            {
                throw;
            }
        }
    }
}