using FilmHaus.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FilmHaus.Models.Connector
{
    [Table("UserFilm")]
    public class UserFilm
    {
        [Key]
        [Column(Order = 1)]
        [ForeignKey("User")]
        public Guid UserId { get; set; }

        public virtual User User { get; set; }

        [Key]
        [Column(Order = 2)]
        [ForeignKey("Film")]
        public Guid FilmId { get; set; }

        public virtual Film Film { get; set; }
    }
}