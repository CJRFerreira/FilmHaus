using FilmHaus.Models.Base;
using FilmHaus.Models.View;
using System;
using System.Linq.Expressions;

namespace FilmHaus.Services
{
    internal static class TagQueryExtensions
    {
        public static Expression<Func<Tag, TagViewModel>> GetTagViewModel()
        {
            return t => new TagViewModel()
            {
                DetailId = t.DetailId,
                Name = t.Name
            };
        }
    }
}