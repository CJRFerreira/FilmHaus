using FilmHaus.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FilmHaus.Models.Connector
{
    [Table("FilmTag")]
    public class FilmTag
    {
        [Key]
        [Column(Order = 1)]
        [ForeignKey("Film")]
        public Guid MediaId { get; set; }

        public virtual Film Film { get; set; }

        [Key]
        [Column(Order = 2)]
        [ForeignKey("Tag")]
        public Guid TagId { get; set; }

        public virtual Tag Tag { get; set; }
    }
}