using FilmHaus.Localization;
using FilmHaus.Models.Connector;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FilmHaus.Models.Base
{
    [Table("Role")]
    public class Role
    {
        [Key]
        public Guid RoleId { get; set; }

        [DataType(DataType.Text)]
        public String RoleName { get; set; }

        public virtual ICollection<FilmPersonRole> FilmPersonRole { get; set; }
    }
}