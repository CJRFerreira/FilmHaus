using FilmHaus.Models.Base;
using FilmHaus.Models.View;
using System.Collections.Generic;

namespace FilmHaus.Services.Shows
{
    public interface IShowService
    {
        ShowViewModel GetShowByMediaId(string id);

        List<ShowViewModel> GetAllShows();

        List<ShowViewModel> GetAllShowsForUser(string id);

        List<ShowViewModel> GetShowsBySearchTerm(string searchTerm);

        List<ShowViewModel> GetShowsByListId(string id);

        int GetAverageShowRating(string id);

        void CreateShow(CreateShowViewModel show);

        void DeleteShowByMediaId(string id);

        void UpdateShowByMediaId(string id, EditShowViewModel show);
    }
}