using System;
using FilmHaus.Models;
using FilmHaus.Models.View;
using FilmHaus.Models.Base;
using System.Data.Entity;

/// <summary>
/// Name: Christian Ferreira
/// Date: September 6th - January 5th
///
/// Statement of Authorship:
/// I, Christian Ferreira (Student #: 000346210), certify that this material is my original work.
/// No other person's work has been used without due acknowledgement.
/// </summary>
namespace FilmHaus.Services.Persons
{
    public class PersonService : IPersonService
    {
        private FilmHausDbContext FilmHausDbContext { get; set; }

        public PersonService(FilmHausDbContext filmHausDbContext)
        {
            FilmHausDbContext = filmHausDbContext;
        }

        public void Create(CreatePersonViewModel person)
        {
            FilmHausDbContext.People.Add(new Person
            {
                PersonId = Guid.NewGuid(),
                FirstName = person.FirstName,
                LastName = person.LastName,
                CreatedOn = DateTime.Now
            });
            FilmHausDbContext.SaveChanges();
        }

        public PersonViewModel Retrieve(Guid personId)
        {
            var result = FilmHausDbContext.People.Find(personId);

            if (result == null)
                throw new ArgumentNullException();

            return new PersonViewModel(result);
        }

        public void Update(Guid personId, EditPersonViewModel person)
        {
            try
            {
                var result = FilmHausDbContext.People.Find(personId);

                if (result == null)
                    throw new ArgumentNullException();

                result.FirstName = person.FirstName;
                result.LastName = person.LastName;

                FilmHausDbContext.Entry(result).State = EntityState.Modified;
                FilmHausDbContext.SaveChanges();
            }
            catch (InvalidOperationException ex)
            {
                throw ex;
            }
        }

        public void Delete(Guid personId)
        {
            try
            {
                var result = FilmHausDbContext.People.Find(personId);

                if (result != null)
                {
                    FilmHausDbContext.People.Remove(result);
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