using FilmHaus.Localization;
using FilmHaus.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FilmHaus.Models.View
{
    public class ListViewModel
    {
        public ListViewModel()
        {
        }

        public ListViewModel(List list)
        {
            Title = list.Title;
            Description = list.Description;
            DateOfCreation = list.DateOfCreation;
            Shared = list.Shared;
        }

        [Display(Name = "Title", ResourceType = typeof(Locale))]
        public String Title { get; set; }

        [Display(Name = "Description", ResourceType = typeof(Locale))]
        public String Description { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "CreatedOn", ResourceType = typeof(Locale))]
        public DateTime DateOfCreation { get; set; }

        [Display(Name = "Shared", ResourceType = typeof(Locale))]
        public Boolean Shared { get; set; }
    }

    public class CreateListViewModel
    {
        public CreateListViewModel()
        {
        }

        [Required]
        [Display(Name = "Title", ResourceType = typeof(Locale))]
        public String Title { get; set; }

        [Display(Name = "Description", ResourceType = typeof(Locale))]
        public String Description { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "CreatedOn", ResourceType = typeof(Locale))]
        public DateTime DateOfCreation { get; set; }

        [Required]
        [Display(Name = "Shared", ResourceType = typeof(Locale))]
        public Boolean Shared { get; set; }
    }

    public class EditListViewModel
    {
        public EditListViewModel()
        {
        }

        public EditListViewModel(List list)
        {
            Title = list.Title;
            Description = list.Description;
            DateOfCreation = list.DateOfCreation;
            Shared = list.Shared;
        }

        [Required]
        [Display(Name = "Title", ResourceType = typeof(Locale))]
        public String Title { get; set; }

        [Display(Name = "Description", ResourceType = typeof(Locale))]
        public String Description { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "CreatedOn", ResourceType = typeof(Locale))]
        public DateTime DateOfCreation { get; set; }

        [Required]
        [Display(Name = "Shared", ResourceType = typeof(Locale))]
        public Boolean Shared { get; set; }
    }
}