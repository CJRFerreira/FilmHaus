using FilmHaus.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FilmHaus.Models.Connector
{
    [Table("UserFilmRating")]
    public class UserFilmRating
    {
        [Key]
        public Guid UserFilmRatingId { get; set; }

        [ForeignKey("User")]
        [Index(name: "IX_UserFilmRating", order: 0, IsUnique = true)]
        public string Id { get; set; }

        public virtual User User { get; set; }

        [ForeignKey("Film")]
        [Index(name: "IX_UserFilmRating", order: 1, IsUnique = true)]
        public Guid MediaId { get; set; }

        public virtual Film Film { get; set; }

        [Timestamp]
        public DateTimeOffset CreatedOn { get; set; }

        [Timestamp]
        [Index(name: "IX_UserFilmRating", order: 2, IsUnique = true)]
        public DateTimeOffset? ObsoletedOn { get; set; }

        [Range(1, 10)]
        public int? Rating { get; set; }
    }
}