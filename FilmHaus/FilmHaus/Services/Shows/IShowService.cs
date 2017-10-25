using FilmHaus.Models.View;
using System;
using System.Collections.Generic;

namespace FilmHaus.Services.Shows
{
    public interface IShowService
    {
        GeneralShowViewModel GetShowByMediaId(Guid mediaId);

        List<GeneralShowViewModel> GetAllShows();

        List<GeneralShowViewModel> GetAllActiveShows();

        List<GeneralShowViewModel> GetShowsBySearchTerm(string searchTerm);

        List<GeneralShowViewModel> GetShowsByListId(Guid mediaId);

        void CreateShow(CreateShowViewModel show);

        void DeleteShowByMediaId(Guid mediaId);

        void ObsoleteShowByMediaId(Guid mediaId);

        void UpdateShowByMediaId(Guid mediaId, EditShowViewModel show);
    }
}