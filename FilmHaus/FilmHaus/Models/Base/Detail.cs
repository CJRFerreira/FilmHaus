using System;
using System.ComponentModel.DataAnnotations;

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