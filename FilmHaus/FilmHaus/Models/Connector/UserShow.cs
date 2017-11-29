using FilmHaus.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FilmHaus.Models.Connector
{
    public class UserShow
    {
        [Key]
        public Guid UserShowId { get; set; }

        [ForeignKey("User"), Column(Order = 0)]
        [Index(name: "IX_UserShow", order: 0, IsUnique = true)]
        public string Id { get; set; }

        public virtual User User { get; set; }

        [ForeignKey("Show"), Column(Order = 1)]
        [Index(name: "IX_UserShow", order: 1, IsUnique = true)]
        public Guid MediaId { get; set; }

        public virtual Show Show { get; set; }

        public DateTime CreatedOn { get; set; }

        [Index(name: "IX_UserShow", order: 2, IsUnique = true)]
        public DateTime? ObsoletedOn { get; set; }
    }
}