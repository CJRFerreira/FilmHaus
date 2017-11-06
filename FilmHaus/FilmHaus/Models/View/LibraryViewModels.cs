using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FilmHaus.Models.View
{
    public class UserLibraryViewModel
    {
        public UserLibraryViewModel()
        {
        }

        public UserLibraryViewModel(List<UserFilmViewModel> films, List<UserShowViewModel> shows)
        {
            Films = films;
            Shows = shows;
        }

        public List<UserFilmViewModel> Films { get; set; }

        public List<UserShowViewModel> Shows { get; set; }
    }

    public class SearchLibraryViewModel
    {
        public SearchLibraryViewModel()
        {
        }

        public SearchLibraryViewModel(List<GeneralFilmViewModel> films, List<GeneralShowViewModel> shows)
        {
            Films = films;
            Shows = shows;
        }

        public List<GeneralFilmViewModel> Films { get; set; }

        public List<GeneralShowViewModel> Shows { get; set; }
    }
}