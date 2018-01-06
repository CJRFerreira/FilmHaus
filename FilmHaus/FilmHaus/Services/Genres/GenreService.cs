using FilmHaus.Models;
using FilmHaus.Services.ShowGenres;
using FilmHaus.Services.FilmGenres;
using FilmHaus.Models.View;
using FilmHaus.Models.Base;
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
namespace FilmHaus.Services.Genres
{
    public class GenreService : IGenreService
    {
        private FilmHausDbContext FilmHausDbContext { get; set; }

        public GenreService(FilmHausDbContext filmHausDbContext)
        {
            FilmHausDbContext = filmHausDbContext;
        }

        public void Create(CreateGenreViewModel genre)
        {
            FilmHausDbContext.Genres.Add(new Genre
            {
                DetailId = Guid.NewGuid(),
                Name = genre.Name,
                CreatedOn = DateTime.Now
            });
            FilmHausDbContext.SaveChanges();
        }

        public GenreViewModel Retrieve(Guid genreId)
        {
            var result = FilmHausDbContext.Genres.Find(genreId);

            if (result == null)
                throw new ArgumentNullException();

            return new GenreViewModel(result);
        }

        public void Update(Guid genreId, EditGenreViewModel genre)
        {
            try
            {
                var result = FilmHausDbContext.Genres.Find(genreId);

                if (result == null)
                    throw new ArgumentNullException();

                result.Name = genre.Name;

                FilmHausDbContext.Entry(result).State = EntityState.Modified;
                FilmHausDbContext.SaveChanges();
            }
            catch (InvalidOperationException ex)
            {
                throw ex;
            }
        }

        public void Delete(Guid genreId)
        {
            try
            {
                var result = FilmHausDbContext.Genres.Find(genreId);

                if (result != null)
                {
                    FilmHausDbContext.Genres.Remove(result);
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