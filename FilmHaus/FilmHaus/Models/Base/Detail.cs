using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FilmHaus.Models.Base
{
    public abstract class Detail
    {
        [Key]
        public Guid DetailId { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Name { get; set; }
    }
}