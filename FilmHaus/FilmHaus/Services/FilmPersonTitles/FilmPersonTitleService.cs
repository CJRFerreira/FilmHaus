using FilmHaus.Models;

namespace FilmHaus.Services.FilmPersonTitles
{
    public class FilmPersonTitleService : IFilmPersonTitleService
    {
        private FilmHausDbContext FilmHausDbContext { get; set; }

        public FilmPersonTitleService(FilmHausDbContext filmHausDbContext)
        {
            FilmHausDbContext = filmHausDbContext;
        }
    }
}