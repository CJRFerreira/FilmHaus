using FilmHaus.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FilmHaus.Models.Connector
{
    public class ReviewFilm
    {
        [Key]
        public Guid ReviewFilmId { get; set; }

        [ForeignKey("Film"), Column(Order = 0)]
        [Index(name: "IX_ReviewFilm", order: 0, IsUnique = true)]
        public Guid MediaId { get; set; }

        public virtual Film Film { get; set; }

        [ForeignKey("Review"), Column(Order = 1)]
        [Index(name: "IX_ReviewFilm", order: 1, IsUnique = true)]
        public Guid ReviewId { get; set; }

        public virtual Review Review { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime CreatedOn { get; set; }

        [Index(name: "IX_ReviewFilm", order: 2, IsUnique = true)]
        public DateTime? ObsoletedOn { get; set; }
    }
}