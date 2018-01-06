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
    internal static class UserQueryExtensions
    {
        public static Expression<Func<User, UserViewModel>> GetUserViewModel()
        {
            return f => new UserViewModel()
            {
                Id = f.Id,
                FirstName = f.FirstName,
                LastName = f.LastName,
                Email = f.Email,
                PhoneNumber = f.PhoneNumber,
                CreatedOn = f.CreatedOn
            };
        }
    }
}