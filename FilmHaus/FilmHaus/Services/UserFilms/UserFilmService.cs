using FilmHaus.Models;

namespace FilmHaus.Services.UserFilms
{
    public class UserFilmService : IUserFilmService
    {
        private FilmHausDbContext FilmHausDbContext { get; set; }

        public UserFilmService(FilmHausDbContext filmHausDbContext)
        {
            FilmHausDbContext = filmHausDbContext;
        }
    }
}