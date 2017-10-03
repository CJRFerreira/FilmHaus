using FilmHaus.Models;

namespace FilmHaus.Services.UserShows
{
    public class UserShowService : IUserShowService
    {
        private FilmHausDbContext FilmHausDbContext { get; set; }

        public UserShowService(FilmHausDbContext filmHausDbContext)
        {
            FilmHausDbContext = filmHausDbContext;
        }
    }
}