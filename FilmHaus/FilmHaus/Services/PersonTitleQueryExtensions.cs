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

/// <summary>
/// Name: Christian Ferreira
/// Date: September 6th - January 5th
///
/// Statement of Authorship:
/// I, Christian Ferreira (Student #: 000346210), certify that this material is my original work.
/// No other person's work has been used without due acknowledgement.
/// </summary>
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