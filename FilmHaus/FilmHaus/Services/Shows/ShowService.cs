using FilmHaus.Models;
using FilmHaus.Models.Base;
using FilmHaus.Models.View;
using FilmHaus.Services.UserShowRatings;
using FilmHaus.Services.UserShows;
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
        private FilmHausDbContext FilmHausDbContext { get; }

        private IUserShowService UserShowService { get; }

        private IUserShowRatingService UserShowRatingService { get; }

        public ShowService(FilmHausDbContext filmHausDbContext, IUserShowService userShowService, IUserShowRatingService userShowRatingService)
        {
            FilmHausDbContext = filmHausDbContext;
            UserShowService = userShowService;
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

                if (show == null)
                    throw new ArgumentNullException();

                FilmHausDbContext.Shows.Remove(show);
                FilmHausDbContext.SaveChanges();
            }
            catch 
            {
                throw;
            }
        }

        public List<ShowViewModel> GetAllShows(string userId)
        {
            var shows = new List<ShowViewModel>();

            var userShow = GetUserShowViewModel();
            var generalShow = GetGeneralShowViewModel();

            foreach (var show in FilmHausDbContext.Shows.ToList())
            {
                var result = new ShowViewModel();

                if (UserShowRatingService.DoesUserHaveRating(userId, show.MediaId))
                {
                    result = userShow.Invoke(show.UserShows
                             .Where(uf => uf.Id == userId && uf.MediaId == show.MediaId)
                             .FirstOrDefault()
                             );
                }
                else
                {
                    result = generalShow.Invoke(show);
                    result.InCurrentUserLibrary = UserShowService.IsShowInLibrary(show.MediaId, userId);
                }

                shows.Add(result);
            }

            return shows;
        }

        public ShowViewModel GetShowByMediaId(string userId, Guid mediaId)
        {
            var show = FilmHausDbContext.Shows.AsExpandable().Where(f => f.MediaId == mediaId).FirstOrDefault();

            var userShow = GetUserShowViewModel();
            var generalShow = GetGeneralShowViewModel();

            if (UserShowRatingService.DoesUserHaveRating(userId, show.MediaId))
            {
                return userShow.Invoke(show.UserShows
                         .Where(uf => uf.Id == userId && uf.MediaId == show.MediaId)
                         .FirstOrDefault()
                         );
            }
            else
            {
                var result = generalShow.Invoke(show);
                result.InCurrentUserLibrary = UserShowService.IsShowInLibrary(mediaId, userId);

                return result;
            }
        }


        public List<ShowViewModel> GetShowsBySearchTerm(string userId, string searchTerm)
        {
            var shows = new List<ShowViewModel>();

            var userShow = GetUserShowViewModel();
            var generalShow = GetGeneralShowViewModel();

            foreach (var show in FilmHausDbContext.Shows.Where(f => f.MediaName.Contains(searchTerm)).ToList())
            {
                var result = new ShowViewModel();

                if (UserShowRatingService.DoesUserHaveRating(userId, show.MediaId))
                {
                    result = userShow.Invoke(show.UserShows
                             .Where(uf => uf.Id == userId && uf.MediaId == show.MediaId)
                             .FirstOrDefault()
                             );
                }
                else
                {
                    result = generalShow.Invoke(show);
                    result.InCurrentUserLibrary = UserShowService.IsShowInLibrary(show.MediaId, userId);
                }

                shows.Add(result);
            }

            return shows;
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
            catch
            {
                throw;
            }
        }
    }
}