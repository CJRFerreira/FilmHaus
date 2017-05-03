using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FilmHaus.Models.Base
{
    [Table("Review")]
    public class Review
    {
        [Key]
        public Guid Id { get; set; }

        [Key]
        [Column(Order = 1)]
        [ForeignKey("User")]
        public Guid UserId { get; set; }

        public virtual User User { get; set; }

        [Key]
        [Column(Order = 2)]
        [ForeignKey("Film")]
        public Guid FilmId { get; set; }

        public virtual Film Film { get; set; }

        public String Body { get; set; }

        public enum Status
        {
            Public = 0,
            Private = 1,
        }

        public bool Flagged { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Created On")]
        public DateTime DateOfCreation { get; set; }
    }
}