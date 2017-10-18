using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilmHaus.Models.Base
{
    public abstract class Detail
    {
        [Key]
        [Index(name: "IX_Detail", order: 0, IsUnique = true)]
        public Guid DetailId { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedOn { get; set; }

        [DataType(DataType.DateTime)]
        [Index(name: "IX_Detail", order: 1, IsUnique = true)]
        public DateTime ObsoletedOn { get; set; }
    }
}