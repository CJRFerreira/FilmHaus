using FilmHaus.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FilmHaus.Models.Connector
{
    public class ListTag
    {
        [Key]
        public Guid ListTagId { get; set; }

        [ForeignKey("List"), Column(Order = 0)]
        public Guid ListId { get; set; }

        public virtual List List { get; set; }

        [ForeignKey("Tag"), Column(Order = 1)]
        public Guid DetailId { get; set; }

        public virtual Tag Tag { get; set; }
    }
}