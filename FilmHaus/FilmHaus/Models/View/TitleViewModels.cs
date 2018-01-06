﻿using FilmHaus.Localization;
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
    public class TitleViewModel : DetailViewModel
    {
        public TitleViewModel() : base()
        {
        }

        public TitleViewModel(Title title)
        {
            DetailId = title.DetailId;
            Name = title.Name;
        }
    }

    public class CreateTitleViewModel : CreateDetailViewModel
    {
        public CreateTitleViewModel() : base()
        {
        }
    }

    public class EditTitleViewModel : EditDetailViewModel
    {
        public EditTitleViewModel() : base()
        {
        }

        public EditTitleViewModel(Title title)
        {
            DetailId = title.DetailId;
            Name = title.Name;
        }

        public EditTitleViewModel(TitleViewModel title)
        {
            DetailId = title.DetailId;
            Name = title.Name;
        }
    }
}