using FilmHaus.Localization;
using FilmHaus.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

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