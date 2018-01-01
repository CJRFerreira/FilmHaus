using FilmHaus.Models.Base;
using FilmHaus.Models.View;
using System;
using System.Linq.Expressions;

namespace FilmHaus.Services
{
    internal static class ListQueryExtensions
    {
        public static Expression<Func<List, ListViewModel>> GetListViewModel()
        {
            return l => new ListViewModel()
            {
                ListId = l.ListId,
                Id = l.Id,
                CreatedOn = l.CreatedOn,
                Title = l.Title,
                Description = l.Description,
                Shared = l.Shared
            };
        }
    }
}