using FilmHaus.Models.Base;
using FilmHaus.Models.View;
using System;
using System.Linq.Expressions;

namespace FilmHaus.Services
{
    internal static class TitleQueryExtensions
    {
        public static Expression<Func<Title, TitleViewModel>> GetTitleViewModel()
        {
            return t => new TitleViewModel()
            {
                DetailId = t.DetailId,
                Name = t.Name
            };
        }
    }
}