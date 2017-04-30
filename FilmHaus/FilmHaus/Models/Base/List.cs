using FilmHaus.Models;
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
        public Guid ID { get; set; }

        [Key]
        [ForeignKey("AspNetUsers")]
        public String UserID { get; set; }

        public String Title { get; set; }
        public String Description { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfCreation { get; set; }

        public virtual ICollection<Film> FilmsInList { get; set; }
    }
}