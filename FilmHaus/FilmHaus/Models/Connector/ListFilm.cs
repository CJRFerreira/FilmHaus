using FilmHaus.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FilmHaus.Models.Connector
{
    [Table("ListFilm")]
    public class ListFilm
    {
        [Key]
        [Column(Order = 1)]
        [ForeignKey("Film")]
        public Guid MediaId { get; set; }

        public virtual Film Film { get; set; }

        [Key]
        [Column(Order = 2)]
        [ForeignKey("List")]
        public Guid ListId { get; set; }

        public virtual List List { get; set; }
    }
}