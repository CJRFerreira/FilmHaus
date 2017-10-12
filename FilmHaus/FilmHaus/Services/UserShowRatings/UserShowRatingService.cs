using FilmHaus.Models;

namespace FilmHaus.Services.UserShows
{
    public class UserShowRatingService : IUserShowRatingService
    {
        private FilmHausDbContext FilmHausDbContext { get; set; }

        public UserShowRatingService(FilmHausDbContext filmHausDbContext)
        {
            FilmHausDbContext = filmHausDbContext;
        }
    }
}