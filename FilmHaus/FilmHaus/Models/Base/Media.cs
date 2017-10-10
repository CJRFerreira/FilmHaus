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

        public Media(Guid mediaId, Uri posterUri, string mediaName, DateTimeOffset dateOfRelease, AwardStatus accolades, DateTimeOffset createdOn, DateTimeOffset obsoletedOn)
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
        [Required]
        public Guid MediaId { get; set; }

        [DataType(DataType.ImageUrl)]
        public Uri PosterUri { get; set; }

        [Required]
        public string MediaName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTimeOffset DateOfRelease { get; set; }

        public AwardStatus Accolades { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTimeOffset? CreatedOn { get; set; }

        [DataType(DataType.DateTime)]
        public DateTimeOffset? ObsoletedOn { get; set; }
    }
}