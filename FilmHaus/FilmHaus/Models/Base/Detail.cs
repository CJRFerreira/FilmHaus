using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilmHaus.Models.Base
{
    public abstract class Detail
    {
        public Detail()
        {
        }

        public Detail(Detail detail)
        {
            DetailId = detail.DetailId;
            Name = detail.Name;
            CreatedOn = detail.CreatedOn;
        }

        [Key]
        public Guid DetailId { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedOn { get; set; }
    }
}