using FilmHaus.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FilmHaus.Models.Base
{
    public abstract class Media
    {
        public Media()
        {
        }

        public Media(Media media)
        {
            MediaId = media.MediaId;
            PosterUri = media.PosterUri;
            MediaName = media.MediaName;
            DateOfRelease = media.DateOfRelease;
            Accolades = media.Accolades;
            CreatedOn = media.CreatedOn;
            ObsoletedOn = media.ObsoletedOn;
        }

        public Media(Guid mediaId, Uri posterUri, string mediaName, DateTime dateOfRelease, AwardStatus accolades, DateTime createdOn, DateTime obsoletedOn)
        {
            MediaId = mediaId;
            PosterUri = posterUri;
            MediaName = mediaName;
            DateOfRelease = dateOfRelease;
            Accolades = accolades;
            CreatedOn = createdOn;
            ObsoletedOn = obsoletedOn;
        }

        [Key]
        public Guid MediaId { get; set; }

        public Uri PosterUri { get; set; }

        [Required]
        public string MediaName { get; set; }

        [Required]
        public DateTime DateOfRelease { get; set; }

        public AwardStatus Accolades { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        public DateTime? ObsoletedOn { get; set; }
    }
}