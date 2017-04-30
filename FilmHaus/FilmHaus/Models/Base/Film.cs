using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FilmHaus.Models.Base
{
    [Table("Film")]
    public class Film
    {
        public Guid ID { get; set; }
        public String FilmName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfRelease { get; set; }

        public Int32 Runtime { get; set; }
        public Int32 Rating { get; set; }
        public String Accolades { get; set; }
    }
}