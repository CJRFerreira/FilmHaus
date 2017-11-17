using FilmHaus.Models;
using FilmHaus.Services.ShowGenres;
using FilmHaus.Services.FilmGenres;

namespace FilmHaus.Services.Genres
{
    public class GenreService : IGenreService
    {
        private FilmHausDbContext FilmHausDbContext { get; set; }

        private IFilmGenreService FilmGenreService { get; set; }

        private IShowGenreService ShowGenreService { get; set; }

        public GenreService(FilmHausDbContext filmHausDbContext, IFilmGenreService filmGenreService, IShowGenreService showGenreService)
        {
            FilmHausDbContext = filmHausDbContext;
            ShowGenreService = showGenreService;
            FilmGenreService = filmGenreService;
        }
    }
}