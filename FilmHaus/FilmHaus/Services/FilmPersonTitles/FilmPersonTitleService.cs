using FilmHaus.Models;
using FilmHaus.Services.FilmPersonTitles;

namespace FilmHaus.Services.ReviewFilms
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