using FilmHaus.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FilmHaus.Models.Connector
{
    [Table("ListTag")]
    public class ListTag
    {
        [Key]
        [Column(Order = 1)]
        [ForeignKey("List")]
        public Guid ListId { get; set; }

        public virtual List List { get; set; }

        [Key]
        [Column(Order = 2)]
        [ForeignKey("Tag")]
        public Guid TagId { get; set; }

        public virtual Tag Tag { get; set; }
    }
}