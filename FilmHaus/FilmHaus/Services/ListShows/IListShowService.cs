using FilmHaus.Models.View;
using System;
using System.Collections.Generic;

namespace FilmHaus.Services.ListShows
{
    public interface IListShowService
    {
        List<ShowViewModel> GetAllShowsByListId(Guid listId);

        List<ListViewModel> GetAllListsWithShow(Guid mediaId);

        bool AddShowToList(Guid listId, Guid mediaId);

        bool RemoveShowInList(Guid listShowId);

        bool RemoveShowInList(Guid listId, Guid mediaId);

        bool ObsoleteShowInList(Guid listShowId);

        bool ObsoleteShowInList(Guid listId, Guid mediaId);
    }
}