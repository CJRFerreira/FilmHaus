using FilmHaus.Localization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FilmHaus.Models.View
{
    public class ListViewModel
    {
        [Required]
        [Display(Name = "Title", ResourceType = typeof(Locale))]
        public String Title { get; set; }

        [Display(Name = "Description", ResourceType = typeof(Locale))]
        public String Description { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "CreatedOn", ResourceType = typeof(Locale))]
        public DateTime DateOfCreation { get; set; }

        [Required]
        [Display(Name = "Shared", ResourceType = typeof(Locale))]
        public Boolean Shared { get; set; }
    }
}