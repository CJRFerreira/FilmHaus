using FilmHaus.Models;
using FilmHaus.Models.Base;
using FilmHaus.Models.View;
using System;
using System.Data.Entity;

/// <summary>
/// Name: Christian Ferreira
/// Date: September 6th - January 5th
///
/// Statement of Authorship:
/// I, Christian Ferreira (Student #: 000346210), certify that this material is my original work.
/// No other person's work has been used without due acknowledgement.
/// </summary>
namespace FilmHaus.Services.Titles
{
    public class TitleService : ITitleService
    {
        private FilmHausDbContext FilmHausDbContext { get; set; }

        public TitleService(FilmHausDbContext filmHausDbContext)
        {
            FilmHausDbContext = filmHausDbContext;
        }

        public void Create(CreateTitleViewModel title)
        {
            FilmHausDbContext.Titles.Add(new Title
            {
                DetailId = Guid.NewGuid(),
                Name = title.Name,
                CreatedOn = DateTime.Now
            });
            FilmHausDbContext.SaveChanges();
        }

        public TitleViewModel Retrieve(Guid titleId)
        {
            var result = FilmHausDbContext.Titles.Find(titleId);

            if (result == null)
                throw new ArgumentNullException();

            return new TitleViewModel(result);
        }

        public void Update(Guid titleId, EditTitleViewModel title)
        {
            try
            {
                var result = FilmHausDbContext.Titles.Find(titleId);

                if (result == null)
                    throw new ArgumentNullException();

                result.Name = title.Name;

                FilmHausDbContext.Entry(result).State = EntityState.Modified;
                FilmHausDbContext.SaveChanges();
            }
            catch (InvalidOperationException ex)
            {
                throw ex;
            }
        }

        public void Delete(Guid titleId)
        {
            try
            {
                var result = FilmHausDbContext.Titles.Find(titleId);

                if (result != null)
                {
                    FilmHausDbContext.Titles.Remove(result);
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