using FilmHaus.Localization;
using FilmHaus.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FilmHaus.Models.View
{
    public class TagViewModel
    {
        public TagViewModel()
        {
        }

        public TagViewModel(Tag tag)
        {
            Name = tag.Name;
        }

        [DataType(DataType.Text)]
        [Display(Name = "Tag", ResourceType = typeof(Locale))]
        public string Name { get; set; }
    }

    public class CreateTagViewModel
    {
        public CreateTagViewModel()
        {
        }

        public CreateTagViewModel(Tag tag)
        {
            Name = tag.Name;
        }

        public CreateTagViewModel(TagViewModel tag)
        {
            Name = tag.Name;
        }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Tag", ResourceType = typeof(Locale))]
        public string Name { get; set; }
    }
}