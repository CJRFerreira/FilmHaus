using FilmHaus.Models.Base;
using FilmHaus.Models.View;
using System.Collections.Generic;

namespace FilmHaus.Services.Shows
{
    public interface IShowService
    {
        ShowViewModel GetShowByShowId(string id);

        List<ShowViewModel> GetAllShows();

        List<ShowViewModel> GetAllShowsForUser(string id);

        List<ShowViewModel> GetShowsBySearchTerm(string searchTerm);

        List<ShowViewModel> GetShowsByListId(string id);

        int GetAverageShowRating(string id);

        void CreateShow(CreateShowViewModel show);

        void DeleteShowByShowId(string id);

        void UpdateShowByShowId(string id, EditShowViewModel show);
    }
}