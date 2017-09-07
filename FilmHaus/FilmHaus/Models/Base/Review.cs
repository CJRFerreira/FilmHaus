﻿using FilmHaus.Localization;
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
        [Required]
        public Guid ReviewId { get; set; }

        [Column(Order = 1)]
        [ForeignKey("User")]
        public string Id { get; set; }

        public virtual User User { get; set; }

        [Column(Order = 2)]
        [ForeignKey("Film")]
        public Guid FilmId { get; set; }

        public virtual Film Film { get; set; }

        [DataType(DataType.MultilineText)]
        public String Body { get; set; }

        [Required]
        public Boolean Shared { get; set; }

        public bool? Flagged { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfCreation { get; set; }
    }
}