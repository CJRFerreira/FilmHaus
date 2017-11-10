using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FilmHaus.Models.View;
using FilmHaus.Models;
using FilmHaus.Models.Base;
using FilmHaus.Models.Connector;
using System.Data.Entity;

namespace FilmHaus.Services.ListShows
{
    public class ListShowService : IListShowService
    {
        private FilmHausDbContext FilmHausDbContext { get; set; }

        public ListShowService(FilmHausDbContext filmHausDbContext)
        {
            FilmHausDbContext = filmHausDbContext;
        }

        public List<GeneralShowViewModel> GetAllShowsByListId(Guid listId)
        {
            throw new NotImplementedException();
        }

        public void CreateListShow(Guid listId, Guid mediaId)
        {
            throw new NotImplementedException();
        }

        public void DeleteListShow(Guid listShowId)
        {
            throw new NotImplementedException();
        }

        public void DeleteListShow(Guid listId, Guid mediaId)
        {
            throw new NotImplementedException();
        }

        public void ObsoleteListShow(Guid listShowId)
        {
            throw new NotImplementedException();
        }

        public void ObsoleteListShow(Guid listId, Guid mediaId)
        {
            throw new NotImplementedException();
        }
    }
}