using System;
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

        public void AddShowToUserLibrary(Guid mediaId, string userId)
        {
            throw new NotImplementedException();
        }

        public void RemoveShowFromUserLibrary(Guid userShowId)
        {
            throw new NotImplementedException();
        }
    }
}