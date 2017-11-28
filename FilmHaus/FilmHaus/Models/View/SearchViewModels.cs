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

        public SearchViewModel(string searchTerm, AwardStatus? accolades, int? releaseYear, int? rating)
        {
            SearchTerm = searchTerm;
            Accolades = accolades;
            ReleaseYear = releaseYear;
            Rating = rating;
        }

        public SearchViewModel(SearchViewModel searchViewModel)
        {
            SearchTerm = searchViewModel.SearchTerm;
            Accolades = searchViewModel.Accolades;
            ReleaseYear = searchViewModel.ReleaseYear;
            Rating = searchViewModel.Rating;
        }

        [Required]
        [Display(Name = "Search", ResourceType = typeof(Locale))]
        public string SearchTerm { get; set; }

        [Display(Name = "Accolades", ResourceType = typeof(Locale))]
        public AwardStatus? Accolades { get; set; }

        [Display(Name = "ReleaseDate", ResourceType = typeof(Locale))]
        public int? ReleaseYear { get; set; }

        [Display(Name = "Rating", ResourceType = typeof(Locale))]
        public int? Rating { get; set; }
    }

    public class SearchAllViewModel : SearchViewModel
    {
        public SearchAllViewModel() : base()
        {
        }

        public SearchAllViewModel(string searchTerm, AwardStatus? accolades, int? releaseYear, int? rating, List<GeneralFilmViewModel> films, List<GeneralShowViewModel> shows) : base(searchTerm, accolades, releaseYear, rating)
        {
            Films = films;
            Shows = shows;
        }

        public SearchAllViewModel(SearchAllViewModel searchAllViewModel) : base(searchAllViewModel)
        {
            Films = searchAllViewModel.Films;
            Shows = searchAllViewModel.Shows;
        }

        public List<GeneralFilmViewModel> Films { get; set; }

        public List<GeneralShowViewModel> Shows { get; set; }
    }

    public class SearchShowsViewModel : SearchViewModel
    {
        public SearchShowsViewModel() : base()
        {
        }

        public SearchShowsViewModel(string searchTerm, AwardStatus? accolades, int? releaseYear, int? rating, List<GeneralShowViewModel> shows) : base(searchTerm, accolades, releaseYear, rating)
        {
            Shows = shows;
        }

        public SearchShowsViewModel(SearchShowsViewModel searchShowsViewModel) : base(searchShowsViewModel)
        {
            Shows = searchShowsViewModel.Shows;
        }

        public List<GeneralShowViewModel> Shows { get; set; }
    }

    public class SearchFilmsViewModel : SearchViewModel
    {
        public SearchFilmsViewModel() : base()
        {
        }

        public SearchFilmsViewModel(string searchTerm, AwardStatus? accolades, int? releaseYear, int? rating, List<GeneralFilmViewModel> films) : base(searchTerm, accolades, releaseYear, rating)
        {
            Films = films;
        }

        public SearchFilmsViewModel(SearchFilmsViewModel searchFilmsViewModel) : base(searchFilmsViewModel)
        {
            Films = searchFilmsViewModel.Films;
        }

        public List<GeneralFilmViewModel> Films { get; set; }
    }
}