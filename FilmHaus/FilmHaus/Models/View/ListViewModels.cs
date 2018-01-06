using FilmHaus.Localization;
using FilmHaus.Models.Base;
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
    public class ListViewModel
    {
        public ListViewModel()
        {
        }

        public ListViewModel(List list)
        {
            ListId = list.ListId;
            Id = list.Id;
            Title = list.Title;
            Description = list.Description;
            CreatedOn = list.CreatedOn;
            Shared = list.Shared;
        }

        public ListViewModel(EditListViewModel list)
        {
            ListId = list.ListId;
            Id = list.Id;
            Title = list.Title;
            Description = list.Description;
            Shared = list.Shared;
        }

        [Display(Name = "Id", ResourceType = typeof(Locale))]
        public Guid ListId { get; set; }

        [Display(Name = "Id", ResourceType = typeof(Locale))]
        public string Id { get; set; }

        [Display(Name = "Title", ResourceType = typeof(Locale))]
        public string Title { get; set; }

        [Display(Name = "Description", ResourceType = typeof(Locale))]
        public string Description { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "CreatedOn", ResourceType = typeof(Locale))]
        public DateTime CreatedOn { get; set; }

        [Display(Name = "Shared", ResourceType = typeof(Locale))]
        public bool Shared { get; set; }
    }

    public class CreateListViewModel
    {
        public CreateListViewModel()
        {
        }

        public CreateListViewModel(string id)
        {
            Id = id;
        }

        [Display(Name = "Id", ResourceType = typeof(Locale))]
        public string Id { get; set; }

        [Required]
        [Display(Name = "Title", ResourceType = typeof(Locale))]
        public string Title { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Description", ResourceType = typeof(Locale))]
        public string Description { get; set; }

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
            Id = list.Id;
            Title = list.Title;
            Description = list.Description;
            Shared = list.Shared;
        }

        public EditListViewModel(ListViewModel list)
        {
            ListId = list.ListId;
            Id = list.Id;
            Title = list.Title;
            Description = list.Description;
            Shared = list.Shared;
        }

        [Display(Name = "Id", ResourceType = typeof(Locale))]
        public Guid ListId { get; set; }

        [Display(Name = "Id", ResourceType = typeof(Locale))]
        public string Id { get; set; }

        [Required]
        [Display(Name = "Title", ResourceType = typeof(Locale))]
        public string Title { get; set; }

        [Display(Name = "Description", ResourceType = typeof(Locale))]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Shared", ResourceType = typeof(Locale))]
        public bool Shared { get; set; }
    }
}