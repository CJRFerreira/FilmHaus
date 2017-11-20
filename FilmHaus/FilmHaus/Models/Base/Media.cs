using FilmHaus.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        }

        public Media(Guid mediaId, string posterUri, string mediaName, DateTime dateOfRelease, AwardStatus accolades, DateTime createdOn)
        {
            MediaId = mediaId;
            PosterUri = posterUri;
            MediaName = mediaName;
            DateOfRelease = dateOfRelease;
            Accolades = accolades;
            CreatedOn = createdOn;
        }

        [Key]
        public Guid MediaId { get; set; }

        [DataType(DataType.ImageUrl)]
        public string PosterUri { get; set; }

        [Required]
        public string MediaName { get; set; }

        [Required]
        public DateTime DateOfRelease { get; set; }

        public AwardStatus Accolades { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }
    }
}