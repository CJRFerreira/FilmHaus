using FilmHaus.Models.Connector;
using System.Collections.Generic;

namespace FilmHaus.Models.Base
{
    public class Title : Detail
    {
        public Title() : base()
        {
        }

        public Title(Title title) : base(title)
        {
        }

        public virtual ICollection<FilmPersonTitle> FilmPersonTitle { get; set; }

        public virtual ICollection<ShowPersonTitle> ShowPersonTitle { get; set; }
    }
}