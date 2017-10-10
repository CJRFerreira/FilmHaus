using FilmHaus.Localization;
using FilmHaus.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FilmHaus.Models.View
{
    public abstract class DetailViewModel
    {
        public DetailViewModel()
        {
        }

        public DetailViewModel(Detail detail)
        {
            DetailId = detail.DetailId;
            Name = detail.Name;
        }

        public DetailViewModel(EditDetailViewModel detail)
        {
            DetailId = detail.DetailId;
            Name = detail.Name;
        }

        [Display(Name = "Id", ResourceType = typeof(Locale))]
        public Guid DetailId { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Name", ResourceType = typeof(Locale))]
        public string Name { get; set; }
    }

    public abstract class CreateDetailViewModel
    {
        public CreateDetailViewModel()
        {
        }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Name", ResourceType = typeof(Locale))]
        public string Name { get; set; }
    }

    public abstract class EditDetailViewModel
    {
        public EditDetailViewModel()
        {
        }

        public EditDetailViewModel(Detail detail)
        {
            DetailId = detail.DetailId;
            Name = detail.Name;
        }

        public EditDetailViewModel(DetailViewModel detail)
        {
            DetailId = detail.DetailId;
            Name = detail.Name;
        }

        [Display(Name = "Id", ResourceType = typeof(Locale))]
        public Guid DetailId { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Name", ResourceType = typeof(Locale))]
        public string Name { get; set; }
    }
}