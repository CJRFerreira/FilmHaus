using FilmHaus.Models.Base;
using FilmHaus.Models.Connector;
using FilmHaus.Models.View;
using LinqKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FilmHaus.Services
{
    internal static class PersonQueryExtensions
    {
        public static Expression<Func<Person, PersonViewModel>> GetUserFilmViewModel()
        {
            return f => new PersonViewModel()
            {
                PersonId = f.PersonId,
                FirstName = f.FirstName,
                LastName = f.LastName
            };
        }
    }
}