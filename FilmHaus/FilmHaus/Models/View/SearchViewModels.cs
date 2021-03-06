﻿using FilmHaus.Enums;
using FilmHaus.Localization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

/// <summary>
/// Name: Christian Ferreira
/// Date: September 6th - January 5th
///
/// Statement of Authorship:
/// I, Christian Ferreira (Student #: 000346210), certify that this material is my original work.
/// No other person's work has been used without due acknowledgement.
/// </summary>
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

        [Display(Name = "Title", ResourceType = typeof(Locale))]
        public string SearchTerm { get; set; }

        [Display(Name = "Accolades", ResourceType = typeof(Locale))]
        public AwardStatus? Accolades { get; set; }

        [Display(Name = "ReleaseYear", ResourceType = typeof(Locale))]
        public int? ReleaseYear { get; set; }

        [Display(Name = "Rating", ResourceType = typeof(Locale))]
        public int? Rating { get; set; }
    }

    public class SearchAllViewModel : SearchViewModel
    {
        public SearchAllViewModel() : base()
        {
        }

        public SearchAllViewModel(string searchTerm, AwardStatus? accolades, int? releaseYear, int? rating, List<FilmViewModel> films, List<ShowViewModel> shows)
            : base(searchTerm, accolades, releaseYear, rating)
        {
            Films = films;
            Shows = shows;
        }

        public SearchAllViewModel(SearchAllViewModel searchAllViewModel) : base(searchAllViewModel)
        {
            Films = searchAllViewModel.Films;
            Shows = searchAllViewModel.Shows;
        }

        public List<FilmViewModel> Films { get; set; }

        public List<ShowViewModel> Shows { get; set; }
    }

    public class SearchShowsViewModel : SearchViewModel
    {
        public SearchShowsViewModel() : base()
        {
        }

        public SearchShowsViewModel(string searchTerm, AwardStatus? accolades, int? releaseYear, int? rating, List<ShowViewModel> shows)
            : base(searchTerm, accolades, releaseYear, rating)
        {
            Shows = shows;
        }

        public SearchShowsViewModel(SearchShowsViewModel searchShowsViewModel) : base(searchShowsViewModel)
        {
            Shows = searchShowsViewModel.Shows;
        }

        public List<ShowViewModel> Shows { get; set; }
    }

    public class SearchFilmsViewModel : SearchViewModel
    {
        public SearchFilmsViewModel() : base()
        {
        }

        public SearchFilmsViewModel(string searchTerm, AwardStatus? accolades, int? releaseYear, int? rating, List<FilmViewModel> films)
            : base(searchTerm, accolades, releaseYear, rating)
        {
            Films = films;
        }

        public SearchFilmsViewModel(SearchFilmsViewModel searchFilmsViewModel) : base(searchFilmsViewModel)
        {
            Films = searchFilmsViewModel.Films;
        }

        public List<FilmViewModel> Films { get; set; }
    }
}