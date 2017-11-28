using FilmHaus.Models.Base;
using FilmHaus.Models.View;
using System;
using System.Linq.Expressions;

namespace FilmHaus.Services
{
    internal static class GenreQueryExtensions
    {
        public static Expression<Func<Genre, GenreViewModel>> GetGenreViewModel()
        {
            return g => new GenreViewModel()
            {
                DetailId = g.DetailId,
                Name = g.Name
            };
        }
    }
}