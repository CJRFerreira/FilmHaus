using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FilmHaus.Models.View
{
    public class LibraryViewModel
    {
        public LibraryViewModel()
        {
        }

        public LibraryViewModel(List<UserFilmViewModel> films, List<UserShowViewModel> shows)
        {
            Films = films;
            Shows = shows;
        }

        public List<UserFilmViewModel> Films { get; set; }

        public List<UserShowViewModel> Shows { get; set; }
    }

    public class FilmLibraryViewModel
    {
        public FilmLibraryViewModel()
        {
        }

        public FilmLibraryViewModel(List<UserFilmViewModel> films)
        {
            Films = films;
        }

        public List<UserFilmViewModel> Films { get; set; }
    }

    public class ShowLibraryViewModel
    {
        public ShowLibraryViewModel()
        {
        }

        public ShowLibraryViewModel(List<UserShowViewModel> shows)
        {
            Shows = shows;
        }

        public List<UserShowViewModel> Shows { get; set; }
    }
}