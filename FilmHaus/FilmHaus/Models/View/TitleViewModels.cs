using FilmHaus.Localization;
using FilmHaus.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FilmHaus.Models.View
{
    public class TitleViewModel
    {
        public TitleViewModel()
        {
        }

        public TitleViewModel(Title title)
        {
            TitleId = title.TitleId;
            Name = title.TitleName;
        }

        [Display(Name = "Id", ResourceType = typeof(Locale))]
        public Guid TitleId { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Name", ResourceType = typeof(Locale))]
        public string Name { get; set; }
    }

    public class CreateTitleViewModel
    {
        public CreateTitleViewModel()
        {
        }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Tag", ResourceType = typeof(Locale))]
        public string Name { get; set; }
    }

    public class EditTitleViewModel
    {
        public EditTitleViewModel()
        {
        }

        public EditTitleViewModel(Title title)
        {
            TitleId = title.TitleId;
            Name = title.TitleName;
        }

        public EditTitleViewModel(TitleViewModel title)
        {
            TitleId = title.TitleId;
            Name = title.Name;
        }

        [Display(Name = "Id", ResourceType = typeof(Locale))]
        public Guid TitleId { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Name", ResourceType = typeof(Locale))]
        public string Name { get; set; }
    }
}