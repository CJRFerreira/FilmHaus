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
using static FilmHaus.Services.PersonQueryExtensions;
using static FilmHaus.Services.TitleQueryExtensions;

namespace FilmHaus.Services
{
    internal static class PersonTitleQueryExtensions
    {
        public static Expression<Func<FilmPersonTitle, PersonTitleViewModel>> GetPersonTitleViewModelForFilm()
        {
            var person = GetPersonViewModel();
            var title = GetTitleViewModel();

            return f => new PersonTitleViewModel()
            {
                Person = person.Invoke(f.Person),
                Title = title.Invoke(f.Title)
            };
        }

        public static Expression<Func<ShowPersonTitle, PersonTitleViewModel>> GetPersonTitleViewModelForShow()
        {
            var person = GetPersonViewModel();
            var title = GetTitleViewModel();

            return f => new PersonTitleViewModel()
            {
                Person = person.Invoke(f.Person),
                Title = title.Invoke(f.Title)
            };
        }
    }
}