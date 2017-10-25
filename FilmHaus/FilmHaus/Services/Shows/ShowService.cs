using FilmHaus.Models;
using FilmHaus.Models.Base;
using FilmHaus.Models.View;
using FilmHaus.Services.UserShowRatings;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

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

        public List<ShowViewModel> GetAllShows()
        {
            return FilmHausDbContext.Shows.Select(s => new ShowViewModel()
            {
                MediaId = s.MediaId,
                MediaName = s.MediaName,
                PosterUri = s.PosterUri,
                DateOfRelease = s.DateOfRelease,
                Accolades = s.Accolades,
                NumberOfSeasons = s.NumberOfSeasons,
                Rating = UserShowRatingService.GetAverageShowRating(s.MediaId)
            })
            .ToList();
        }

        public List<ShowViewModel> GetAllShowsForUser(string userId)
        {
            return FilmHausDbContext.UserShows.Where(u => u.Id == userId).Select(s => new ShowViewModel()
            {
                MediaId = s.Show.MediaId,
                MediaName = s.Show.MediaName,
                PosterUri = s.Show.PosterUri,
                DateOfRelease = s.Show.DateOfRelease,
                Accolades = s.Show.Accolades,
                NumberOfSeasons = s.Show.NumberOfSeasons,
                Rating = UserShowRatingService.GetAverageShowRating(s.MediaId)
            })
            .ToList();
        }

        public ShowViewModel GetShowByMediaId(Guid mediaId)
        {
            return FilmHausDbContext.Shows.Where(s => s.MediaId == mediaId).Select(s => new ShowViewModel()
            {
                MediaId = s.MediaId,
                MediaName = s.MediaName,
                PosterUri = s.PosterUri,
                DateOfRelease = s.DateOfRelease,
                Accolades = s.Accolades,
                NumberOfSeasons = s.NumberOfSeasons,
                Rating = UserShowRatingService.GetAverageShowRating(s.MediaId)
            })
            .FirstOrDefault();
        }

        public List<ShowViewModel> GetShowsByListId(Guid mediaId)
        {
            return FilmHausDbContext.ListShows.Where(l => l.ListId == mediaId).Select(s => new ShowViewModel()
            {
                MediaId = s.Show.MediaId,
                MediaName = s.Show.MediaName,
                PosterUri = s.Show.PosterUri,
                DateOfRelease = s.Show.DateOfRelease,
                Accolades = s.Show.Accolades,
                NumberOfSeasons = s.Show.NumberOfSeasons,
                Rating = UserShowRatingService.GetAverageShowRating(s.MediaId)
            })
            .ToList();
        }

        public List<ShowViewModel> GetShowsBySearchTerm(string searchTerm)
        {
            return FilmHausDbContext.Shows.Where(f => f.MediaName.Contains(searchTerm)).Select(s => new ShowViewModel()
            {
                MediaId = s.MediaId,
                MediaName = s.MediaName,
                PosterUri = s.PosterUri,
                DateOfRelease = s.DateOfRelease,
                Accolades = s.Accolades,
                NumberOfSeasons = s.NumberOfSeasons,
                Rating = UserShowRatingService.GetAverageShowRating(s.MediaId)
            })
            .ToList();
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

        public List<ShowViewModel> GetAllActiveShows()
        {
            return FilmHausDbContext.Shows.Where(x => x.ObsoletedOn != null).Select(f => new ShowViewModel()
            {
                MediaId = f.MediaId,
                MediaName = f.MediaName,
                PosterUri = f.PosterUri,
                DateOfRelease = f.DateOfRelease,
                Accolades = f.Accolades,
                NumberOfSeasons = f.NumberOfSeasons,
                Rating = UserShowRatingService.GetAverageShowRating(f.MediaId)
            })
            .ToList();
        }
    }
}