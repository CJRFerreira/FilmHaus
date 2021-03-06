﻿using System;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;
using FilmHaus.Models;
using FilmHaus.Models.Base;
using FilmHaus.Models.View;
using FilmHaus.Services.ListShows;
using FilmHaus.Services.ListFilms;
using LinqKit;

/// <summary>
/// Name: Christian Ferreira
/// Date: September 6th - January 5th
///
/// Statement of Authorship:
/// I, Christian Ferreira (Student #: 000346210), certify that this material is my original work.
/// No other person's work has been used without due acknowledgement.
/// </summary>
namespace FilmHaus.Services.Lists
{
    public class ListService : IListService
    {
        private FilmHausDbContext FilmHausDbContext { get; }

        private IListFilmService ListFilmService { get; }

        private IListShowService ListShowService { get; }

        public ListService(FilmHausDbContext filmHausDbContext, IListFilmService listFilmService, IListShowService listShowService)
        {
            FilmHausDbContext = filmHausDbContext;
            ListShowService = listShowService;
            ListFilmService = listFilmService;
        }

        public void CreateList(CreateListViewModel list)
        {
            FilmHausDbContext.Lists.Add(new List
            {
                ListId = Guid.NewGuid(),
                Id = list.Id,
                CreatedOn = DateTime.Now,
                Title = list.Title,
                Description = list.Description,
                Shared = list.Shared
            });
            FilmHausDbContext.SaveChanges();
        }

        public void DeleteListByListId(Guid listId)
        {
            try
            {
                var result = FilmHausDbContext.Lists.Find(listId);
                if (result == null)
                    throw new KeyNotFoundException($"No entity found for key: {listId}");

                foreach (var lf in FilmHausDbContext.ListFilms.Where(rf => rf.ListId == result.ListId).Select(rf => rf).ToList())
                    FilmHausDbContext.ListFilms.Remove(lf);
                foreach (var ls in FilmHausDbContext.ListShows.Where(rs => rs.ListId == result.ListId).Select(rs => rs).ToList())
                    FilmHausDbContext.ListShows.Remove(ls);
                //foreach (var rs in FilmHausDbContext.ListSeasons.Where(rs => rs.ListId == review.ListId).Select(rs => rs).ToList())
                //    FilmHausDbContext.ListShows.Remove(rs);
                //foreach (var re in FilmHausDbContext.ListEpisodes.Where(re => re.ListId == review.ListId).Select(re => re).ToList())
                //    FilmHausDbContext.ListShows.Remove(re);

                FilmHausDbContext.SaveChanges();

                FilmHausDbContext.Lists.Remove(result);
                FilmHausDbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void UpdateListByListId(Guid listId, EditListViewModel list)
        {
            try
            {
                var result = FilmHausDbContext.Lists.Find(listId);

                if (result == null)
                    throw new KeyNotFoundException();

                result.Description = list.Description;
                result.Shared = list.Shared;

                FilmHausDbContext.Entry(result).State = EntityState.Modified;
                FilmHausDbContext.SaveChanges();
            }
            catch (InvalidOperationException ex)
            {
                throw ex;
            }
        }

        public ListViewModel GetListByListId(Guid listId)
        {
            var result = FilmHausDbContext.Lists.Find(listId);

            if (result == null)
                throw new KeyNotFoundException();

            return new ListViewModel(result);
        }

        public ListLibraryViewModel GetListWithMediaByListId(Guid listId)
        {
            return new ListLibraryViewModel
            {
                List = GetListByListId(listId),
                Films = ListFilmService.GetAllFilmsForList(listId),
                Shows = ListShowService.GetAllShowsByListId(listId)
            };
        }

        public List<ListViewModel> GetAllSharedLists()
        {
            return FilmHausDbContext.Lists
                .AsExpandable()
                .Where(l => l.Shared)
                .Select(ListQueryExtensions.GetListViewModel())
                .ToList();
        }

        public List<ListViewModel> GetAllLists()
        {
            return FilmHausDbContext.Lists
                .AsExpandable()
                .Select(ListQueryExtensions.GetListViewModel())
                .ToList();
        }

        public List<ListViewModel> GetAllListsByUserId(string userId)
        {
            return FilmHausDbContext.Lists
                .AsExpandable()
                .Where(l => l.Id == userId)
                .Select(ListQueryExtensions.GetListViewModel())
                .ToList();
        }
    }
}