using FilmHaus.Models;

namespace FilmHaus.Services.Titles
{
    public class TitleService : ITitleService
    {
        private FilmHausDbContext FilmHausDbContext { get; set; }

        public TitleService(FilmHausDbContext filmHausDbContext)
        {
            FilmHausDbContext = filmHausDbContext;
        }
    }
}