using FilmHaus.Localization;
using FilmHaus.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FilmHaus.Models.View
{
    public class GenreViewModel : DetailViewModel
    {
        public GenreViewModel()
        {
        }

        public GenreViewModel(Genre genre)
        {
            DetailId = genre.DetailId;
            Name = genre.Name;
        }

        public GenreViewModel(EditGenreViewModel genre)
        {
            DetailId = genre.DetailId;
            Name = genre.Name;
        }
    }

    public class CreateGenreViewModel : CreateDetailViewModel
    {
        public CreateGenreViewModel()
        {
        }
    }

    public class EditGenreViewModel : EditDetailViewModel
    {
        public EditGenreViewModel()
        {
        }

        public EditGenreViewModel(Genre genre)
        {
            DetailId = genre.DetailId;
            Name = genre.Name;
        }

        public EditGenreViewModel(GenreViewModel genre)
        {
            DetailId = genre.DetailId;
            Name = genre.Name;
        }
    }
}