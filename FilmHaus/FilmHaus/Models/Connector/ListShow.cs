﻿using FilmHaus.Models.Base;
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
        public Guid ListShpwId { get; set; }

        [Column(Order = 1)]
        [ForeignKey("Show")]
        [Index(name: "IX_ListShow", order: 0, IsUnique = true)]
        public Guid MediaId { get; set; }

        public virtual Show Show { get; set; }

        [Timestamp]
        public DateTimeOffset CreatedOn { get; set; }

        [Timestamp]
        [Index(name: "IX_ListShow", order: 1, IsUnique = true)]
        public DateTimeOffset? ObsoletedOn { get; set; }

        [Column(Order = 2)]
        [ForeignKey("List")]
        public Guid ListId { get; set; }

        public virtual List List { get; set; }
    }
}