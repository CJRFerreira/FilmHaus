using FilmHaus.Enums;
using FilmHaus.Localization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FilmHaus.Models.View
{
    public class SearchViewModel
    {
        public SearchViewModel()
        {
        }

        public string SearchTerm { get; set; }

        [Display(Name = "Accolades", ResourceType = typeof(Locale))]
        public AwardStatus? Accolades { get; set; }

        [Display(Name = "ReleaseDate", ResourceType = typeof(Locale))]
        public int? ReleaseYear { get; set; }

        [Display(Name = "Rating", ResourceType = typeof(Locale))]
        public int? Rating { get; set; }
    }

    public class SearchAllViewModel
    {
        public SearchAllViewModel()
        {
        }

        public SearchAllViewModel(List<GeneralFilmViewModel> films, List<GeneralShowViewModel> shows)
        {
            Films = films;
            Shows = shows;
        }

        public string SearchTerm { get; set; }

        [Display(Name = "Accolades", ResourceType = typeof(Locale))]
        public AwardStatus? Accolades { get; set; }

        [Display(Name = "ReleaseDate", ResourceType = typeof(Locale))]
        public int? ReleaseYear { get; set; }

        [Display(Name = "Rating", ResourceType = typeof(Locale))]
        public int? Rating { get; set; }

        public List<GeneralFilmViewModel> Films { get; set; }

        public List<GeneralShowViewModel> Shows { get; set; }
    }

    public class SearchShowsViewModel
    {
        public SearchShowsViewModel()
        {
        }

        public SearchShowsViewModel(List<GeneralShowViewModel> shows)
        {
            Shows = shows;
        }

        public string SearchTerm { get; set; }

        [Display(Name = "Accolades", ResourceType = typeof(Locale))]
        public AwardStatus? Accolades { get; set; }

        [Display(Name = "ReleaseDate", ResourceType = typeof(Locale))]
        public int? ReleaseYear { get; set; }

        [Display(Name = "Rating", ResourceType = typeof(Locale))]
        public int? Rating { get; set; }

        public List<GeneralShowViewModel> Shows { get; set; }
    }

    public class SearchFilmsViewModel
    {
        public SearchFilmsViewModel()
        {
        }

        public SearchFilmsViewModel(List<GeneralFilmViewModel> films)
        {
            Films = films;
        }

        public string SearchTerm { get; set; }

        [Display(Name = "Accolades", ResourceType = typeof(Locale))]
        public AwardStatus? Accolades { get; set; }

        [Display(Name = "ReleaseDate", ResourceType = typeof(Locale))]
        public int? ReleaseYear { get; set; }

        [Display(Name = "Rating", ResourceType = typeof(Locale))]
        public int? Rating { get; set; }

        public List<GeneralFilmViewModel> Films { get; set; }
    }
}