using FilmHaus.Models;

namespace FilmHaus.Services.ShowGenres
{
    public class ShowGenreService : IShowGenreService
    {
        private FilmHausDbContext FilmHausDbContext { get; set; }

        public ShowGenreService(FilmHausDbContext filmHausDbContext)
        {
            FilmHausDbContext = filmHausDbContext;
        }
    }
}