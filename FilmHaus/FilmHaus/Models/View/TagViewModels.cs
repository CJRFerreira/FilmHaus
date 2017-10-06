using FilmHaus.Localization;
using FilmHaus.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FilmHaus.Models.View
{
    public class TagViewModel : DetailViewModel
    {
        public TagViewModel() : base()
        {
        }

        public TagViewModel(Tag tag)
        {
            DetailId = tag.DetailId;
            Name = tag.Name;
        }
    }

    public class CreateTagViewModel : CreateDetailViewModel
    {
        public CreateTagViewModel() : base()
        {
        }
    }

    public class EditTagViewModel : EditDetailViewModel
    {
        public EditTagViewModel() : base()
        {
        }

        public EditTagViewModel(Tag tag)
        {
            DetailId = tag.DetailId;
            Name = tag.Name;
        }

        public EditTagViewModel(TagViewModel tag)
        {
            DetailId = tag.DetailId;
            Name = tag.Name;
        }
    }
}