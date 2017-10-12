using FilmHaus.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FilmHaus.Models.Connector
{
    [Table("ListShow")]
    public class ListShow
    {
        [Key]
        public Guid ListShowId { get; set; }

        [ForeignKey("Show"), Column(Order = 0)]
        [Index(name: "IX_ListShow", order: 0, IsUnique = true)]
        public Guid MediaId { get; set; }

        public virtual Show Show { get; set; }

        public DateTime CreatedOn { get; set; }

        [Index(name: "IX_ListShow", order: 1, IsUnique = true)]
        public DateTime? ObsoletedOn { get; set; }

        [ForeignKey("List"), Column(Order = 1)]
        public Guid ListId { get; set; }

        public virtual List List { get; set; }
    }
}