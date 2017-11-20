using FilmHaus.Models.Base;
using FilmHaus.Models.View;
using System;
using System.Collections.Generic;

namespace FilmHaus.Services.Tags
{
    public interface ITagService
    {
        void Create(CreateTagViewModel tag);

        TagViewModel Retrieve(Guid tagId);

        void Update(Guid tagId, EditTagViewModel tag);

        void Delete(Guid tagId);
    }
}