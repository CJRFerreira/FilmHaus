using FilmHaus.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FilmHaus.Models.Connector
{
    [Table("FilmPersonRole")]
    public class FilmPersonRole
    {
        [Key]
        [Column(Order = 1)]
        [ForeignKey("FilmPerson")]
        public Guid FilmPersonId { get; set; }

        public virtual FilmPerson FilmPerson { get; set; }

        [Key]
        [Column(Order = 2)]
        [ForeignKey("FilmRole")]
        public Guid FilmRoleId { get; set; }

        public virtual FilmRole FilmRole { get; set; }
    }
}