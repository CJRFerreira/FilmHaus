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

        public LibraryViewModel(List<FilmViewModel> films, List<ShowViewModel> shows)
        {
            Films = films;
            Shows = shows;
        }

        public List<FilmViewModel> Films { get; set; }

        public List<ShowViewModel> Shows { get; set; }
    }

    public class FilmLibraryViewModel
    {
        public FilmLibraryViewModel()
        {
        }

        public FilmLibraryViewModel(List<FilmViewModel> films)
        {
            Films = films;
        }

        public List<FilmViewModel> Films { get; set; }
    }

    public class ShowLibraryViewModel
    {
        public ShowLibraryViewModel()
        {
        }

        public ShowLibraryViewModel(List<ShowViewModel> shows)
        {
            Shows = shows;
        }

        public List<ShowViewModel> Shows { get; set; }
    }
}