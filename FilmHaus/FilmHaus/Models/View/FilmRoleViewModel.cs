using FilmHaus.Localization;
using FilmHaus.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FilmHaus.Models.View
{
    public class FilmRoleViewModel
    {
        public FilmRoleViewModel()
        {
        }

        public FilmRoleViewModel(Role filmRole)
        {
            Role = filmRole.RoleName;
        }

        [DataType(DataType.Text)]
        [Display(Name = "Role", ResourceType = typeof(Locale))]
        public String Role { get; set; }
    }
}