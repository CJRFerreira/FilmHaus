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
            ListId = list.ListId;
            UserId = list.Id;
            Title = list.Title;
            Description = list.Description;
            DateOfCreation = list.CreatedOn;
            Shared = list.Shared;
        }

        public ListViewModel(EditListViewModel list)
        {
            ListId = list.ListId;
            UserId = list.UserId;
            Title = list.Title;
            Description = list.Description;
            DateOfCreation = list.DateOfCreation;
            Shared = list.Shared;
        }

        [Display(Name = "Id", ResourceType = typeof(Locale))]
        public Guid ListId { get; set; }

        [Display(Name = "Id", ResourceType = typeof(Locale))]
        public string UserId { get; set; }

        [Display(Name = "Title", ResourceType = typeof(Locale))]
        public string Title { get; set; }

        [Display(Name = "Description", ResourceType = typeof(Locale))]
        public string Description { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "CreatedOn", ResourceType = typeof(Locale))]
        public DateTime DateOfCreation { get; set; }

        [Display(Name = "Shared", ResourceType = typeof(Locale))]
        public bool Shared { get; set; }
    }

    public class CreateListViewModel
    {
        public CreateListViewModel()
        {
        }

        [Required]
        [Display(Name = "Title", ResourceType = typeof(Locale))]
        public string Title { get; set; }

        [Display(Name = "Description", ResourceType = typeof(Locale))]
        public string Description { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "CreatedOn", ResourceType = typeof(Locale))]
        public DateTime DateOfCreation { get; set; }

        [Required]
        [Display(Name = "Shared", ResourceType = typeof(Locale))]
        public bool Shared { get; set; }
    }

    public class EditListViewModel
    {
        public EditListViewModel()
        {
        }

        public EditListViewModel(List list)
        {
            ListId = list.ListId;
            UserId = list.Id;
            Title = list.Title;
            Description = list.Description;
            DateOfCreation = list.CreatedOn;
            Shared = list.Shared;
        }

        public EditListViewModel(ListViewModel list)
        {
            ListId = list.ListId;
            UserId = list.UserId;
            Title = list.Title;
            Description = list.Description;
            Shared = list.Shared;
        }

        [Display(Name = "Id", ResourceType = typeof(Locale))]
        public Guid ListId { get; set; }

        [Display(Name = "Id", ResourceType = typeof(Locale))]
        public string UserId { get; set; }

        [Required]
        [Display(Name = "Title", ResourceType = typeof(Locale))]
        public string Title { get; set; }

        [Display(Name = "Description", ResourceType = typeof(Locale))]
        public string Description { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "CreatedOn", ResourceType = typeof(Locale))]
        public DateTime DateOfCreation { get; set; }

        [Required]
        [Display(Name = "Shared", ResourceType = typeof(Locale))]
        public bool Shared { get; set; }
    }
}