using FilmHaus.Models;
using FilmHaus.Services.FilmTags;
using FilmHaus.Services.ShowTags;

namespace FilmHaus.Services.Tags
{
    public class TagService : ITagService
    {
        private FilmHausDbContext FilmHausDbContext { get; set; }

        private IFilmTagService FilmTagService { get; set; }

        private IShowTagService ShowTagService { get; set; }

        public TagService(FilmHausDbContext filmHausDbContext)
        {
            FilmHausDbContext = filmHausDbContext;
        }
    }
}