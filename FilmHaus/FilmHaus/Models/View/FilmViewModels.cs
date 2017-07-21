using FilmHaus.Localization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FilmHaus.Models.View
{
    public class FilmViewModels
    {
        public class CreateFilmViewModel
        {
            public Uri PicUri { get; set; }

            [Display(Name = "Title", ResourceType = typeof(Locale))]
            public String FilmName { get; set; }

            [DataType(DataType.Date)]
            [Display(Name = "ReleaseDate", ResourceType = typeof(Locale))]
            public DateTime DateOfRelease { get; set; }

            [Display(Name = "Runtime", ResourceType = typeof(Locale))]
            public Int32 Runtime { get; set; }

            [Display(Name = "Rating", ResourceType = typeof(Locale))]
            public Int32 Rating { get; set; }

            [Display(Name = "Accolades", ResourceType = typeof(Locale))]
            public String Accolades { get; set; }
        }

        public class DetailsFilmViewModel
        {
            public Uri PicUri { get; set; }

            [Display(Name = "Title", ResourceType = typeof(Locale))]
            public String FilmName { get; set; }

            [DataType(DataType.Date)]
            [Display(Name = "ReleaseDate", ResourceType = typeof(Locale))]
            public DateTime DateOfRelease { get; set; }

            [Display(Name = "Runtime", ResourceType = typeof(Locale))]
            public Int32 Runtime { get; set; }

            [Display(Name = "Rating", ResourceType = typeof(Locale))]
            public Int32 Rating { get; set; }

            [Display(Name = "Accolades", ResourceType = typeof(Locale))]
            public String Accolades { get; set; }
        }

        public class UpdateFilmViewModel
        {
            public Uri PicUri { get; set; }

            [Display(Name = "Title", ResourceType = typeof(Locale))]
            public String FilmName { get; set; }

            [DataType(DataType.Date)]
            [Display(Name = "ReleaseDate", ResourceType = typeof(Locale))]
            public DateTime DateOfRelease { get; set; }

            [Display(Name = "Runtime", ResourceType = typeof(Locale))]
            public Int32 Runtime { get; set; }

            [Display(Name = "Rating", ResourceType = typeof(Locale))]
            public Int32 Rating { get; set; }

            [Display(Name = "Accolades", ResourceType = typeof(Locale))]
            public String Accolades { get; set; }
        }

        public class DeleteFilmViewModel
        {
            [Key]
            public Guid Id { get; set; }

            public Uri PicUri { get; set; }

            [Display(Name = "Title", ResourceType = typeof(Locale))]
            public String FilmName { get; set; }
        }
    }
}