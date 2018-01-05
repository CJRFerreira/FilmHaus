using System;
using System.Linq;
using System.Collections.Generic;
using FilmHaus.Models;
using FilmHaus.Models.Base;
using FilmHaus.Models.View;
using FilmHaus.Models.Connector;
using static FilmHaus.Services.ShowQueryExtensions;
using static FilmHaus.Services.PersonQueryExtensions;
using static FilmHaus.Services.TitleQueryExtensions;
using static FilmHaus.Services.PersonTitleQueryExtensions;

namespace FilmHaus.Services.ShowPersonTitles
{
    /// <summary>
    /// Class implementation of the <see cref="IShowPersonTitleService"/> Interface
    /// </summary>
    public class ShowPersonTitleService : IShowPersonTitleService
    {
        /// <summary>
        /// Accessor to the <see cref="FilmHausDbContext"/>
        /// </summary>
        private FilmHausDbContext FilmHausDbContext { get; set; }

        /// <summary>
        /// Constructor for the <see cref="ShowPersonTitleService"/> class
        /// </summary>
        /// <param name="filmHausDbContext">Accessor for the Db, used for DI</param>
        public ShowPersonTitleService(FilmHausDbContext filmHausDbContext)
        {
            FilmHausDbContext = filmHausDbContext;
        }

        /// <summary>
        /// Get all <see cref="Person"/>s and <see cref="Title"/>s for a given <see cref="Show"/>
        /// </summary>
        /// <param name="mediaId">Id of the <see cref="Show"/></param>
        /// <returns><see cref="List<<see cref="PersonTitleViewModel"/>>"/> with all <see cref="Person"/>s and their <see cref="Title"/>s</returns>
        public List<PersonTitleViewModel> GetAllPersonsAndTitlesForShow(Guid mediaId)
        {
            return FilmHausDbContext.ShowPersonTitles.Where(fpt => fpt.MediaId == mediaId).Select(GetPersonTitleViewModelForShow()).ToList();
        }

        /// <summary>
        /// Given a <see cref="Person"/>, return all <see cref="Show"/>s they have an association with
        /// </summary>
        /// <param name="personId">Id of the <see cref="Person"/></param>
        /// <returns><see cref="List<<see cref="ShowViewModel"/>>"/> with all <see cref="Show"/>s</returns>
        public List<ShowViewModel> GetAllShowsForPerson(Guid personId)
        {
            return FilmHausDbContext.ShowPersonTitles.Where(spt => spt.PersonId == personId).Select(spt => spt.Show).Select(GetGeneralShowViewModel()).ToList();
        }

        /// <summary>
        /// Given a <see cref="Person"/>, return all <see cref="Title"/>s they have an association with
        /// </summary>
        /// <param name="personId">Id of the <see cref="Person"/></param>
        /// <returns><see cref="List<<see cref="TitleViewModel"/>>"/> with all <see cref="Title"/>s</returns>
        public List<TitleViewModel> GetAllTitlesForPerson(Guid personId)
        {
            return FilmHausDbContext.ShowPersonTitles.Where(fpt => fpt.PersonId == personId).Select(fpt => fpt.Title).Select(GetTitleViewModel()).ToList();
        }

        /// <summary>
        /// Given a <see cref="Title"/>, return all <see cref="Person"/>s they have an association with
        /// </summary>
        /// <param name="titleId">Id of the <see cref="Title"/></param>
        /// <returns><see cref="List<<see cref="PersonViewModel"/>>"/> with all <see cref="Person"/>s</returns>
        public List<PersonViewModel> GetAllPeopleForTitle(Guid titleId)
        {
            return FilmHausDbContext.ShowPersonTitles.Where(fpt => fpt.DetailId == titleId).Select(fpt => fpt.Person).Select(GetPersonViewModel()).ToList();
        }

        /// <summary>
        /// Given a <see cref="Person"/> and <see cref="Title"/>, return all <see cref="Show"/>s they have an association with
        /// </summary>
        /// <param name="personId">Id of the <see cref="Person"/></param>
        /// <param name="titleId">Id of the <see cref="Title"/></param>
        /// <returns><see cref="List<<see cref="ShowViewModel"/>>"/> with all <see cref="Show"/>s</returns>
        public List<ShowViewModel> GetAllShowsForPersonAsTitle(Guid personId, Guid titleId)
        {
            return FilmHausDbContext.ShowPersonTitles.Where(spt => spt.PersonId == personId && spt.DetailId == titleId).Select(spt => spt.Show).Select(GetGeneralShowViewModel()).ToList();
        }

        /// <summary>
        /// Create an association between a <see cref="Person"/>, <see cref="Title"/>, and <see cref="Show"/>
        /// </summary>
        /// <param name="mediaId"><see cref="Show"/> the record is associated with</param>
        /// <param name="personId"><see cref="Person"/> the record is associated with</param>
        /// <param name="titleId"><see cref="Title"/> the record is associated with</param>
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

        /// <summary>
        /// Remove the association between a <see cref="Person"/>, <see cref="Title"/>, and <see cref="Show"/>
        /// </summary>
        /// <param name="mediaId"><see cref="Show"/> the record is associated with</param>
        /// <param name="personId"><see cref="Person"/> the record is associated with</param>
        /// <param name="titleId"><see cref="Title"/> the record is associated with</param>
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