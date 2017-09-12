using FilmHaus.Models.Base;
using FilmHaus.Models.View;
using System.Collections.Generic;

namespace FilmHaus.Services.Shows
{
    internal interface IShowService
    {
        Show GetShowByShowId(string id);

        List<Show> GetAllShows();

        List<Show> GetAllShowsForUser(string id);

        List<Show> GetShowsBySearchTerm(string searchTerm);

        List<Show> GetShowsByListId(string id);

        int GetAverageShowRating(string id);

        void CreateShow(CreateShowViewModel show);

        void DeleteShowByShowId(string id);

        void UpdateShowByShowId(string id, EditShowViewModel show);
    }
}