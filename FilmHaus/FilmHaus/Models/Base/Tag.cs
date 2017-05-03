using FilmHaus.Models.Connector;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FilmHaus.Models.Base
{
    [Table("Tag")]
    public class Tag
    {
        [Key]
        public Guid Id { get; set; }

        public String Name { get; set; }

        public virtual ICollection<FilmTag> FilmTag { get; set; }
    }
}