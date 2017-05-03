using FilmHaus.Models.Connector;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FilmHaus.Models.Base
{
    [Table("List")]
    public class List
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("Users")]
        public String UserId { get; set; }

        public virtual User User { get; set; }

        public String Title { get; set; }
        public String Description { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Created On")]
        public DateTime DateOfCreation { get; set; }

        public enum Status
        {
            Public = 0,
            Private = 0
        }

        public virtual ICollection<ListFilm> ListFilm { get; set; }
    }
}