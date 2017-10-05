using FilmHaus.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilmHaus.Models.Connector
{
    [Table("ShowTag")]
    public class ShowTag
    {
        [Key]
        public Guid ShowTagId { get; set; }

        [Column(Order = 1)]
        [ForeignKey("Show")]
        public Guid MediaId { get; set; }

        public virtual Show Show { get; set; }

        [Column(Order = 2)]
        [ForeignKey("Tag")]
        public Guid TagId { get; set; }

        public virtual Tag Tag { get; set; }
    }
}