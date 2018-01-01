using System;
using System.Linq;
using System.Collections.Generic;
using FilmHaus.Models;
using FilmHaus.Models.Connector;
using FilmHaus.Models.View;
using static FilmHaus.Services.ShowQueryExtensions;
using static FilmHaus.Services.PersonQueryExtensions;
using static FilmHaus.Services.TitleQueryExtensions;
using static FilmHaus.Services.PersonTitleQueryExtensions;

namespace FilmHaus.Services.ShowPersonTitles
{
    public class ShowPersonTitleService : IShowPersonTitleService
    {
        private FilmHausDbContext FilmHausDbContext { get; set; }

        public ShowPersonTitleService(FilmHausDbContext filmHausDbContext)
        {
            FilmHausDbContext = filmHausDbContext;
        }

        public List<PersonTitleViewModel> GetAllPersonsAndTitlesForShow(Guid mediaId)
        {
            return FilmHausDbContext.ShowPersonTitles.Where(fpt => fpt.MediaId == mediaId).Select(GetPersonTitleViewModelForShow()).ToList();
        }

        public List<ShowViewModel> GetAllShowsForPerson(Guid personId)
        {
            return FilmHausDbContext.ShowPersonTitles.Where(spt => spt.PersonId == personId).Select(spt => spt.Show).Select(GetGeneralShowViewModel()).ToList();
        }

        public List<TitleViewModel> GetAllTitlesForPerson(Guid personId)
        {
            return FilmHausDbContext.ShowPersonTitles.Where(fpt => fpt.PersonId == personId).Select(fpt => fpt.Title).Select(GetTitleViewModel()).ToList();
        }

        public List<PersonViewModel> GetAllPeopleForTitle(Guid titleId)
        {
            return FilmHausDbContext.ShowPersonTitles.Where(fpt => fpt.DetailId == titleId).Select(fpt => fpt.Person).Select(GetPersonViewModel()).ToList();
        }

        public List<ShowViewModel> GetAllShowsForPersonAsTitle(Guid personId, Guid titleId)
        {
            return FilmHausDbContext.ShowPersonTitles.Where(spt => spt.PersonId == personId && spt.DetailId == titleId).Select(spt => spt.Show).Select(GetGeneralShowViewModel()).ToList();
        }

        public void AddPersonAsTitleToShow(Guid mediaId, Guid personId, Guid titleId)
        {
            FilmHausDbContext.ShowPersonTitles.Add(new ShowPersonTitle
            {
                ShowPersonTitleId = Guid.NewGuid(),
                MediaId = mediaId,
                PersonId = personId,
                DetailId = titleId
            });
            FilmHausDbContext.SaveChanges();
        }

        public void RemovePersonAsTitleFromShow(Guid showPersonTitleId)
        {
            try
            {
                var result = FilmHausDbContext.ShowPersonTitles.Find(showPersonTitleId);

                if (result != null)
                {
                    FilmHausDbContext.ShowPersonTitles.Remove(result);
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

        public void RemovePersonAsTitleFromShow(Guid mediaId, Guid personId, Guid titleId)
        {
            try
            {
                var result = FilmHausDbContext.ShowPersonTitles.Where(fpt => fpt.MediaId == mediaId && fpt.PersonId == personId && fpt.DetailId == titleId).FirstOrDefault();

                if (result != null)
                {
                    FilmHausDbContext.ShowPersonTitles.Remove(result);
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