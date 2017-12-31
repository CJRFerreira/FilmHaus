using System;
using System.Collections.Generic;
using FilmHaus.Models;
using FilmHaus.Models.View;

namespace FilmHaus.Services.FilmPersonTitles
{
    public class FilmPersonTitleService : IFilmPersonTitleService
    {
        private FilmHausDbContext FilmHausDbContext { get; set; }

        public FilmPersonTitleService(FilmHausDbContext filmHausDbContext)
        {
            FilmHausDbContext = filmHausDbContext;
        }

        public List<PersonTitleViewModel> GetAllPersonsAndTitlesForFilm(Guid mediaId)
        {
            throw new NotImplementedException();
        }

        public List<FilmViewModel> GetAllFilmsForPerson(Guid personId)
        {
            throw new NotImplementedException();
        }

        public List<FilmViewModel> GetAllFilmsForPersonAsTitle(Guid personId, Guid titleId)
        {
            throw new NotImplementedException();
        }

        public List<FilmViewModel> GetAllTitlesForPerson(Guid personId)
        {
            throw new NotImplementedException();
        }

        public List<FilmViewModel> GetAllPeopleForTitle(Guid personId)
        {
            throw new NotImplementedException();
        }

        public void AddPersonAsTitleToFilm(Guid mediaId, Guid personId, Guid titleId)
        {
            throw new NotImplementedException();
        }

        public void RemovePersonAsTitleToFilm(Guid filmPersonTitleId)
        {
            throw new NotImplementedException();
        }

        public void RemovePersonAsTitleToFilm(Guid mediaId, Guid personId, Guid titleId)
        {
            throw new NotImplementedException();
        }
    }
}