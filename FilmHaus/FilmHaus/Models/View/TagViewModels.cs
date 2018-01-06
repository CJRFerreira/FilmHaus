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