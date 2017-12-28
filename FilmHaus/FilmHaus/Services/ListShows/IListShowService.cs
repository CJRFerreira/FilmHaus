using FilmHaus.Models.View;
using System;
using System.Collections.Generic;

namespace FilmHaus.Services.ListShows
{
    public interface IListShowService
    {
        List<ShowViewModel> GetAllShowsByListId(Guid listId);

        void AddShowToList(Guid listId, Guid mediaId);

        void RemoveShowInList(Guid listShowId);

        void RemoveShowInList(Guid listId, Guid mediaId);

        void ObsoleteShowInList(Guid listShowId);

        void ObsoleteShowInList(Guid listId, Guid mediaId);
    }
}