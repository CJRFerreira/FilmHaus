using FilmHaus.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FilmHaus.Models.Connector
{
    [Table("ShowPersonRole")]
    public class ShowPersonRole
    {
        [Key]
        [Column(Order = 1)]
        [ForeignKey("Show")]
        public Guid ShowId { get; set; }

        public virtual Show Show { get; set; }

        [Key]
        [Column(Order = 2)]
        [ForeignKey("Person")]
        public Guid PersonId { get; set; }

        public virtual Person Person { get; set; }

        [Key]
        [Column(Order = 3)]
        [ForeignKey("Role")]
        public Guid RoleId { get; set; }

        public virtual Role Role { get; set; }
    }
}