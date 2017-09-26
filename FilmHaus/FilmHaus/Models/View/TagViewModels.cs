﻿using FilmHaus.Localization;
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
            TagId = tag.TagId;
            Name = tag.Name;
        }

        [Display(Name = "Id", ResourceType = typeof(Locale))]
        public Guid TagId { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Tag", ResourceType = typeof(Locale))]
        public string Name { get; set; }
    }

    public class CreateTagViewModel
    {
        public CreateTagViewModel()
        {
        }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Tag", ResourceType = typeof(Locale))]
        public string Name { get; set; }
    }

    public class EditTagViewModel
    {
        public EditTagViewModel()
        {
        }

        public EditTagViewModel(Tag tag)
        {
            TagId = tag.TagId;
            Name = tag.Name;
        }

        public EditTagViewModel(TagViewModel tag)
        {
            TagId = tag.TagId;
            Name = tag.Name;
        }

        [Display(Name = "Id", ResourceType = typeof(Locale))]
        public Guid TagId { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Tag", ResourceType = typeof(Locale))]
        public string Name { get; set; }
    }
}