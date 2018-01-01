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