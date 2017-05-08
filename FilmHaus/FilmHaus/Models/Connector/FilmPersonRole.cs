using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FilmHaus.Models.Connector
{
    [Table("FilmPersonRole")]
    public class FilmPersonRole
    {
        [Key]
        [Column(Order = 1)]
        [ForeignKey("Film")]
        public Guid FilmPersonId { get; set; }

        public virtual FilmPerson FilmPerson { get; set; }

        [Key]
        [Column(Order = 2)]
        [ForeignKey("Genre")]
        public Guid FilmRoleId { get; set; }

        public virtual FilmRole FilmRole { get; set; }
    }
}