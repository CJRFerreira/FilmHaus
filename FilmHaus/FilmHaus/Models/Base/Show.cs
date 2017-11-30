using FilmHaus.Models.Connector;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FilmHaus.Models.Base
{
    public class Show : Media
    {
        public Show() : base()
        {
        }

        public Show(Show show) : base(show)
        {
            NumberOfSeasons = show.NumberOfSeasons;
        }

        public int NumberOfSeasons { get; set; }

        public virtual ICollection<ShowGenre> ShowGenres { get; set; }

        public virtual ICollection<ShowTag> ShowTags { get; set; }

        public virtual ICollection<ListShow> ListShows { get; set; }

        public virtual ICollection<ShowPersonTitle> ShowPersonTitles { get; set; }

        public virtual ICollection<UserShow> UserShows { get; set; }

        public virtual ICollection<UserShowRating> UserShowRatings { get; set; }

        public virtual ICollection<ReviewShow> ReviewShows { get; set; }
    }
}