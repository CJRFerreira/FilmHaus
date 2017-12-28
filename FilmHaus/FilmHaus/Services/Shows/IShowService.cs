using FilmHaus.Models.View;
using System;
using System.Collections.Generic;

namespace FilmHaus.Services.Shows
{
    public interface IShowService
    {
        ShowViewModel GetShowByMediaId(Guid mediaId);

        List<ShowViewModel> GetAllShows();

        List<ShowViewModel> GetShowsBySearchTerm(string searchTerm);

        List<ShowViewModel> GetShowsByListId(Guid mediaId);

        void CreateShow(CreateShowViewModel show);

        void DeleteShowByMediaId(Guid mediaId);

        void UpdateShowByMediaId(Guid mediaId, EditShowViewModel show);
    }
}