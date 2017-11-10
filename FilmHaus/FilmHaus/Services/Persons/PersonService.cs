using FilmHaus.Models;

namespace FilmHaus.Services.Persons
{
    public class PersonService : IPersonService
    {
        private FilmHausDbContext FilmHausDbContext { get; set; }

        public PersonService(FilmHausDbContext filmHausDbContext)
        {
            FilmHausDbContext = filmHausDbContext;
        }
    }
}