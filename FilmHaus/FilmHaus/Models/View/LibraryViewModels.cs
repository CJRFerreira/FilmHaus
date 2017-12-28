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

        public UserLibraryViewModel(List<FilmViewModel> films, List<ShowViewModel> shows)
        {
            Films = films;
            Shows = shows;
        }

        public List<FilmViewModel> Films { get; set; }

        public List<ShowViewModel> Shows { get; set; }
    }

    public class SearchUserLibraryViewModel
    {
        public SearchUserLibraryViewModel()
        {
        }

        public SearchUserLibraryViewModel(SearchViewModel searchViewModel)
        {
            SearchViewModel = searchViewModel;
        }

        public SearchUserLibraryViewModel(List<FilmViewModel> films, List<ShowViewModel> shows)
        {
            Films = films;
            Shows = shows;
        }

        public SearchUserLibraryViewModel(SearchViewModel searchViewModel, List<FilmViewModel> films, List<ShowViewModel> shows)
        {
            SearchViewModel = searchViewModel;
            Films = films;
            Shows = shows;
        }

        public SearchViewModel SearchViewModel { get; set; }

        public List<FilmViewModel> Films { get; set; }

        public List<ShowViewModel> Shows { get; set; }
    }

    public class SearchLibraryViewModel
    {
        public SearchLibraryViewModel()
        {
        }

        public SearchLibraryViewModel(SearchViewModel searchViewModel)
        {
            SearchViewModel = searchViewModel;
        }

        public SearchLibraryViewModel(List<FilmViewModel> films, List<ShowViewModel> shows)
        {
            Films = films;
            Shows = shows;
        }

        public SearchLibraryViewModel(SearchViewModel searchViewModel, List<FilmViewModel> films, List<ShowViewModel> shows)
        {
            SearchViewModel = searchViewModel;
            Films = films;
            Shows = shows;
        }

        public SearchViewModel SearchViewModel { get; set; }

        public List<FilmViewModel> Films { get; set; }

        public List<ShowViewModel> Shows { get; set; }
    }

    public class ReviewLibraryViewModel
    {
        public ReviewLibraryViewModel()
        {
        }

        public ReviewLibraryViewModel(List<ExpandedReviewViewModel> films, List<ExpandedReviewViewModel> shows)
        {
            FilmReviews = films;
            ShowReviews = shows;
        }

        public List<ExpandedReviewViewModel> FilmReviews { get; set; }

        public List<ExpandedReviewViewModel> ShowReviews { get; set; }
    }

    public class ListLibraryViewModel
    {
        public ListLibraryViewModel()
        {
        }

        public ListLibraryViewModel(List<FilmViewModel> films, List<ShowViewModel> shows)
        {
            Films = films;
            Shows = shows;
        }

        public ListViewModel List { get; set; }

        public List<FilmViewModel> Films { get; set; }

        public List<ShowViewModel> Shows { get; set; }
    }
}