using FilmHaus.Models.View;
using System;
using System.Collections.Generic;

namespace FilmHaus.Services.Shows
{
    public interface IShowService
    {
        ShowViewModel GetShowByMediaId(string userId, Guid mediaId);

        List<ShowViewModel> GetAllShows(string userId);

        List<ShowViewModel> GetShowsBySearchTerm(string userId, string searchTerm);

        void CreateShow(CreateShowViewModel show);

        void DeleteShowByMediaId(Guid mediaId);

        void UpdateShowByMediaId(Guid mediaId, EditShowViewModel show);
    }
}