using FilmHaus.Models.Base;
using FilmHaus.Models.View;
using System;
using System.Linq.Expressions;

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