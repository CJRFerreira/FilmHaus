using FilmHaus.Models.View;
using System;

namespace FilmHaus.Services.Titles
{
    public interface ITitleService
    {
        void Create(CreateTitleViewModel tag);

        TitleViewModel Retrieve(Guid tagId);

        void Update(Guid tagId, EditTitleViewModel tag);

        void Delete(Guid tagId);
    }
}