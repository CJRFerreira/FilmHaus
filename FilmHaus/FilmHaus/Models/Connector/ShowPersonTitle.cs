using FilmHaus.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FilmHaus.Models.Connector
{
    [Table("ShowPersonTitle")]
    public class ShowPersonTitle
    {
        [Key]
        public Guid ShowPersonTitleId { get; set; }

        [ForeignKey("Show"), Column(Order = 0)]
        public Guid MediaId { get; set; }

        public virtual Show Show { get; set; }

        [ForeignKey("Person"), Column(Order = 1)]
        public Guid PersonId { get; set; }

        public virtual Person Person { get; set; }

        [ForeignKey("Title"), Column(Order = 2)]
        public Guid DetailId { get; set; }

        public virtual Title Title { get; set; }
    }
}