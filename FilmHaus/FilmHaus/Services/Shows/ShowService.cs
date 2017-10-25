using FilmHaus.Models;
using FilmHaus.Models.Base;
using FilmHaus.Models.View;
using FilmHaus.Services.UserShowRatings;
using LinqKit;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using static FilmHaus.Services.ShowQueryExtensions;

namespace FilmHaus.Services.Shows
{
    public class ShowService : IShowService
    {
        private FilmHausDbContext FilmHausDbContext { get; set; }

        protected IUserShowRatingService UserShowRatingService { get; set; }

        public ShowService(FilmHausDbContext filmHausDbContext, IUserShowRatingService userShowRatingService)
        {
            FilmHausDbContext = filmHausDbContext;
            UserShowRatingService = userShowRatingService;
        }

        public void CreateShow(CreateShowViewModel show)
        {
            FilmHausDbContext.Shows.Add(new Show
            {
                MediaId = Guid.NewGuid(),
                MediaName = show.MediaName,
                DateOfRelease = show.DateOfRelease,
                Accolades = show.Accolades,
                PosterUri = show.PosterUri,
                NumberOfSeasons = show.NumberOfSeasons,
                CreatedOn = DateTime.Now
            });
            FilmHausDbContext.SaveChanges();
        }

        public void DeleteShowByMediaId(Guid mediaId)
        {
            try
            {
                var show = FilmHausDbContext.Shows.Find(mediaId);

                if (show != null)
                {
                    FilmHausDbContext.Shows.Remove(show);
                    FilmHausDbContext.SaveChanges();
                }
                else
                    throw new ArgumentNullException();
            }
            catch (InvalidOperationException ex)
            {
                throw ex;
            }
        }

        public void ObsoleteShowByMediaId(Guid mediaId)
        {
            try
            {
                var result = FilmHausDbContext.Shows.Find(mediaId);

                if (result == null)
                    throw new ArgumentNullException();

                result.ObsoletedOn = DateTime.Now;

                FilmHausDbContext.Entry(result).State = EntityState.Modified;
                FilmHausDbContext.SaveChanges();
            }
            catch (InvalidOperationException ex)
            {
                throw ex;
            }
        }

        public List<GeneralShowViewModel> GetAllShows()
        {
            return FilmHausDbContext.Shows.AsExpandable().Select(GetGeneralShowViewModel()).ToList();
        }

        public GeneralShowViewModel GetShowByMediaId(Guid mediaId)
        {
            return FilmHausDbContext.Shows.AsExpandable().Where(f => f.MediaId == mediaId).Select(GetGeneralShowViewModel()).FirstOrDefault();
        }

        public List<GeneralShowViewModel> GetShowsByListId(Guid mediaId)
        {
            return FilmHausDbContext.ListShows.AsExpandable().Where(l => l.ListId == mediaId).Select(l => l.Show).Select(GetGeneralShowViewModel()).ToList();
        }

        public List<GeneralShowViewModel> GetShowsBySearchTerm(string searchTerm)
        {
            return FilmHausDbContext.Shows.Where(f => f.MediaName.Contains(searchTerm)).Select(GetGeneralShowViewModel()).ToList();
        }

        public void UpdateShowByMediaId(Guid mediaId, EditShowViewModel show)
        {
            try
            {
                var result = FilmHausDbContext.Shows.Find(mediaId);

                if (result == null)
                    throw new ArgumentNullException();

                result.PosterUri = show.PosterUri;
                result.MediaName = show.MediaName;
                result.DateOfRelease = show.DateOfRelease;
                result.Accolades = show.Accolades;
                result.NumberOfSeasons = show.NumberOfSeasons;

                FilmHausDbContext.Entry(result).State = EntityState.Modified;
                FilmHausDbContext.SaveChanges();
            }
            catch (InvalidOperationException ex)
            {
                throw ex;
            }
        }

        public List<GeneralShowViewModel> GetAllActiveShows()
        {
            return FilmHausDbContext.Shows.Where(f => f.ObsoletedOn != null).Select(GetGeneralShowViewModel()).ToList();
        }
    }
}