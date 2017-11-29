using FilmHaus.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FilmHaus.Models.Connector
{
    public class UserFilm
    {
        [Key]
        public Guid UserFilmId { get; set; }

        [ForeignKey("User"), Column(Order = 0)]
        [Index(name: "IX_UserFilm", order: 0, IsUnique = true)]
        public string Id { get; set; }

        public virtual User User { get; set; }

        [ForeignKey("Film"), Column(Order = 1)]
        [Index(name: "IX_UserFilm", order: 1, IsUnique = true)]
        public Guid MediaId { get; set; }

        public virtual Film Film { get; set; }

        public DateTime CreatedOn { get; set; }

        [Index(name: "IX_UserFilm", order: 2, IsUnique = true)]
        public DateTime? ObsoletedOn { get; set; }
    }
}