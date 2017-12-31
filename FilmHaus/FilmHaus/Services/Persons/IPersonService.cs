using FilmHaus.Models.Base;
using FilmHaus.Models.View;
using System;
using System.Collections.Generic;

namespace FilmHaus.Services.Persons
{
    public interface IPersonService
    {
        void Create(CreatePersonViewModel person);

        PersonTitleViewModel Retrieve(Guid personId);

        void Update(Guid personId, EditPersonViewModel person);

        void Delete(Guid personId);
    }
}