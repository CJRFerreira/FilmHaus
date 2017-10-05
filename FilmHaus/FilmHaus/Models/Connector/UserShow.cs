using FilmHaus.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FilmHaus.Models.Connector
{
    [Table("UserShow")]
    public class UserShow
    {
        [Key]
        public Guid UserShowId { get; set; }

        [Column(Order = 1)]
        [ForeignKey("User")]
        [Index(name: "IX_UserShow", order: 0, IsUnique = true)]
        public string Id { get; set; }

        public virtual User User { get; set; }

        [Column(Order = 2)]
        [ForeignKey("Show")]
        [Index(name: "IX_UserShow", order: 1, IsUnique = true)]
        public Guid MediaId { get; set; }

        public virtual Show Show { get; set; }

        [Timestamp]
        public DateTimeOffset CreatedOn { get; set; }

        [Timestamp]
        [Index(name: "IX_UserShow", order: 2, IsUnique = true)]
        public DateTimeOffset? ObsoletedOn { get; set; }
    }
}