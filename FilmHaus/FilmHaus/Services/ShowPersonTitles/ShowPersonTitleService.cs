using FilmHaus.Models;

namespace FilmHaus.Services.ShowPersonTitles
{
    public class ShowPersonTitleService : IShowPersonTitleService
    {
        private FilmHausDbContext FilmHausDbContext { get; set; }

        public ShowPersonTitleService(FilmHausDbContext filmHausDbContext)
        {
            FilmHausDbContext = filmHausDbContext;
        }
    }
}