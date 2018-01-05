using System;
using System.Linq;
using System.Collections.Generic;
using FilmHaus.Models;
using FilmHaus.Models.Base;
using FilmHaus.Models.Connector;
using FilmHaus.Models.View;
using static FilmHaus.Services.FilmQueryExtensions;
using static FilmHaus.Services.PersonQueryExtensions;
using static FilmHaus.Services.TitleQueryExtensions;
using static FilmHaus.Services.PersonTitleQueryExtensions;

namespace FilmHaus.Services.FilmPersonTitles
{
    /// <summary>
    /// Class implementation of the <see cref="IFilmPersonTitleService"/> Interface
    /// </summary>
    public class FilmPersonTitleService : IFilmPersonTitleService
    {
        /// <summary>
        /// Accessor to the <see cref="FilmHausDbContext"/>
        /// </summary>
        private FilmHausDbContext FilmHausDbContext { get; set; }

        /// <summary>
        /// Constructor for the <see cref="FilmPersonTitleService"/> class
        /// </summary>
        /// <param name="filmHausDbContext">Accessor for the Db, used for DI</param>
        public FilmPersonTitleService(FilmHausDbContext filmHausDbContext)
        {
            FilmHausDbContext = filmHausDbContext;
        }

        /// <summary>
        /// Get all <see cref="Person"/>s and <see cref="Title"/>s for a given <see cref="Film"/>
        /// </summary>
        /// <param name="mediaId">Id of the <see cref="Film"/></param>
        /// <returns><see cref="List<<see cref="PersonTitleViewModel"/>>"/> with all <see cref="Person"/>s and their <see cref="Title"/>s</returns>
        public List<PersonTitleViewModel> GetAllPersonsAndTitlesForFilm(Guid mediaId)
        {
            return FilmHausDbContext.FilmPersonTitles.Where(fpt => fpt.MediaId == mediaId).Select(GetPersonTitleViewModelForFilm()).ToList();
        }

        /// <summary>
        /// Given a <see cref="Person"/>, return all <see cref="Film"/>s they have an association with
        /// </summary>
        /// <param name="personId">Id of the <see cref="Person"/></param>
        /// <returns><see cref="List<<see cref="FilmViewModel"/>>"/> with all <see cref="Film"/>s</returns>
        public List<FilmViewModel> GetAllFilmsForPerson(Guid personId)
        {
            return FilmHausDbContext.FilmPersonTitles.Where(fpt => fpt.PersonId == personId).Select(fpt => fpt.Film).Select(GetGeneralFilmViewModel()).ToList();
        }

        /// <summary>
        /// Given a <see cref="Person"/> and <see cref="Title"/>, return all <see cref="Film"/>s they have an association with
        /// </summary>
        /// <param name="personId">Id of the <see cref="Person"/></param>
        /// <param name="titleId">Id of the <see cref="Title"/></param>
        /// <returns><see cref="List<<see cref="FilmViewModel"/>>"/> with all <see cref="Film"/>s</returns>
        public List<FilmViewModel> GetAllFilmsForPersonAsTitle(Guid personId, Guid titleId)
        {
            return FilmHausDbContext.FilmPersonTitles.Where(fpt => fpt.PersonId == personId && fpt.DetailId == titleId).Select(fpt => fpt.Film).Select(GetGeneralFilmViewModel()).ToList();
        }

        /// <summary>
        /// Given a <see cref="Person"/>, return all <see cref="Title"/>s they have an association with
        /// </summary>
        /// <param name="personId">Id of the <see cref="Person"/></param>
        /// <returns><see cref="List<<see cref="TitleViewModel"/>>"/> with all <see cref="Title"/>s</returns>
        public List<TitleViewModel> GetAllTitlesForPerson(Guid personId)
        {
            return FilmHausDbContext.FilmPersonTitles.Where(fpt => fpt.PersonId == personId).Select(fpt => fpt.Title).Select(GetTitleViewModel()).ToList();
        }

        /// <summary>
        /// Given a <see cref="Title"/>, return all <see cref="Person"/>s they have an association with
        /// </summary>
        /// <param name="titleId">Id of the <see cref="Title"/></param>
        /// <returns><see cref="List<<see cref="PersonViewModel"/>>"/> with all <see cref="Person"/>s</returns>
        public List<PersonViewModel> GetAllPeopleForTitle(Guid titleId)
        {
            return FilmHausDbContext.FilmPersonTitles.Where(fpt => fpt.DetailId == titleId).Select(fpt => fpt.Person).Select(GetPersonViewModel()).ToList();
        }

        /// <summary>
        /// Create an association between a <see cref="Person"/>, <see cref="Title"/>, and <see cref="Film"/>
        /// </summary>
        /// <param name="mediaId"><see cref="Film"/> the record is associated with</param>
        /// <param name="personId"><see cref="Person"/> the record is associated with</param>
        /// <param name="titleId"><see cref="Title"/> the record is associated with</param>
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

        /// <summary>
        /// Remove the association between a <see cref="Person"/>, <see cref="Title"/>, and <see cref="Film"/>
        /// </summary>
        /// <param name="mediaId"><see cref="Film"/> the record is associated with</param>
        /// <param name="personId"><see cref="Person"/> the record is associated with</param>
        /// <param name="titleId"><see cref="Title"/> the record is associated with</param>
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