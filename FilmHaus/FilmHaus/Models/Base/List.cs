using FilmHaus.Localization;
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
        [Required]
        public Guid ListId { get; set; }

        [ForeignKey("User")]
        public string Id { get; set; }

        public virtual User User { get; set; }

        [Required]
        [Display(Name = "Title", ResourceType = typeof(Locale))]
        public String Title { get; set; }

        [Display(Name = "Description", ResourceType = typeof(Locale))]
        public String Description { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "CreatedOn", ResourceType = typeof(Locale))]
        public DateTime DateOfCreation { get; set; }

        public enum Status
        {
            Public = 0,
            Private = 0
        }

        [NotMapped]
        public virtual ICollection<ListFilm> ListFilm { get; set; }

        [NotMapped]
        public virtual ICollection<ListTag> ListTag { get; set; }
    }
}