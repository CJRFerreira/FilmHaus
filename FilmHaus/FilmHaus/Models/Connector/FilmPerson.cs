using FilmHaus.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FilmHaus.Models.Connector
{
    [Table("FilmPerson")]
    public class FilmPerson
    {
        [Key]
        [Column(Order = 1)]
        [ForeignKey("Film")]
        public Guid FilmId { get; set; }

        public virtual Film Film { get; set; }

        [Key]
        [Column(Order = 2)]
        [ForeignKey("Person")]
        public Guid PersonId { get; set; }

        public virtual Person Person { get; set; }

        [Key]
        [Column(Order = 3)]
        [ForeignKey("FilmPersonRole")]
        public Guid FilmPersonRoleId { get; set; }

        public virtual FilmPersonRole FilmPersonRole { get; set; }
    }
}