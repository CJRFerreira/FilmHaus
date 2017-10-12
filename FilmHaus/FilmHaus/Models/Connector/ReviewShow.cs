using FilmHaus.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FilmHaus.Models.Connector
{
    [Table("ReviewShow")]
    public class ReviewShow
    {
        [Key]
        public Guid ReviewShowId { get; set; }

        [ForeignKey("Show"), Column(Order = 0)]
        [Index(name: "IX_ReviewShow", order: 0, IsUnique = true)]
        public Guid MediaId { get; set; }

        public virtual Show Show { get; set; }

        public DateTime CreatedOn { get; set; }

        [Index(name: "IX_ReviewShow", order: 1, IsUnique = true)]
        public DateTime? ObsoletedOn { get; set; }

        [ForeignKey("Review"), Column(Order = 1)]
        public Guid ReviewId { get; set; }

        public virtual Review Review { get; set; }
    }
}