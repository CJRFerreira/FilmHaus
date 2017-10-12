using FilmHaus.Models;
using FilmHaus.Models.Base;
using FilmHaus.Models.View;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace FilmHaus.Services.Shows
{
    public class ShowService : IShowService
    {
        private FilmHausDbContext FilmHausDbContext { get; set; }

        public ShowService(FilmHausDbContext filmHausDbContext)
        {
            FilmHausDbContext = filmHausDbContext;
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
            var show = FilmHausDbContext.Shows.Find(mediaId);

            if (show != null)
            {
                FilmHausDbContext.Shows.Remove(show);
                FilmHausDbContext.SaveChanges();
            }
            else
                throw new ArgumentNullException();
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
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ShowViewModel> GetAllShows()
        {
            return FilmHausDbContext.Shows.Select(x => new ShowViewModel(x)
            {
                Rating = GetAverageShowRating(x.MediaId)
            })
            .ToList();
        }

        public List<ShowViewModel> GetAllShowsForUser(string userId)
        {
            return FilmHausDbContext.UserShows.Where(u => u.Id == userId).Select(x => new ShowViewModel(x.Show)
            {
                Rating = GetAverageShowRating(x.MediaId)
            })
            .ToList();
        }

        public ShowViewModel GetShowByMediaId(Guid mediaId)
        {
            return FilmHausDbContext.Shows.Where(s => s.MediaId == mediaId).Select(s => new ShowViewModel(s)
            {
                Rating = GetAverageShowRating(s.MediaId)
            })
            .FirstOrDefault();
        }

        public List<ShowViewModel> GetShowsByListId(Guid mediaId)
        {
            return FilmHausDbContext.ListShows.Where(l => l.ListId == mediaId).Select(s => new ShowViewModel(s.Show)).ToList();
        }

        public List<ShowViewModel> GetShowsBySearchTerm(string searchTerm)
        {
            return FilmHausDbContext.Shows.Where(s => s.MediaName.Contains(searchTerm)).Select(s => new ShowViewModel(s)).ToList();
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
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int GetAverageShowRating(Guid mediaId)
        {
            return 0;
        }

        public List<ShowViewModel> GetAllActiveShows()
        {
            return FilmHausDbContext.Shows.Where(x => x.ObsoletedOn != null).Select(x => new ShowViewModel(x)
            {
                Rating = GetAverageShowRating(x.MediaId)
            })
            .ToList();
        }
    }
}