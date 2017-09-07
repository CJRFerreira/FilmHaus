using FilmHaus.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FilmHaus.Models.Connector
{
    [Table("UserShow")]
    public class UserShow
    {
        [Key]
        [Column(Order = 1)]
        [ForeignKey("User")]
        public string Id { get; set; }

        public virtual User User { get; set; }

        [Key]
        [Column(Order = 2)]
        [ForeignKey("Show")]
        public Guid ShowId { get; set; }

        public virtual Show Show { get; set; }
    }
}