using FilmHaus.Models;

namespace FilmHaus.Services.FilmGenres
{
    public class FilmGenreService : IFilmGenreService
    {
        private FilmHausDbContext FilmHausDbContext { get; set; }

        public FilmGenreService(FilmHausDbContext filmHausDbContext)
        {
            FilmHausDbContext = filmHausDbContext;
        }
    }
}