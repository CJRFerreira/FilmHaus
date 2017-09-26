using FilmHaus.Localization;
using FilmHaus.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FilmHaus.Models.View
{
    public class GenreViewModel
    {
        public GenreViewModel()
        {
        }

        public GenreViewModel(Genre genre)
        {
            GenreId = genre.GenreId;
            Name = genre.Name;
        }

        public GenreViewModel(EditGenreViewModel genre)
        {
            GenreId = genre.GenreId;
            Name = genre.Name;
        }

        [Display(Name = "Id", ResourceType = typeof(Locale))]
        public Guid GenreId { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Genre", ResourceType = typeof(Locale))]
        public string Name { get; set; }
    }

    public class CreateGenreViewModel
    {
        public CreateGenreViewModel()
        {
        }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Genre", ResourceType = typeof(Locale))]
        public string Name { get; set; }
    }

    public class EditGenreViewModel
    {
        public EditGenreViewModel()
        {
        }

        public EditGenreViewModel(Genre genre)
        {
            GenreId = genre.GenreId;
            Name = genre.Name;
        }

        public EditGenreViewModel(GenreViewModel genre)
        {
            GenreId = genre.GenreId;
            Name = genre.Name;
        }

        [Display(Name = "Id", ResourceType = typeof(Locale))]
        public Guid GenreId { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Genre", ResourceType = typeof(Locale))]
        public string Name { get; set; }
    }
}