using FilmHaus.Models.Base;
using System.Collections.Generic;

namespace FilmHaus.Services.Shows
{
    internal interface IShowService
    {
        Show GetShowByShowId(string id);

        ICollection<Show> GetAllShows();

        ICollection<Show> GetAllShowsForUser(string id);

        ICollection<Show> GetShowsBySearchTerm(string searchTerm);

        void CreateShow(Show Show);

        void DeleteShowByShowId(string id);

        void UpdateShowByShowId(string id);
    }
}