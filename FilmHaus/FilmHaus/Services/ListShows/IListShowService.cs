using FilmHaus.Models.View;
using System;
using System.Collections.Generic;

namespace FilmHaus.Services.ListShows
{
    public interface IListShowService
    {
        List<GeneralShowViewModel> GetAllShowsByListId(Guid listId);

        void CreateListShow(Guid listId, Guid mediaId);

        void DeleteListShow(Guid listShowId);

        void DeleteListShow(Guid listId, Guid mediaId);

        void ObsoleteListShow(Guid listShowId);

        void ObsoleteListShow(Guid listId, Guid mediaId);
    }
}