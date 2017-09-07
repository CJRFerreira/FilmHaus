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
        public String Title { get; set; }

        public String Description { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfCreation { get; set; }

        [Required]
        [Display(Name = "Shared", ResourceType = typeof(Locale))]
        public Boolean Shared { get; set; }

        
        public virtual ICollection<ListFilm> ListFilm { get; set; }

        
        public virtual ICollection<ListTag> ListTag { get; set; }
    }
}