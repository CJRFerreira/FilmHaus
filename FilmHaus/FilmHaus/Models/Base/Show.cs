using FilmHaus.Models.Connector;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FilmHaus.Models.Base
{
    [Table("Show")]
    public class Show : Media
    {
        public Show()
        {
        }

        public Show(Show show)
        {
            MediaId = show.MediaId;
            PosterUri = show.PosterUri;
            MediaName = show.MediaName;
            DateOfRelease = show.DateOfRelease;
            Accolades = show.Accolades;
            NumberOfSeasons = show.NumberOfSeasons;
        }

        public int NumberOfSeasons { get; set; }

        public virtual ICollection<ShowGenre> ShowGenre { get; set; }

        public virtual ICollection<ShowTag> ShowTag { get; set; }

        public virtual ICollection<ListShow> ListShow { get; set; }

        public virtual ICollection<ShowPersonTitle> ShowPersonTitle { get; set; }

        public virtual ICollection<UserShow> UserShow { get; set; }
    }
}