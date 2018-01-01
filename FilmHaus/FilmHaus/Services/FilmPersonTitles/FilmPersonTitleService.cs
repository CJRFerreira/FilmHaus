using System;
using System.Linq;
using System.Collections.Generic;
using FilmHaus.Models;
using FilmHaus.Models.Connector;
using FilmHaus.Models.View;
using static FilmHaus.Services.FilmQueryExtensions;
using static FilmHaus.Services.PersonQueryExtensions;
using static FilmHaus.Services.TitleQueryExtensions;
using static FilmHaus.Services.PersonTitleQueryExtensions;

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
            return FilmHausDbContext.FilmPersonTitles.Where(fpt => fpt.MediaId == mediaId).Select(GetPersonTitleViewModelForFilm()).ToList();
        }

        public List<FilmViewModel> GetAllFilmsForPerson(Guid personId)
        {
            return FilmHausDbContext.FilmPersonTitles.Where(fpt => fpt.PersonId == personId).Select(fpt => fpt.Film).Select(GetGeneralFilmViewModel()).ToList();
        }

        public List<FilmViewModel> GetAllFilmsForPersonAsTitle(Guid personId, Guid titleId)
        {
            return FilmHausDbContext.FilmPersonTitles.Where(fpt => fpt.PersonId == personId && fpt.DetailId == titleId).Select(fpt => fpt.Film).Select(GetGeneralFilmViewModel()).ToList();
        }

        public List<TitleViewModel> GetAllTitlesForPerson(Guid personId)
        {
            return FilmHausDbContext.FilmPersonTitles.Where(fpt => fpt.PersonId == personId).Select(fpt => fpt.Title).Select(GetTitleViewModel()).ToList();
        }

        public List<PersonViewModel> GetAllPeopleForTitle(Guid titleId)
        {
            return FilmHausDbContext.FilmPersonTitles.Where(fpt => fpt.DetailId == titleId).Select(fpt => fpt.Person).Select(GetPersonViewModel()).ToList();
        }

        public void AddPersonAsTitleToFilm(Guid mediaId, Guid personId, Guid titleId)
        {
            FilmHausDbContext.FilmPersonTitles.Add(new FilmPersonTitle
            {
                FilmPersonTitleId = Guid.NewGuid(),
                MediaId = mediaId,
                PersonId = personId,
                DetailId = titleId
            });
            FilmHausDbContext.SaveChanges();
        }

        public void RemovePersonAsTitleFromFilm(Guid filmPersonTitleId)
        {
            try
            {
                var result = FilmHausDbContext.FilmPersonTitles.Find(filmPersonTitleId);

                if (result != null)
                {
                    FilmHausDbContext.FilmPersonTitles.Remove(result);
                    FilmHausDbContext.SaveChanges();
                }
                else
                    throw new ArgumentNullException();
            }
            catch
            {
                throw;
            }
        }

        public void RemovePersonAsTitleFromFilm(Guid mediaId, Guid personId, Guid titleId)
        {
            try
            {
                var result = FilmHausDbContext.FilmPersonTitles.Where(fpt => fpt.MediaId == mediaId && fpt.PersonId == personId && fpt.DetailId == titleId).FirstOrDefault();

                if (result != null)
                {
                    FilmHausDbContext.FilmPersonTitles.Remove(result);
                    FilmHausDbContext.SaveChanges();
                }
                else
                    throw new ArgumentNullException();
            }
            catch
            {
                throw;
            }
        }
    }
}