using FilmHaus.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilmHaus.Models.Connector
{
    public class ShowTag
    {
        [Key]
        public Guid ShowTagId { get; set; }

        [ForeignKey("Show"), Column(Order = 0)]
        public Guid MediaId { get; set; }

        public virtual Show Show { get; set; }

        [ForeignKey("Tag"), Column(Order = 1)]
        public Guid DetailId { get; set; }

        public virtual Tag Tag { get; set; }
    }
}